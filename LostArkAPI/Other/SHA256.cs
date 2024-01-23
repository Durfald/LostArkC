using System.Text;

namespace LostArkAPI.Other
{
    public static class SHA256
    {
        public static string sha256_hash(string value)
        {
            using var hash = System.Security.Cryptography.SHA512.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return BitConverter.ToString(byteArray).Replace("-", "").ToLowerInvariant();
        }
        public static string sha3256_hash(string value)
        {
            var hash = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(512);
            var input = Encoding.UTF8.GetBytes(value);
            hash.BlockUpdate(input, 0, input.Length);
            byte[] result = new byte[64];
            hash.DoFinal(result);

            return BitConverter.ToString(result).Replace("-", "").ToLowerInvariant();
        }

    }
}
