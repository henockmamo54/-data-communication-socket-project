namespace Client
{
    partial class Form1
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
            this.txt_conversationHistory = new System.Windows.Forms.TextBox();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_conversationHistory
            // 
            this.txt_conversationHistory.Location = new System.Drawing.Point(13, 13);
            this.txt_conversationHistory.Multiline = true;
            this.txt_conversationHistory.Name = "txt_conversationHistory";
            this.txt_conversationHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_conversationHistory.Size = new System.Drawing.Size(259, 401);
            this.txt_conversationHistory.TabIndex = 0;
            // 
            // txt_message
            // 
            this.txt_message.Location = new System.Drawing.Point(13, 421);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(209, 20);
            this.txt_message.TabIndex = 1;
            this.txt_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_message_KeyDown);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(229, 421);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(43, 20);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 453);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.txt_conversationHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_conversationHistory;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Button btn_send;
    }
}

