﻿namespace SqlQueryTool.Forms
{
	partial class RowCountFilterPrompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMinimumRowCountTitle = new System.Windows.Forms.Label();
            this.txtMinimumRowCount = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMinimumRowCountTitle
            // 
            this.lblMinimumRowCountTitle.AutoSize = true;
            this.lblMinimumRowCountTitle.Location = new System.Drawing.Point(13, 13);
            this.lblMinimumRowCountTitle.Name = "lblMinimumRowCountTitle";
            this.lblMinimumRowCountTitle.Size = new System.Drawing.Size(129, 13);
            this.lblMinimumRowCountTitle.TabIndex = 0;
            this.lblMinimumRowCountTitle.Text = "Número mínimo de linhas:";
            // 
            // txtMinimumRowCount
            // 
            this.txtMinimumRowCount.Location = new System.Drawing.Point(143, 10);
            this.txtMinimumRowCount.Name = "txtMinimumRowCount";
            this.txtMinimumRowCount.Size = new System.Drawing.Size(65, 20);
            this.txtMinimumRowCount.TabIndex = 1;
            this.txtMinimumRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(52, 58);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Confirmar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(133, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RowCountFilterPrompt
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(224, 93);
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtMinimumRowCount);
            this.Controls.Add(this.lblMinimumRowCountTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RowCountFilterPrompt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insira o número mínimo de linhas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMinimumRowCountTitle;
		private System.Windows.Forms.TextBox txtMinimumRowCount;
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
    }
}