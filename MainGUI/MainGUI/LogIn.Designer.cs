namespace MainGUI
{
    partial class frmLogIn
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
            if (disposing && (components != null))
            {
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
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.mtxtbPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.llblNewUser = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtbUserName
            // 
            this.txtbUserName.Location = new System.Drawing.Point(81, 18);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(157, 20);
            this.txtbUserName.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // mtxtbPassword
            // 
            this.mtxtbPassword.Location = new System.Drawing.Point(81, 45);
            this.mtxtbPassword.Name = "mtxtbPassword";
            this.mtxtbPassword.PasswordChar = '*';
            this.mtxtbPassword.Size = new System.Drawing.Size(157, 20);
            this.mtxtbPassword.TabIndex = 1;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(81, 71);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 2;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // llblNewUser
            // 
            this.llblNewUser.AutoSize = true;
            this.llblNewUser.Location = new System.Drawing.Point(162, 76);
            this.llblNewUser.Name = "llblNewUser";
            this.llblNewUser.Size = new System.Drawing.Size(54, 13);
            this.llblNewUser.TabIndex = 3;
            this.llblNewUser.TabStop = true;
            this.llblNewUser.Text = "New User";
            this.llblNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblNewUser_LinkClicked);
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 118);
            this.Controls.Add(this.llblNewUser);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.mtxtbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtbUserName);
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.MaskedTextBox mtxtbPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.LinkLabel llblNewUser;
    }
}