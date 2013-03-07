﻿using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace RequestReduce.Utilities
{
    public static class Hasher
    {
        [ThreadStatic]
        private static MD5CryptoServiceProvider md5;
        
        public static Guid Hash(string input)
        {
            return input==null ? Guid.Empty : Hash(Encoding.UTF8.GetBytes(input));
        }

        public static Guid Hash(byte[] bytes)
        {
            if (md5 == null)
                md5 = new MD5CryptoServiceProvider();


            return new Guid(md5.ComputeHash(bytes));
        }
    }
}
