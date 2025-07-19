namespace KafkaChatApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtChat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChat.Location = new System.Drawing.Point(0, 0);
            this.txtChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(584, 241);
            this.txtChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMessage.Location = new System.Drawing.Point(0, 231);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(584, 30);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "hi";
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.Location = new System.Drawing.Point(0, 261);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(584, 28);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 289);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChat);
            this.Name = "Form1";
            this.Text = "Kafka Chat Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
