namespace server
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtbox_serverMessage = new System.Windows.Forms.RichTextBox();
            this.txt_conversationHistory = new System.Windows.Forms.TextBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbox_serverMessage
            // 
            this.txtbox_serverMessage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtbox_serverMessage.Enabled = false;
            this.txtbox_serverMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_serverMessage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtbox_serverMessage.Location = new System.Drawing.Point(5, 43);
            this.txtbox_serverMessage.Name = "txtbox_serverMessage";
            this.txtbox_serverMessage.Size = new System.Drawing.Size(267, 67);
            this.txtbox_serverMessage.TabIndex = 1;
            this.txtbox_serverMessage.Text = "";
            // 
            // txt_conversationHistory
            // 
            this.txt_conversationHistory.Location = new System.Drawing.Point(5, 116);
            this.txt_conversationHistory.Multiline = true;
            this.txt_conversationHistory.Name = "txt_conversationHistory";
            this.txt_conversationHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_conversationHistory.Size = new System.Drawing.Size(267, 316);
            this.txt_conversationHistory.TabIndex = 2;
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(5, 439);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(214, 20);
            this.txt_msg.TabIndex = 3;
            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(226, 439);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(46, 23);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 472);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.txt_conversationHistory);
            this.Controls.Add(this.txtbox_serverMessage);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtbox_serverMessage;
        private System.Windows.Forms.TextBox txt_conversationHistory;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button btn_send;
    }
}

