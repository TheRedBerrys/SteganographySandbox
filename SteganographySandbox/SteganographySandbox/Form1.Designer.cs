namespace SteganographySandbox
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
            this.labelFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picMessage = new System.Windows.Forms.PictureBox();
            this.labelPictureWithMessage = new System.Windows.Forms.Label();
            this.txtMessageToHide = new System.Windows.Forms.TextBox();
            this.labelMessageToHide = new System.Windows.Forms.Label();
            this.labelHiddenMessage = new System.Windows.Forms.Label();
            this.txtHiddenMessage = new System.Windows.Forms.TextBox();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonGet = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.txtFileRead = new System.Windows.Forms.TextBox();
            this.buttonHideFile = new System.Windows.Forms.Button();
            this.labelSaveFile = new System.Windows.Forms.Label();
            this.txtSaveFile = new System.Windows.Forms.TextBox();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(13, 13);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(57, 13);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(77, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(253, 20);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "Desert.png";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(337, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(20, 44);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(51, 13);
            this.labelFilePath.TabIndex = 3;
            this.labelFilePath.Text = "File Path:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(77, 44);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(253, 20);
            this.txtFilePath.TabIndex = 4;
            this.txtFilePath.Text = "C:\\Users\\Spencer\\Documents\\Visual Studio 2012\\Projects\\SteganographySandbox\\Stega" +
    "nographySandbox\\Images";
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(13, 101);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(81, 13);
            this.labelOriginal.TabIndex = 5;
            this.labelOriginal.Text = "Original Picture:";
            // 
            // picOriginal
            // 
            this.picOriginal.BackColor = System.Drawing.Color.White;
            this.picOriginal.Location = new System.Drawing.Point(16, 118);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(396, 282);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOriginal.TabIndex = 6;
            this.picOriginal.TabStop = false;
            // 
            // picMessage
            // 
            this.picMessage.BackColor = System.Drawing.Color.White;
            this.picMessage.Location = new System.Drawing.Point(419, 118);
            this.picMessage.Name = "picMessage";
            this.picMessage.Size = new System.Drawing.Size(396, 282);
            this.picMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMessage.TabIndex = 7;
            this.picMessage.TabStop = false;
            // 
            // labelPictureWithMessage
            // 
            this.labelPictureWithMessage.AutoSize = true;
            this.labelPictureWithMessage.Location = new System.Drawing.Point(419, 99);
            this.labelPictureWithMessage.Name = "labelPictureWithMessage";
            this.labelPictureWithMessage.Size = new System.Drawing.Size(111, 13);
            this.labelPictureWithMessage.TabIndex = 8;
            this.labelPictureWithMessage.Text = "Picture with Message:";
            // 
            // txtMessageToHide
            // 
            this.txtMessageToHide.Location = new System.Drawing.Point(16, 423);
            this.txtMessageToHide.Multiline = true;
            this.txtMessageToHide.Name = "txtMessageToHide";
            this.txtMessageToHide.Size = new System.Drawing.Size(396, 76);
            this.txtMessageToHide.TabIndex = 9;
            // 
            // labelMessageToHide
            // 
            this.labelMessageToHide.AutoSize = true;
            this.labelMessageToHide.Location = new System.Drawing.Point(16, 407);
            this.labelMessageToHide.Name = "labelMessageToHide";
            this.labelMessageToHide.Size = new System.Drawing.Size(90, 13);
            this.labelMessageToHide.TabIndex = 10;
            this.labelMessageToHide.Text = "Message to Hide:";
            // 
            // labelHiddenMessage
            // 
            this.labelHiddenMessage.AutoSize = true;
            this.labelHiddenMessage.Location = new System.Drawing.Point(419, 407);
            this.labelHiddenMessage.Name = "labelHiddenMessage";
            this.labelHiddenMessage.Size = new System.Drawing.Size(90, 13);
            this.labelHiddenMessage.TabIndex = 11;
            this.labelHiddenMessage.Text = "Hidden Message:";
            // 
            // txtHiddenMessage
            // 
            this.txtHiddenMessage.Location = new System.Drawing.Point(419, 424);
            this.txtHiddenMessage.Multiline = true;
            this.txtHiddenMessage.Name = "txtHiddenMessage";
            this.txtHiddenMessage.Size = new System.Drawing.Size(396, 75);
            this.txtHiddenMessage.TabIndex = 12;
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(16, 506);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(90, 23);
            this.buttonHide.TabIndex = 13;
            this.buttonHide.Text = "Hide Message";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(419, 506);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(90, 23);
            this.buttonGet.TabIndex = 14;
            this.buttonGet.Text = "Get Message";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(13, 551);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(66, 13);
            this.labelFile.TabIndex = 15;
            this.labelFile.Text = "Or use a file:";
            // 
            // txtFileRead
            // 
            this.txtFileRead.Location = new System.Drawing.Point(16, 567);
            this.txtFileRead.Name = "txtFileRead";
            this.txtFileRead.Size = new System.Drawing.Size(396, 20);
            this.txtFileRead.TabIndex = 16;
            this.txtFileRead.Text = "C:\\Users\\Spencer\\Documents\\Visual Studio 2012\\Projects\\SteganographySandbox\\Stega" +
    "nographySandbox\\Input Files\\image2.gif";
            // 
            // buttonHideFile
            // 
            this.buttonHideFile.Location = new System.Drawing.Point(16, 593);
            this.buttonHideFile.Name = "buttonHideFile";
            this.buttonHideFile.Size = new System.Drawing.Size(75, 23);
            this.buttonHideFile.TabIndex = 17;
            this.buttonHideFile.Text = "Hide File";
            this.buttonHideFile.UseVisualStyleBackColor = true;
            this.buttonHideFile.Click += new System.EventHandler(this.buttonHideFile_Click);
            // 
            // labelSaveFile
            // 
            this.labelSaveFile.AutoSize = true;
            this.labelSaveFile.Location = new System.Drawing.Point(419, 550);
            this.labelSaveFile.Name = "labelSaveFile";
            this.labelSaveFile.Size = new System.Drawing.Size(84, 13);
            this.labelSaveFile.TabIndex = 18;
            this.labelSaveFile.Text = "Or save to a file:";
            // 
            // txtSaveFile
            // 
            this.txtSaveFile.Location = new System.Drawing.Point(419, 567);
            this.txtSaveFile.Name = "txtSaveFile";
            this.txtSaveFile.Size = new System.Drawing.Size(396, 20);
            this.txtSaveFile.TabIndex = 19;
            this.txtSaveFile.Text = "C:\\Users\\Spencer\\Documents\\Visual Studio 2012\\Projects\\SteganographySandbox\\Stega" +
    "nographySandbox\\Output Files\\Message.txt";
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Location = new System.Drawing.Point(419, 594);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFile.TabIndex = 20;
            this.buttonSaveFile.Text = "SaveFile";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 637);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.txtSaveFile);
            this.Controls.Add(this.labelSaveFile);
            this.Controls.Add(this.buttonHideFile);
            this.Controls.Add(this.txtFileRead);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.txtHiddenMessage);
            this.Controls.Add(this.labelHiddenMessage);
            this.Controls.Add(this.labelMessageToHide);
            this.Controls.Add(this.txtMessageToHide);
            this.Controls.Add(this.labelPictureWithMessage);
            this.Controls.Add(this.picMessage);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.labelFileName);
            this.MaximumSize = new System.Drawing.Size(850, 675);
            this.MinimumSize = new System.Drawing.Size(850, 675);
            this.Name = "Form1";
            this.Text = "Steganography Sandbox";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picMessage;
        private System.Windows.Forms.Label labelPictureWithMessage;
        private System.Windows.Forms.TextBox txtMessageToHide;
        private System.Windows.Forms.Label labelMessageToHide;
        private System.Windows.Forms.Label labelHiddenMessage;
        private System.Windows.Forms.TextBox txtHiddenMessage;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TextBox txtFileRead;
        private System.Windows.Forms.Button buttonHideFile;
        private System.Windows.Forms.Label labelSaveFile;
        private System.Windows.Forms.TextBox txtSaveFile;
        private System.Windows.Forms.Button buttonSaveFile;
    }
}

