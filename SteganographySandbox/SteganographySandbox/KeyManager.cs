using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SteganographySandbox
{
    /// <summary>
    /// A static class that manages keys to use in steganography.
    /// </summary>
    public static class KeyManager
    {
        /// <summary>
        /// The path of the file that contains the keys.
        /// </summary>
        static string keyPath = "../../key.txt";
        /// <summary>
        /// The length of new keys to create.
        /// </summary>
        static int keyLength = 16;

        /// <summary>
        /// Gets the latest key in the key file. If no keys are present, creates a new key, saves the key in the file, and returns the new key.
        /// </summary>
        /// <returns>The most recent key to use for steganography.</returns>
        public static byte[] GetLastKey()
        {
            string currentKey = File.ReadAllLines(keyPath).LastOrDefault();

            if (string.IsNullOrEmpty(currentKey))
                return NewKey();

            return currentKey.Split(',').Select(c => Convert.ToByte(c)).ToArray();
        }

        /// <summary>
        /// Creates and returns a new random key of the length indicated by the keyLength property.
        /// </summary>
        /// <returns></returns>
        public static byte[] NewKey()
        {
            Random random = new Random();
            byte[] key = new byte[keyLength];
            random.NextBytes(key);

            string keyString = string.Join(",", key);
            File.AppendAllLines(keyPath, new string[] { keyString });

            return key;
        }
    }
}
