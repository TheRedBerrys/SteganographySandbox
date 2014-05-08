using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SteganographySandbox
{
    /// <summary>
    /// A class that hides and retrieves secret messages from Bitmap objects.
    /// The class is non-static because steganography is easier to manage with saved state.
    /// The class only publicizes static methods, because it is easier (and more natural) to hide and retrieve messages without instantiating an instance of a class to do so.
    /// </summary>
    public class Steganography
    {
        // The instance implementation handles the actual work of hiding and retrieving messages, and its members are not available to other classes.
        #region Instance Implementation

        /// <summary>
        /// The Bitmap this instance is working with.
        /// </summary>
        Bitmap image;
        /// <summary>
        /// The current x and y locations in the Bitmap the instance is working on; the maximum x and y locations of pixels in the Bitmap.
        /// </summary>
        int x, y, maxX, maxY;
        /// <summary>
        /// The key that comes before and after the bytes of the actual hidden message. 
        /// The presence of the key signals the presence of a hidden message, as well as the end of such a message
        /// </summary>
        byte[] key;

        /// <summary>
        /// Creates a new instance of the Steganography class with a given image to use in hiding and retrieving messages.
        /// </summary>
        /// <param name="image">The image to use in hiding and retrieving messages.</param>
        private Steganography(Bitmap image)
        {
            // Copying the bitmap to a new one ensures we don't have problems when saving the file.
            this.image = new Bitmap(image);

            this.x = 0;
            this.y = 0;
            this.maxX = image.Width - 1;
            this.maxY = image.Height - 1;

            // Currently, we just get the last key in the key history file. We could easily pick a key to use in any number of other ways.
            key = KeyManager.GetLastKey();
        }

        /// <summary>
        /// Given a byte array to hide in the current Bitmap, returns that Bitmap with the byte array hidden inside.
        /// </summary>
        /// <param name="bytes">The byte array to hide inside the current Bitmap.</param>
        /// <returns>The current Bitmap, with the given byte array hidden inside.</returns>
        private Bitmap ImageWithHiddenMessage(byte[] bytes)
        {
            HideBytes(bytes, false);
            return image;
        }

        /// <summary>
        /// Given a byte array, returns that byte array with the key before and after that array.
        /// </summary>
        /// <param name="original">The byte array to place between the key.</param>
        /// <returns>The given byte array, with the key both before and after the given bytes.</returns>
        private byte[] BytesWithKey(byte[] original)
        {
            List<byte> byteList = key.ToList();
            byteList.AddRange(original);
            byteList.AddRange(key);

            return byteList.ToArray();
        }

        /// <summary>
        /// Hides a given byte array inside the current Bitmap.
        /// </summary>
        /// <param name="bytes">The byte array to hide in the current Bitmap.</param>
        /// <param name="alreadyHasKey">Whether the given byte array already has the key at the beginning and end. Defaults to false.</param>
        private void HideBytes(byte[] bytes, bool alreadyHasKey = false)
        {
            // If the byte array doesn't already have the key, put the key in the bytes.
            if (!alreadyHasKey)
                bytes = BytesWithKey(bytes);

            // Convert the bytes into bits and hide those bits.
            BitArray bits = new BitArray(bytes);
            HideBits(bits);
        }

        /// <summary>
        /// Given a BitArray, hides that BitArray in the current Bitmap.
        /// </summary>
        /// <param name="bits">The BitArray to hide in the current Bitmap.</param>
        private void HideBits(BitArray bits)
        {
            // For each bit in the array, simply hide that bit in the next pixel.
            for (int i = 0; i < bits.Length; i++)
            {
                ProcessPixel(bits[i]);
                NextPixel();
            }
        }

        /// <summary>
        /// "Processes" a pixel by changing the color to represent a bit.
        /// The pixel has an "on" bit if the least significant bit of its blue value is on, and vice versa.
        /// </summary>
        /// <param name="bit">The bit that the pixel should reflect.</param>
        private void ProcessPixel(bool bit)
        {
            Color color = image.GetPixel(x, y);
            byte currB = color.B;

            // The pixel is "on" if the blue value is not divisible by 2; i.e. if its least significant bit is on.
            bool currOn = currB % 2 == 1;
            
            // If the current pixel does not encode to the correct bit value, change it so that it does.
            if (currOn != bit)
            {
                int argb = color.ToArgb();

                // Always change the blue value to go towards the half-way point (we avoid going out of range this way).
                if (currB < 128)
                    argb++;
                else
                    argb--;

                Color newColor = Color.FromArgb(argb);
                image.SetPixel(x, y, newColor);
            }
        }

        /// <summary>
        /// Returns the byte array hidden inside the current Bitmap, if any.
        /// </summary>
        /// <returns>The byte array hidden inside the current Bitmap. If no byte array is hidden, returns null.</returns>
        private byte[] HiddenBytes()
        {
            try
            {
                List<byte> bytes = new List<byte>();

                // Get the first n bytes in the picture, where n is the number of bytes in the key.
                for (int i = 0; i < key.Length; i++)
                    bytes.Add(NextByte());

                // Check for the presence of the key.
                if (EndsWithKey(bytes))
                    bytes = new List<byte>(); // Remove the starting key.
                else
                    return null; // If the key isn't found at the beginning of the picture, there's no hidden message.

                // Until we've found the entire key to end the hidden bytes, keep adding the next byte.
                while (!EndsWithKey(bytes))
                    bytes.Add(NextByte());

                // Return the byte array, but don't include the ending key.
                return bytes.Take(bytes.Count - key.Length).ToArray();
            }
            catch // If the key is found at the start of the picture, but no key is found to end the search (this will probably never happen but is possible).
            {
                return null;
            }
        }

        /// <summary>
        /// Given a List of bytes, determines whether that list of bytes ends with the current key.
        /// </summary>
        /// <param name="message">The List of bytes to check for ending with the current key.</param>
        /// <returns>True if the given List of bytes ends with the current key, false otherwise.</returns>
        private bool EndsWithKey(List<byte> message)
        {
            // The message can't end with the key if it is shorter than the key.
            if (message.Count < key.Length)
                return false;

            int offset = message.Count - key.Length;

            // Check each byte of the key, seeing if it is found at the proper place in the message.
            for (int i = 0; i < key.Length; i++)
                if (message[offset + i] != key[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Gets the next byte from the current Bitmap, by decoding the next 8 pixels.
        /// </summary>
        /// <returns>A byte created by decoding the next 8 pixels.</returns>
        private byte NextByte()
        {
            // We have to use a byte array rather than a single byte because the BitArray.CopyTo() method requires it.
            byte[] answer = new byte[1];
            BitArray bits = new BitArray(8);

            // Simply grab each bit from the next 8 pixels.
            for (int i = 0; i < 8; i++)
            {
                bits[i] = BoolFromNextPixel();
                NextPixel();
            }

            bits.CopyTo(answer, 0);

            return answer[0];
        }

        /// <summary>
        /// Returns the decoded value of the next pixel (i.e. the pixel with location at the current x and y values).
        /// </summary>
        /// <returns>The decoded value of the next pixel.</returns>
        private bool BoolFromNextPixel()
        {
            Color color = image.GetPixel(x, y);
            byte currB = color.B;

            // The pixel is "on" if the least significant bit of its blue value is on.
            return currB % 2 == 1;
        }

        /// <summary>
        /// Moves to the next pixel to process.
        /// </summary>
        private void NextPixel()
        {
            if (x < maxX)
            {
                x++;
            }
            else
            {
                x = 0;
                y++;
            }
        }

        #endregion Instance Implementation

        // Only the static methods are accessible, making the steganography interface easy to interact with.
        #region Static

        /// <summary>
        /// Given an image, returns the string hidden in the image, if any.
        /// </summary>
        /// <param name="image">The image from which to find a hidden string.</param>
        /// <returns>The string hidden in the image. If no string is hidden in the image, returns null.</returns>
        public static string HiddenMessage(Bitmap image)
        {
            byte[] bytes = HiddenBytes(image);
            return ByteEncoder.StringFromBytes(bytes);
        }

        /// <summary>
        /// Given an image and a string message to hide in it, returns the image with the message hidden inside.
        /// </summary>
        /// <param name="image">The image in which to hide the given string.</param>
        /// <param name="message">The string to hide in the image.</param>
        /// <returns>The image with the string hidden inside.</returns>
        public static Bitmap ImageWithHiddenMessage(Bitmap image, string message)
        {
            byte[] bytes = ByteEncoder.BytesFromString(message);
            return ImageWithHiddenMessage(image, bytes);
        }

        /// <summary>
        /// Saves the byte array hidden in an image, saves that byte array to a file, and returns the file path for that file.
        /// </summary>
        /// <param name="image">The image from which to find the hidden bytes.</param>
        /// <param name="path">The desired path to save the new file to.</param>
        /// <returns>The file path of the file in which the hidden bytes were saved.</returns>
        public static string FilePathForHiddenFile(Bitmap image, string path)
        {
            byte[] bytes = HiddenBytes(image);
            return ByteEncoder.FilePathFromBytes(bytes, path);
        }
        
        /// <summary>
        /// Given an image and a file path, hides the bytes from that file in the image.
        /// </summary>
        /// <param name="image">The image in which to hide the file.</param>
        /// <param name="path">The file path of the file to hide in the image.</param>
        /// <returns>The image with the file hidden inside.</returns>
        public static Bitmap ImageWithHiddenFile(Bitmap image, string path)
        {
            byte[] bytes = ByteEncoder.BytesFromFile(path);
            return ImageWithHiddenMessage(image, bytes);
        }

        #endregion Static

        // The private static methods interact with the instance implementation on a byte array level, and are not available to other classes.
        #region Private Static

        /// <summary>
        /// Given a Bitmap and a byte array, returns the Bitmap with the byte array hidden inside.
        /// </summary>
        /// <param name="image">The image in which to hide the byte array.</param>
        /// <param name="bytes">The byte array to hide in the image.</param>
        /// <returns>The given image with the given byte array hidden inside.</returns>
        private static Bitmap ImageWithHiddenMessage(Bitmap image, byte[] bytes)
        {
            Steganography steg = new Steganography(image);
            return steg.ImageWithHiddenMessage(bytes);
        }

        /// <summary>
        /// Given an image, returns the byte array hidden inside, if any.
        /// </summary>
        /// <param name="image">The image from which to find a hidden byte array.</param>
        /// <returns>The byte array hidden inside the image. If no byte array is found hidden in the image, returns null.</returns>
        private static byte[] HiddenBytes(Bitmap image)
        {
            Steganography steg = new Steganography(image);
            return steg.HiddenBytes();
        }

        #endregion Private Static
    }
}
