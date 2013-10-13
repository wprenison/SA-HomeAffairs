namespace MainGUI
{
    partial class frmNewUserGUI
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
            this.lblFName = new System.Windows.Forms.Label();
            this.txtbFirstNames = new System.Windows.Forms.TextBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.txtbLastName = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtbAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.txtbAddressLine2 = new System.Windows.Forms.TextBox();
            this.txtbAddressLine3 = new System.Windows.Forms.TextBox();
            this.txtbUserName = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.llblPassword = new System.Windows.Forms.LinkLabel();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.txtbConfirmPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(7, 13);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(65, 13);
            this.lblFName.TabIndex = 0;
            this.lblFName.Text = "First Names:";
            // 
            // txtbFirstNames
            // 
            this.txtbFirstNames.Location = new System.Drawing.Point(111, 10);
            this.txtbFirstNames.Name = "txtbFirstNames";
            this.txtbFirstNames.Size = new System.Drawing.Size(213, 20);
            this.txtbFirstNames.TabIndex = 0;
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(7, 39);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(61, 13);
            this.lblLName.TabIndex = 2;
            this.lblLName.Text = "Last Name:";
            // 
            // txtbLastName
            // 
            this.txtbLastName.Location = new System.Drawing.Point(110, 36);
            this.txtbLastName.Name = "txtbLastName";
            this.txtbLastName.Size = new System.Drawing.Size(213, 20);
            this.txtbLastName.TabIndex = 1;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(8, 66);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(71, 13);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Date Of Birth:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(110, 62);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(213, 20);
            this.dtpDateOfBirth.TabIndex = 2;
            // 
            // txtbAddressLine1
            // 
            this.txtbAddressLine1.Location = new System.Drawing.Point(110, 88);
            this.txtbAddressLine1.Name = "txtbAddressLine1";
            this.txtbAddressLine1.Size = new System.Drawing.Size(213, 20);
            this.txtbAddressLine1.TabIndex = 3;
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.AutoSize = true;
            this.lblAddressLine1.Location = new System.Drawing.Point(8, 91);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(48, 13);
            this.lblAddressLine1.TabIndex = 8;
            this.lblAddressLine1.Text = "Address:";
            // 
            // txtbAddressLine2
            // 
            this.txtbAddressLine2.Location = new System.Drawing.Point(110, 114);
            this.txtbAddressLine2.Name = "txtbAddressLine2";
            this.txtbAddressLine2.Size = new System.Drawing.Size(213, 20);
            this.txtbAddressLine2.TabIndex = 4;
            // 
            // txtbAddressLine3
            // 
            this.txtbAddressLine3.Location = new System.Drawing.Point(110, 140);
            this.txtbAddressLine3.Name = "txtbAddressLine3";
            this.txtbAddressLine3.Size = new System.Drawing.Size(213, 20);
            this.txtbAddressLine3.TabIndex = 5;
            // 
            // txtbUserName
            // 
            this.txtbUserName.Location = new System.Drawing.Point(110, 166);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.Size = new System.Drawing.Size(213, 20);
            this.txtbUserName.TabIndex = 6;
            // 
            // txtbPassword
            // 
            this.txtbPassword.Location = new System.Drawing.Point(110, 192);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(213, 20);
            this.txtbPassword.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(7, 169);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 13;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(8, 195);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password:";
            // 
            // llblPassword
            // 
            this.llblPassword.AutoSize = true;
            this.llblPassword.Location = new System.Drawing.Point(119, 252);
            this.llblPassword.Name = "llblPassword";
            this.llblPassword.Size = new System.Drawing.Size(111, 13);
            this.llblPassword.TabIndex = 9;
            this.llblPassword.TabStop = true;
            this.llblPassword.Text = "Password Restrictions";
            this.llblPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPassword_LinkClicked);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(236, 247);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblPasswordConfirm
            // 
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.Location = new System.Drawing.Point(8, 221);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(94, 13);
            this.lblPasswordConfirm.TabIndex = 18;
            this.lblPasswordConfirm.Text = "Confirm Password:";
            // 
            // txtbConfirmPassword
            // 
            this.txtbConfirmPassword.Location = new System.Drawing.Point(110, 218);
            this.txtbConfirmPassword.Name = "txtbConfirmPassword";
            this.txtbConfirmPassword.PasswordChar = '*';
            this.txtbConfirmPassword.Size = new System.Drawing.Size(213, 20);
            this.txtbConfirmPassword.TabIndex = 8;
            // 
            // frmNewUserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 279);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.txtbConfirmPassword);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.llblPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbUserName);
            this.Controls.Add(this.txtbAddressLine3);
            this.Controls.Add(this.txtbAddressLine2);
            this.Controls.Add(this.lblAddressLine1);
            this.Controls.Add(this.txtbAddressLine1);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtbLastName);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.txtbFirstNames);
            this.Controls.Add(this.lblFName);
            this.Name = "frmNewUserGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox txtbFirstNames;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.TextBox txtbLastName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.TextBox txtbAddressLine1;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.TextBox txtbAddressLine2;
        private System.Windows.Forms.TextBox txtbAddressLine3;
        private System.Windows.Forms.TextBox txtbUserName;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.LinkLabel llblPassword;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblPasswordConfirm;
        private System.Windows.Forms.TextBox txtbConfirmPassword;
    }
}