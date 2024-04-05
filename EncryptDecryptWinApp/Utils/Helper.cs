using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecryptWinApp.Utils
{
    public static class Helper
    {
        // Define constants for encryption parameters
        const int SaltSize = 16;        // 16 bytes for salt
        const int KeyIterations = 100000; // Number of iterations for key derivation
        const int KeySize = 256;       // Key size in bits (128, 192, or 256)
        const int IVSize = 128;         // 16 bytes for initialization vector
        const int IVIterations = 10000; // Number of iterations for IV derivation

        public static string Encrypt(string plainText, string passPhraseKey)
        {
            try
            {
                // Generate a random salt
                byte[] salt = GenerateRandomSalt();

                // Derive a key and IV from the passphrase and salt
                byte[] key = GenerateKey(passPhraseKey, salt);
                byte[] iv = GenerateIV(passPhraseKey, salt);

                // Create a new AES object with the specified key and IV
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Padding = PaddingMode.PKCS7;

                    // Create a new encryptor
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Create a memory stream to hold the encrypted data
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText);
                            }
                        }

                        // Append the salt to the encrypted data
                        byte[] encryptedData = ms.ToArray();
                        byte[] combinedData = new byte[encryptedData.Length + salt.Length];
                        encryptedData.CopyTo(combinedData, 0);
                        salt.CopyTo(combinedData, encryptedData.Length);

                        string base64String = Convert.ToBase64String(combinedData);

                        return base64String;
                    }
                }
            }
            catch (CryptographicException ex)
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string base64EncryptedText, string passPhraseKey)
        {
            try
            {
                byte[] cipherText = Convert.FromBase64String(base64EncryptedText);

                // Extract the salt from the cipherText
                byte[] salt = cipherText.Skip(cipherText.Length - SaltSize).ToArray();
                byte[] encryptedData = cipherText.Take(cipherText.Length - SaltSize).ToArray();

                // Derive a key and IV from the passphrase and salt
                byte[] key = GenerateKey(passPhraseKey, salt);
                byte[] iv = GenerateIV(passPhraseKey, salt);

                // Create a new AES object with the specified key and IV
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Padding = PaddingMode.PKCS7;

                    // Create a new decryptor
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Create a memory stream to hold the decrypted data
                    using (MemoryStream ms = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private static byte[] GenerateRandomSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private static byte[] GenerateKey(string passPhraseKey, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passPhraseKey, salt, KeyIterations);
            return pbkdf2.GetBytes(KeySize / 8);
        }

        private static byte[] GenerateIV(string passPhraseKey, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passPhraseKey, salt, IVIterations);
            return pbkdf2.GetBytes(IVSize / 8);
        }

        public static string ConvertToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
