using System;
using System.Linq;

namespace RemotePresentationUsingSgnalR.Shared
{
    public class HashIdentifier
    {
        public string Hash { get; }

        private static Random random = new Random();
        private const int RANDOM_STR_LENGTH = 10;

        private static string CreateRandomString(int length)
        {
            //Gerate Random String
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(System.Linq.Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GetStringSha256Hash(string text) =>
            //Using SHA 256 HASH Algorithm
            string.IsNullOrEmpty(text) ? string.Empty : BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty);

        public HashIdentifier()
        {
            string randomStr = CreateRandomString(RANDOM_STR_LENGTH);
            Hash = GetStringSha256Hash(CreateRandomString(RANDOM_STR_LENGTH));
            //Identify = "asd";
        }
    }
}
