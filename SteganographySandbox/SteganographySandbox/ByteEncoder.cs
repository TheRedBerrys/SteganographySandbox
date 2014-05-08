using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SteganographySandbox
{
    /// <summary>
    /// A static class that helps converts byte arrays to useful objects and vice versa.
    /// </summary>
    public static class ByteEncoder
    {
        /// <summary>
        /// Given a string, returns a byte array that represents the string.
        /// </summary>
        /// <param name="input">The string to convert to a byte array.</param>
        /// <returns>A byte array that represents the given string.</returns>
        public static byte[] BytesFromString(string input)
        {
            return input.Select(c => (byte)c).ToArray();
        }

        /// <summary>
        /// Given a byte array, returns the string the byte array represents.
        /// </summary>
        /// <param name="input">The byte array to convert to a string.</param>
        /// <returns>The string created from the byte array. If the input byte array is null, returns null.</returns>
        public static string StringFromBytes(byte[] input)
        {
            if (input == null)
                return null;

            char[] chars = input.Select(b => Convert.ToChar(b)).ToArray();
            return new string(chars);
        }

        /// <summary>
        /// Given a file path, returns the bytes from that file.
        /// </summary>
        /// <param name="path">The file path of the file from which to get the bytes.</param>
        /// <returns>An array containing all the bytes in the file.</returns>
        public static byte[] BytesFromFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Given a byte array and a file path, saves the byte array to the file path and returns the file path saved, including any changes.
        /// </summary>
        /// <param name="input">The byte array to save to a file.</param>
        /// <param name="path">The file path in which to save the bytes.</param>
        /// <returns>The file path to the file in which the bytes were saved.</returns>
        public static string FilePathFromBytes(byte[] input, string path)
        {
            File.WriteAllBytes(path, input);
            return path;
        }
    }
}
