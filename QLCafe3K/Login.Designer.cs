namespace QLCafe3K
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnExit = new Button();
            btnLogin = new Button();
            panel3 = new Panel();
            txtPassWord = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txtUserName = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(28, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 273);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(402, 194);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(141, 58);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(49, 194);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(141, 58);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPassWord);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(20, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(565, 78);
            panel3.TabIndex = 1;
            // 
            // txtPassWord
            // 
            txtPassWord.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassWord.Location = new Point(265, 24);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.Size = new Size(274, 43);
            txtPassWord.TabIndex = 2;
            txtPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 24);
            label2.Name = "label2";
            label2.Size = new Size(167, 38);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu : ";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(20, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(565, 78);
            panel2.TabIndex = 0;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(265, 17);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(274, 43);
            txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Size = new Size(227, 38);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập :";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 315);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogin;
        private Panel panel3;
        private Panel panel2;
        private Button btnExit;
        private TextBox txtPassWord;
        private Label label2;
        private TextBox txtUserName;
        private Label label1;
    }
}
