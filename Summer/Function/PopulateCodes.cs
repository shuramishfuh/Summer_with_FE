using Summer.Models;
using Summer.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Summer.Function
{
    public class PopulateCodes
    {

        private readonly DataContext _context = new DataContext();


        public static string GetRandomAlphanumericString()
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(6, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            var result = new char[length];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(bytes);
            }
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }


        public string UpdatingCodes()
        {

            string AdminCode = GetRandomAlphanumericString();
            string TutorCode = GetRandomAlphanumericString();
            var Admin = _context.Codes.Find(1);
            var Tutor = _context.Codes.Find(2);
            Admin.code = AdminCode;
            Tutor.code = TutorCode;
            StaticCodes.Admin = AdminCode;
            StaticCodes.Tutor = TutorCode;
            _context.SaveChanges();
            return "ok";
        }

        public void Statics()
        {
            StaticCodes.Admin = _context.Codes.Find(1).code;
            StaticCodes.Tutor = _context.Codes.Find(2).code;
        }
    }
}