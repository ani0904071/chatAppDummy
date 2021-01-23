using System;

using System.IO;

using System.Security.Cryptography;
using System.Text;

namespace ChatApplication.Helpers
{
    public static class EncryptionHelper
    {
        static string encryptKey = "aXb2uy4z";
        static byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };

        public static string EncryptString(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateEncryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encryption exception: " +ex.Message);
            }
            return Convert.ToBase64String(memStream.ToArray());
        }

        public static string DecryptString(string inputString)
        {
            MemoryStream memStream = null;
            try
            {
                byte[] key = { }; 
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateDecryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Decryption exception: " + ex.Message);
            }

            Encoding encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }
    }
}
