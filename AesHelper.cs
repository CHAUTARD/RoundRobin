using System;
using System.Security.Cryptography;
using System.Text;

/*
 * AesHelper.cs
 * 
 * Ce fichier contient la classe AesHelper qui fournit des méthodes pour le chiffrement et le déchiffrement de données à l'aide de 
 * l'algorithme AES (Advanced Encryption Standard).
 * 
 * La classe AesHelper inclut les méthodes suivantes :
 * - Encrypt : Chiffre une chaîne de texte en utilisant une clé et un vecteur d'initialisation (IV) spécifiés.
 * - Decrypt : Déchiffre une chaîne de texte chiffrée en utilisant la même clé et IV que ceux utilisés pour le chiffrement.
 * - GenerateKeyAndIV : Génère une clé et un IV aléatoires pour le chiffrement.
 * 
 * Utilisation :
 * 1. Générer une clé et un IV à l'aide de la méthode GenerateKeyAndIV.
 * 2. Chiffrer une chaîne de texte en appelant la méthode Encrypt avec le texte, la clé et l'IV.
 * 3. Déchiffrer la chaîne chiffrée en appelant la méthode Decrypt avec le texte chiffré, la même clé et IV.
 * 
 * Exemple :
 *      var (key, iv) = AesHelper.GenerateKeyAndIV();
 *
 *      string secret = "Données confidentielles";
 *      string encrypted = AesHelper.Encrypt(secret, key, iv);
 *      string decrypted = AesHelper.Decrypt(encrypted, key, iv);
 *
 *      Console.WriteLine($"Chiffré  : {encrypted}");
 *      Console.WriteLine($"Déchiffré: {decrypted}");
 */

public static class AesHelper
{
    // Chiffrement
    public static string Encrypt(string plainText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var encryptor = aes.CreateEncryptor();
        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Convert.ToBase64String(encrypted);
    }

    // Déchiffrement
    public static string Decrypt(string cipherText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        var decryptor = aes.CreateDecryptor();
        byte[] inputBytes = Convert.FromBase64String(cipherText);
        byte[] decrypted = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Encoding.UTF8.GetString(decrypted);
    }

    // Génération d'une clé et d'un IV aléatoires
    public static (byte[] Key, byte[] IV) GenerateKeyAndIV()
    {
        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();
        return (aes.Key, aes.IV);
    }
}
