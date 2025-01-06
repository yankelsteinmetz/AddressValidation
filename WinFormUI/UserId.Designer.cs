namespace WinFormUI
{
    partial class UserId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserId));
            userIdTextBox = new TextBox();
            Submit = new Button();
            instructions = new Label();
            createAccount = new LinkLabel();
            SuspendLayout();
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(32, 70);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(451, 23);
            userIdTextBox.TabIndex = 0;
            // 
            // Submit
            // 
            Submit.Location = new Point(32, 135);
            Submit.Name = "Submit";
            Submit.Size = new Size(449, 38);
            Submit.TabIndex = 1;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // instructions
            // 
            instructions.AutoSize = true;
            instructions.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructions.Location = new Point(138, 6);
            instructions.Name = "instructions";
            instructions.Size = new Size(230, 30);
            instructions.TabIndex = 2;
            instructions.Text = "Enter your USPS user id";
            // 
            // createAccount
            // 
            createAccount.AutoSize = true;
            createAccount.Location = new Point(197, 43);
            createAccount.Name = "createAccount";
            createAccount.Size = new Size(85, 15);
            createAccount.TabIndex = 3;
            createAccount.TabStop = true;
            createAccount.Text = "create account";
            createAccount.TextAlign = ContentAlignment.TopCenter;
            createAccount.LinkClicked += createAccount_LinkClicked;
            // 
            // UserId
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 200);
            Controls.Add(createAccount);
            Controls.Add(instructions);
            Controls.Add(Submit);
            Controls.Add(userIdTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserId";
            Text = "User Id";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userIdTextBox;
        private Button Submit;
        private Label instructions;
        private LinkLabel createAccount;
    }
}