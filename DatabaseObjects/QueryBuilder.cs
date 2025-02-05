﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlQueryTool.Utils;

namespace SqlQueryTool.DatabaseObjects
{
    public static class QueryBuilder
    {
        public enum SelectionShape
        {
            Column,
            Row
        }

        public enum TableSelectLimit
        {
            None,
            LimitTop,
            LimitBottom
        }

        public static string BuildInsertQuery(this TableDefinition table)
        {
            var queryText =
                new StringBuilder($"INSERT INTO {table.Name.ForQueries()}{Environment.NewLine}\t");

            var columnNames = string.Join(", ",
                table.Columns.Where(c => !c.IsIdentity && !c.Type.IsReadOnly).Select(c => c.Name.ForQueries())
                    .ToArray());
            queryText.AppendFormat("({0})", columnNames);

            queryText.AppendFormat("{0}VALUES{0}\t", Environment.NewLine);

            var defaultColumnValues = string.Join(", ",
                table.Columns.Where(c => !c.IsIdentity && !c.Type.IsReadOnly).Select(c => c.FormattedValue).ToArray());
            queryText.AppendFormat("({0})", defaultColumnValues);

            return queryText.ToString();
        }

        public static string BuildSelectRowCountQuery(string tableName)
        {
            return string.Format("SELECT{0}\tCOUNT(*){0}FROM{0}\t{1}", Environment.NewLine, tableName.ForQueries());
        }

        public static string BuildSelectQuery(this TableDefinition table, TableSelectLimit selectLimit,
            string whereClause = "")
        {
            var queryText = new StringBuilder("SELECT ");
            if (selectLimit != TableSelectLimit.None) queryText.Append("TOP 100 ");

            if (table.Columns.Any())
            {
                var columns = string.Join(", ",
                    table.Columns.Select(c => $"{Environment.NewLine}\t{c.ForSelectQueries()}")
                        .ToArray());
                queryText.Append(columns);
            }
            else
            {
                // for views
                queryText.AppendFormat("{0}\t*", Environment.NewLine);
            }

            queryText.AppendFormat("{0}FROM{0}\t{1}", Environment.NewLine, table.Name.ForQueries());

            if (!string.IsNullOrEmpty(whereClause))
                queryText.AppendFormat("{0}WHERE{0}\t{1}", Environment.NewLine, whereClause);

            if (selectLimit == TableSelectLimit.LimitBottom)
            {
                queryText.AppendFormat("{0}ORDER BY", Environment.NewLine);
                if (table.IdentityColumn != null)
                    queryText.AppendFormat("{0}\t{1} DESC", Environment.NewLine,
                        table.IdentityColumn.Name.ForQueries());
                else
                    queryText.AppendFormat("{0}\t? DESC", Environment.NewLine);
            }

            return queryText.ToString();
        }

        public static string BuildUpdateQuery(this TableDefinition table)
        {
            var queryText =
                new StringBuilder(string.Format("UPDATE {0}\t{1}{0}SET", Environment.NewLine, table.Name.ForQueries()));

            var columns = string.Join(", ",
                table.Columns.Where(c => !c.IsIdentity && !c.Type.IsReadOnly).Select(c =>
                        $"{Environment.NewLine}\t{c.Name.ForQueries()} = {c.FormattedValue}")
                    .ToArray());
            queryText.Append(columns);

            queryText.AppendFormat("{0}WHERE{0}\t{1}", Environment.NewLine, GetWhereClause(table));

            return queryText.ToString();
        }

        public static string BuildRowUpdateQuery(string tableName, IEnumerable<SqlCellValue> updateCells,
            SqlCellValue filterCell)
        {
            var queryText =
                new StringBuilder(string.Format("UPDATE {0}\t{1}{0}SET", Environment.NewLine, tableName.ForQueries()));

            foreach (var cell in updateCells)
                queryText.AppendFormat("{0}\t{1} = {2}, ", Environment.NewLine, cell.ColumnName.ForQueries(),
                    cell.SqlFormattedValue);
            queryText.Remove(queryText.Length - 2, 2);

            queryText.AppendFormat("{0}WHERE{0}\t{1} = {2}", Environment.NewLine, filterCell.ColumnName.ForQueries(),
                filterCell.SqlFormattedValue);
            if (!Heuristics.GetIdColumnNames(tableName).Contains(filterCell.ColumnName.ToLower()))
                queryText.AppendFormat("{0}\tAND 1 = 0 /* Reveja a cláusula WHERE! */", Environment.NewLine);

            return queryText.ToString();
        }

        public static string BuildRowDeleteQuery(string tableName, IEnumerable<SqlCellValue> filterCells,
            SelectionShape filterCellsType)
        {
            var queryText = new StringBuilder(string.Format("DELETE FROM{0}\t{1}{0}WHERE{0}\t", Environment.NewLine,
                tableName.ForQueries()));

            if (filterCellsType == SelectionShape.Column)
                queryText.AppendFormat("{0} IN ({1})", filterCells.First().ColumnName.ForQueries(),
                    string.Join(", ", filterCells.Select(f => f.SqlFormattedValue).ToArray()));
            else if (filterCellsType == SelectionShape.Row)
                queryText.AppendFormat("({0})",
                    string.Join(" AND ",
                        filterCells.Select(f =>
                            $"{f.ColumnName.ForQueries()} = {f.SqlFormattedValue}").ToArray()));
            else
                queryText.Append("1 = 0");

            return queryText.ToString();
        }

        public static string BuildDeleteQuery(this TableDefinition table)
        {
            return string.Format("DELETE FROM {0}\t{1}{0}WHERE{0}\t{2}", Environment.NewLine, table.Name.ForQueries(),
                GetWhereClause(table));
        }

        public static string BuildGrantExecuteOnSP(string spName, string userName = "xxx")
        {
            return string.Format("GRANT EXECUTE {0}ON {1} {0}TO {2}", Environment.NewLine, spName, userName);
        }

        public static bool IsCrudQuery(string queryText)
        {
            return QueryStartsWithKeyword(queryText, "INSERT", "SELECT", "UPDATE", "DELETE");
        }

        public static bool IsQueryReturningResults(string queryText)
        {
            return 
                QueryStartsWithKeyword(queryText, "SELECT")
                || QueryContainsKeyword(queryText, CustomQueryDirectives.ShowExecutedQueryResults);
        }

        public static bool IsDestroyQuery(string queryText)
        {
            return QueryStartsWithKeyword(queryText, "UPDATE", "DELETE");
        }

        public static bool IsStructureAlteringQuery(string queryText)
        {
            return QueryStartsWithKeyword(queryText, "ALTER", "DROP");
        }

        private static bool QueryStartsWithKeyword(string queryText, params string[] keywords)
        {
            return keywords.Any(s => (queryText ?? "").ToUpper().TrimStart().StartsWith(s.ToUpper()));
        }

        private static bool QueryContainsKeyword(string queryText, params string[] keywords)
        {
            return keywords.Any(s => (queryText ?? "").ToUpper().TrimStart().Contains(s.ToUpper()));
        }

        private static string GetWhereClause(TableDefinition table)
        {
            if (table.IdentityColumn != null) return $"{table.IdentityColumn.Name.ForQueries()} = ?";

            return "?";
        }

        public static class SystemQueries
        {
            public static string GetDatabaseList()
            {
                return "SELECT name FROM sys.databases WHERE name NOT IN (\'master\', \'tempdb\', \'model\', \'msdb\')";
            }

            public static string GetTableListWithRowCounts()
            {
                return string.Format(
                    "SELECT DISTINCT{0}\ts.name \"Schema\",{0}\tt.name \"Table\",{0}\tt.object_id \"Id\",{0}\tp.rows \"Rows\"{0}FROM {0}\tsys.tables t{0}INNER JOIN{0}\tsys.schemas s ON (t.schema_id = s.schema_id){0}INNER JOIN{0}\tsys.partitions p ON (t.object_id = p.object_id AND p.index_id < 2){0}WHERE{0}\tt.is_ms_shipped = 0{0}",
                    Environment.NewLine);
            }

            public static string GetStoredProcList()
            {
                return
                    "SELECT so.name, sc.text FROM sysobjects so JOIN syscomments sc ON (sc.id = so.id) WHERE so.type ='P' AND so.category = 0 ORDER BY so.name, sc.colid";
            }

            public static string GetViewList()
            {
                return @"
                    SELECT 
                        o.name, 
                        COALESCE(m.definition, '') AS definiton 
                    FROM 
                        sys.objects o 
                    LEFT JOIN 
                        sys.sql_modules m ON (m.object_id = o.object_id) 
                    WHERE 
                        o.type = 'V'
                    ORDER BY 
                        o.name";
            }

            public static string FindColumns()
            {
                return string.Format(
                    "SELECT {0}\ttables.name \"Table\", {0}\tcolumns.name \"Column\", {0}\tstype.name + ' (' + CAST(columns.length AS VARCHAR) + ')' \"Column definition\"{0}FROM {0}\tsysobjects tables {0}JOIN{0}\tsyscolumns columns ON (tables.id = columns.id) {0}JOIN {0}\tsystypes stype ON (columns.xtype = stype.xusertype){0}WHERE {0}\ttables.xtype = 'U' {0}\tAND tables.name NOT LIKE 'sys%' {0}\tAND columns.name LIKE @SearchString {0}ORDER BY {0}\ttables.name{0}",
                    Environment.NewLine);
            }
        }
    }
}