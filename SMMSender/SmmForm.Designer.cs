namespace SMMSender
{
    partial class SmmForm
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
            this.chbTelegram = new System.Windows.Forms.CheckBox();
            this.chbViber = new System.Windows.Forms.CheckBox();
            this.chbFacebook = new System.Windows.Forms.CheckBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.lbText = new System.Windows.Forms.Label();
            this.pbUploadedImage = new System.Windows.Forms.PictureBox();
            this.chbMail = new System.Windows.Forms.CheckBox();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.lbSenderName = new System.Windows.Forms.Label();
            this.lbSenderEmail = new System.Windows.Forms.Label();
            this.lbІSubject = new System.Windows.Forms.Label();
            this.rtbSubject = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUploadedExcelFileSuccess = new System.Windows.Forms.Label();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFromAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbUploadedImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbTelegram
            // 
            this.chbTelegram.AutoSize = true;
            this.chbTelegram.Location = new System.Drawing.Point(81, 440);
            this.chbTelegram.Name = "chbTelegram";
            this.chbTelegram.Size = new System.Drawing.Size(93, 24);
            this.chbTelegram.TabIndex = 0;
            this.chbTelegram.Text = "Telegram";
            this.chbTelegram.UseVisualStyleBackColor = true;
            // 
            // chbViber
            // 
            this.chbViber.AutoSize = true;
            this.chbViber.Location = new System.Drawing.Point(195, 440);
            this.chbViber.Name = "chbViber";
            this.chbViber.Size = new System.Drawing.Size(66, 24);
            this.chbViber.TabIndex = 1;
            this.chbViber.Text = "Viber";
            this.chbViber.UseVisualStyleBackColor = true;
            // 
            // chbFacebook
            // 
            this.chbFacebook.AutoSize = true;
            this.chbFacebook.Location = new System.Drawing.Point(290, 440);
            this.chbFacebook.Name = "chbFacebook";
            this.chbFacebook.Size = new System.Drawing.Size(94, 24);
            this.chbFacebook.TabIndex = 2;
            this.chbFacebook.Text = "Facebook";
            this.chbFacebook.UseVisualStyleBackColor = true;
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(134, 88);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(537, 167);
            this.rtbContent.TabIndex = 4;
            this.rtbContent.Text = "";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(71, 101);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(39, 20);
            this.lbText.TabIndex = 6;
            this.lbText.Text = "Text:";
            // 
            // pbUploadedImage
            // 
            this.pbUploadedImage.Location = new System.Drawing.Point(134, 300);
            this.pbUploadedImage.Name = "pbUploadedImage";
            this.pbUploadedImage.Size = new System.Drawing.Size(537, 112);
            this.pbUploadedImage.TabIndex = 7;
            this.pbUploadedImage.TabStop = false;
            // 
            // chbMail
            // 
            this.chbMail.AutoSize = true;
            this.chbMail.Location = new System.Drawing.Point(419, 440);
            this.chbMail.Name = "chbMail";
            this.chbMail.Size = new System.Drawing.Size(68, 24);
            this.chbMail.TabIndex = 8;
            this.chbMail.Text = "Email";
            this.chbMail.UseVisualStyleBackColor = true;
            this.chbMail.CheckedChanged += new System.EventHandler(this.chbMail_CheckedChanged);
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Location = new System.Drawing.Point(134, 265);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(295, 29);
            this.btnLoadPicture.TabIndex = 9;
            this.btnLoadPicture.Text = "Load Picture";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.btnLoadPicture_Click);
            // 
            // lbSenderName
            // 
            this.lbSenderName.AutoSize = true;
            this.lbSenderName.Location = new System.Drawing.Point(18, 52);
            this.lbSenderName.Name = "lbSenderName";
            this.lbSenderName.Size = new System.Drawing.Size(76, 20);
            this.lbSenderName.TabIndex = 10;
            this.lbSenderName.Text = "My Name:";
            // 
            // lbSenderEmail
            // 
            this.lbSenderEmail.AutoSize = true;
            this.lbSenderEmail.Location = new System.Drawing.Point(18, 10);
            this.lbSenderEmail.Name = "lbSenderEmail";
            this.lbSenderEmail.Size = new System.Drawing.Size(73, 20);
            this.lbSenderEmail.TabIndex = 11;
            this.lbSenderEmail.Text = "My Email:";
            // 
            // lbІSubject
            // 
            this.lbІSubject.AutoSize = true;
            this.lbІSubject.Location = new System.Drawing.Point(12, 204);
            this.lbІSubject.Name = "lbІSubject";
            this.lbІSubject.Size = new System.Drawing.Size(61, 20);
            this.lbІSubject.TabIndex = 13;
            this.lbІSubject.Text = "Subject:";
            // 
            // rtbSubject
            // 
            this.rtbSubject.Location = new System.Drawing.Point(92, 201);
            this.rtbSubject.Name = "rtbSubject";
            this.rtbSubject.Size = new System.Drawing.Size(516, 38);
            this.rtbSubject.TabIndex = 14;
            this.rtbSubject.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.Location = new System.Drawing.Point(0, 866);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(732, 37);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUploadedExcelFileSuccess);
            this.panel1.Controls.Add(this.btnLoadExcel);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtFromAddress);
            this.panel1.Controls.Add(this.lbSenderEmail);
            this.panel1.Controls.Add(this.lbSenderName);
            this.panel1.Controls.Add(this.rtbSubject);
            this.panel1.Controls.Add(this.lbІSubject);
            this.panel1.Location = new System.Drawing.Point(42, 554);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 245);
            this.panel1.TabIndex = 16;
            // 
            // lblUploadedExcelFileSuccess
            // 
            this.lblUploadedExcelFileSuccess.AutoSize = true;
            this.lblUploadedExcelFileSuccess.Location = new System.Drawing.Point(536, 143);
            this.lblUploadedExcelFileSuccess.Name = "lblUploadedExcelFileSuccess";
            this.lblUploadedExcelFileSuccess.Size = new System.Drawing.Size(0, 20);
            this.lblUploadedExcelFileSuccess.TabIndex = 20;
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(99, 139);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(280, 29);
            this.btnLoadExcel.TabIndex = 19;
            this.btnLoadExcel.Text = "Load Contacts";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 87);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Password:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(416, 27);
            this.txtName.TabIndex = 17;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(99, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(416, 27);
            this.txtPassword.TabIndex = 16;
            // 
            // txtFromAddress
            // 
            this.txtFromAddress.Location = new System.Drawing.Point(99, 7);
            this.txtFromAddress.Name = "txtFromAddress";
            this.txtFromAddress.Size = new System.Drawing.Size(416, 27);
            this.txtFromAddress.TabIndex = 15;
            // 
            // SmmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 903);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnLoadPicture);
            this.Controls.Add(this.chbMail);
            this.Controls.Add(this.pbUploadedImage);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.chbFacebook);
            this.Controls.Add(this.chbViber);
            this.Controls.Add(this.chbTelegram);
            this.Name = "SmmForm";
            this.Text = "SmmSender";
            ((System.ComponentModel.ISupportInitialize)(this.pbUploadedImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chbTelegram;
        private CheckBox chbViber;
        private CheckBox chbFacebook;
        private RichTextBox rtbContent;
        private Label lbText;
        private PictureBox pbUploadedImage;
        private Button btnLoadPicture;
        private CheckBox chbMail;
        private Button btnSend;
        private RichTextBox rtbSubject;
        private Label lbІSubject;
        private Label lbSenderEmail;
        private Label lbSenderName;
        private Panel panel1;
        private TextBox txtPassword;
        private TextBox txtFromAddress;
        private Label lblPassword;
        private TextBox txtName;
        private Button btnLoadExcel;
        private Label lblUploadedExcelFileSuccess;
    }
}