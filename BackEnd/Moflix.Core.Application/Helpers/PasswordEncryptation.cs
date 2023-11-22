﻿using System.Security.Cryptography;
using System.Text;

namespace Moflix.Core.Application.Helpers
{
    public class PasswordEncryptation
    {
        public static string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256_HASH = SHA256.Create())
            {
                byte[] bytes = sha256_HASH.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}