using System;
using System.Security.Cryptography;
using System.Text;

namespace Munazara.CrossCutting.General
{
    public static class CryptographyHelper
    {
        public static string Encrypt(string text)
        {
            try
            {
                SHA1CryptoServiceProvider sifre = new SHA1CryptoServiceProvider();

                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                byte[] arySifre = ByteConverter.GetBytes(text);

                byte[] aryHash = sifre.ComputeHash(arySifre);
                return BitConverter.ToString(aryHash);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}