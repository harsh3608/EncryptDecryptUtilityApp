namespace EncryptDecryptWinApp
{
    partial class Form1
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
            label1 = new Label();
            txtRequest = new TextBox();
            txtResponse = new TextBox();
            label2 = new Label();
            btnProcess = new Button();
            rdbEncrypt = new RadioButton();
            rdbDecrypt = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 79);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Request";
            // 
            // txtRequest
            // 
            txtRequest.Location = new Point(15, 97);
            txtRequest.Multiline = true;
            txtRequest.Name = "txtRequest";
            txtRequest.Size = new Size(436, 226);
            txtRequest.TabIndex = 1;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(457, 97);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(427, 226);
            txtResponse.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(457, 79);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Response";
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(368, 340);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(171, 23);
            btnProcess.TabIndex = 4;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // rdbEncrypt
            // 
            rdbEncrypt.AutoSize = true;
            rdbEncrypt.Location = new Point(21, 26);
            rdbEncrypt.Name = "rdbEncrypt";
            rdbEncrypt.Size = new Size(58, 19);
            rdbEncrypt.TabIndex = 5;
            rdbEncrypt.TabStop = true;
            rdbEncrypt.Text = "Ecrypt";
            rdbEncrypt.UseVisualStyleBackColor = true;
            // 
            // rdbDecrypt
            // 
            rdbDecrypt.AutoSize = true;
            rdbDecrypt.Location = new Point(121, 26);
            rdbDecrypt.Name = "rdbDecrypt";
            rdbDecrypt.Size = new Size(66, 19);
            rdbDecrypt.TabIndex = 6;
            rdbDecrypt.TabStop = true;
            rdbDecrypt.Text = "Decrypt";
            rdbDecrypt.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 375);
            Controls.Add(rdbDecrypt);
            Controls.Add(rdbEncrypt);
            Controls.Add(btnProcess);
            Controls.Add(label2);
            Controls.Add(txtResponse);
            Controls.Add(txtRequest);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRequest;
        private TextBox txtResponse;
        private Label label2;
        private Button btnProcess;
        private RadioButton rdbEncrypt;
        private RadioButton rdbDecrypt;
    }
}
