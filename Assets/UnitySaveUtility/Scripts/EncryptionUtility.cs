using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace Platinio.Encryption
{
    public class EncryptionUtility
    {
        private const string ENCRYPTION_KEY = ">]hyJc&qJiD~W8QKwRz9XN@w]7";

        public static string Encrypt(string a)
        {
            return Encrypt(a , ENCRYPTION_KEY);
        }

        public static string Encrypt(string a , string encryptionKey)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(a);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                        cs.Close();
                    }
                    a = Convert.ToBase64String(ms.ToArray());
                }
            }

            return a;
        }

        public static string Decrypt(string a)
        {
            return Decrypt(a, ENCRYPTION_KEY);
        }

        public static string Decrypt(string a, string encryptionKey)
        {
            a = a.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(a);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    a = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return a;
        }



    }

}

