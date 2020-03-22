using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CapaSeguridad.Criptografia
{
    public class EncriptarHash
    {
        //string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

        public string EncriptarStringHash(string value, string llave, string iv)
        {
            //CryptographyManager s = new CryptographyManager();
            //return s.Encrypt(value);

            //UTF8Encoding encoder = new UTF8Encoding();
            //SHA256Managed sha256hasher = new SHA256Managed();
            //byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(value));
            //return Convert.ToBase64String(hashedDataBytes);
            return EncryptKey(value,llave);
        }



        private string EncryptKey(string cadena,string llave)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(cadena);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(llave));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();


            return Convert.ToBase64String(ArrayResultado,
                   0, ArrayResultado.Length);



        }


    }
}
