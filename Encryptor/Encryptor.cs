﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class Encryptor : Form
    {
        public Encryptor()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtDecryptedText.Text.Trim() != "")//EncryptedText
            {
                //Encrypt to str and add it to app.config
                byte[] enc = myCryptographyFunctions.EncryptStringToBytes_Aes(txtDecryptedText.Text);
                string str = BitConverter.ToString(enc).Replace("-", string.Empty);

                txtEncryptedText.Text = str;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtEncryptedText.Text.Trim() != "")//EncryptedText
            {
                //string to byte[]
                byte[] encrypted = myCryptographyFunctions.StringToByteArray(txtEncryptedText.Text);

                txtDecryptedText.Text = myCryptographyFunctions.DecryptStringFromBytes_Aes(encrypted); ;
            }
        }
    }

    public class myCryptographyFunctions
    {
        public static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes("myKeymyKeymyKey!");
            byte[] IV = System.Text.Encoding.Unicode.GetBytes("myIVmyIV");

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            byte[] Key = System.Text.Encoding.Unicode.GetBytes("myKeymyKeymyKey!");
            byte[] IV = System.Text.Encoding.Unicode.GetBytes("myIVmyIV");

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

    }
}
