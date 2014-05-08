using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;

namespace SteganographySandbox
{
    public partial class Form1 : Form
    {
        // A bunch of fields for keeping track of stuff. These should probably be in options or something.
        string originalFolder = @"Original\";
        string messagesFolder = @"Message\";

        string fileName;
        string path;

        string originalFilePath;
        string messageFilePath;

        Bitmap originalImage;
        Bitmap messageImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            fileName = txtFileName.Text;

            path = txtFilePath.Text;
            if (!path.EndsWith(@"\"))
                path += @"\";

            LoadImages();
        }

        /// <summary>
        /// Loads the original picture and the picture with the message.
        /// </summary>
        private void LoadImages()
        {
            originalFilePath = path + originalFolder + fileName;
            messageFilePath = path + messagesFolder + fileName;

            if (File.Exists(originalFilePath))
                originalImage = GetImage(originalFilePath);
            else
                originalImage = null;

            if (File.Exists(messageFilePath))
                messageImage = GetImage(messageFilePath);
            else
                messageImage = null;

            picOriginal.Image = originalImage;
            picMessage.Image = messageImage;

            txtMessageToHide.Text = "";
            txtHiddenMessage.Text = "";
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                txtMessageToHide.Text = "No image loaded yet.";
            }
            else
            {
                string message = txtMessageToHide.Text;
                messageImage = Steganography.ImageWithHiddenMessage(originalImage, txtMessageToHide.Text);

                messageImage.Save(messageFilePath);

                LoadImages();
            }
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            if (messageImage == null)
            {
                txtHiddenMessage.Text = "No image loaded.";
            }
            else
            {
                string message = Steganography.HiddenMessage(messageImage);
                txtHiddenMessage.Text = message == null ? "No message found." : message;
            }
        }

        /// <summary>
        /// Gets the image in a given file path.
        /// </summary>
        /// <param name="filePath">The path from which to get the file.</param>
        /// <returns>The image in the file.</returns>
        private Bitmap GetImage(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return (Bitmap)Bitmap.FromStream(stream);
            }
        }

        private void buttonHideFile_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                txtMessageToHide.Text = "No image loaded yet.";
            }
            else
            {
                string message = txtMessageToHide.Text;
                messageImage = Steganography.ImageWithHiddenFile(originalImage, txtFileRead.Text);

                messageImage.Save(messageFilePath);

                LoadImages();
            }
        }

        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            if (messageImage == null)
            {
                txtHiddenMessage.Text = "No image loaded.";
            }
            else
            {
                string hiddenFilePath = Steganography.FilePathForHiddenFile(messageImage, txtSaveFile.Text);
                txtHiddenMessage.Text = string.Format("Hidden message saved to {0}.", hiddenFilePath);
            }
        }
    }
}
