namespace SqlQueryTool.Forms
{
    partial class ConnectionSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSettings));
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDatabaseTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.lblUsernameTitle = new System.Windows.Forms.Label();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.selDatabaseName = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.AutoSize = true;
            this.lblServerTitle.Location = new System.Drawing.Point(12, 98);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(95, 13);
            this.lblServerTitle.TabIndex = 0;
            this.lblServerTitle.Text = "Nome do Servidor:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(120, 95);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(174, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "localhost\\shopcontrol92";
            // 
            // lblDatabaseTitle
            // 
            this.lblDatabaseTitle.AutoSize = true;
            this.lblDatabaseTitle.Location = new System.Drawing.Point(12, 124);
            this.lblDatabaseTitle.Name = "lblDatabaseTitle";
            this.lblDatabaseTitle.Size = new System.Drawing.Size(90, 13);
            this.lblDatabaseTitle.TabIndex = 2;
            this.lblDatabaseTitle.Text = "Banco de Dados:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 147);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(174, 20);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "sa";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 173);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(174, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Senha123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(120, 199);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(148, 17);
            this.chkIntegratedSecurity.TabIndex = 6;
            this.chkIntegratedSecurity.Text = "Autenticação do windows";
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChanged);
            // 
            // lblUsernameTitle
            // 
            this.lblUsernameTitle.AutoSize = true;
            this.lblUsernameTitle.Location = new System.Drawing.Point(12, 150);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Size = new System.Drawing.Size(46, 13);
            this.lblUsernameTitle.TabIndex = 7;
            this.lblUsernameTitle.Text = "Usuário:";
            // 
            // lblPasswordTitle
            // 
            this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Location = new System.Drawing.Point(12, 176);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(41, 13);
            this.lblPasswordTitle.TabIndex = 8;
            this.lblPasswordTitle.Text = "Senha:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(138, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "Conectar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // selDatabaseName
            // 
            this.selDatabaseName.FormattingEnabled = true;
            this.selDatabaseName.Location = new System.Drawing.Point(120, 122);
            this.selDatabaseName.Name = "selDatabaseName";
            this.selDatabaseName.Size = new System.Drawing.Size(174, 21);
            this.selDatabaseName.TabIndex = 11;
            this.selDatabaseName.DropDown += new System.EventHandler(this.selDatabaseName_DropDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 83);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // ConnectionSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 277);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selDatabaseName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPasswordTitle);
            this.Controls.Add(this.lblUsernameTitle);
            this.Controls.Add(this.chkIntegratedSecurity);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblDatabaseTitle);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServerTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conectar ao Banco de Dados";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblDatabaseTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.Label lblUsernameTitle;
        private System.Windows.Forms.Label lblPasswordTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ComboBox selDatabaseName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}