using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace ShareBook.Models
{
    public class EncryptionDecryption
    {
        private static readonly byte[] initvectors = Encoding.ASCII.GetBytes("tu89geji340t89u2");
        private const int keysize = 256;

        public static string Encrypt(string plaintext, string passpharse)
        {


            byte[] plaintextbytes = Encoding.UTF8.GetBytes(plaintext);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passpharse, null);
            byte[] keybytes = password.GetBytes(keysize / 8);
            RijndaelManaged symetrykey = new RijndaelManaged();
            symetrykey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symetrykey.CreateEncryptor(keybytes, initvectors);
            MemoryStream memorystream = new MemoryStream();

            CryptoStream crypto = new CryptoStream(memorystream, encryptor, CryptoStreamMode.Write);
            crypto.Write(plaintextbytes, 0, plaintextbytes.Length);
            crypto.FlushFinalBlock();
            byte[] cypertextbytes = memorystream.ToArray();
            return Convert.ToBase64String(cypertextbytes);
        }
        public static string Decrypt(string cyphertext, string passpharse)
        {
            string repcyphertext = cyphertext.Replace(" ", "+");

            byte[] cipertext = Convert.FromBase64String(repcyphertext);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passpharse, null);
            byte[] keybytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetrykey = new RijndaelManaged();
            symmetrykey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetrykey.CreateDecryptor(keybytes, initvectors);
            MemoryStream memorystream = new MemoryStream(cipertext);
            CryptoStream crypto = new CryptoStream(memorystream, decryptor, CryptoStreamMode.Read);
            byte[] plaintextbytes = new byte[cyphertext.Length];
            int decrypedtbyte = crypto.Read(plaintextbytes, 0, plaintextbytes.Length);

            return Encoding.UTF8.GetString(plaintextbytes, 0, decrypedtbyte);
        }
    }
}