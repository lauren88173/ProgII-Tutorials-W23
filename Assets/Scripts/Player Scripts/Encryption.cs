using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;
using System.Text;

public class Encryption : MonoBehaviour
{
    //A key for reading and writing the encrypted data

    //Creating an AES system
    public static string EncryptSave(string saveText, string password)
    {
        //using try makes it so that the game doesnt crash if it is unable to perform what is being asked
        try
        {//privateKey = passCode, privateKeyByte = passCodeByte, keyByte = codeByte
            string passCode = "3293745";
            byte[] passCodeByte = { };
            passCodeByte = Encoding.UTF8.GetBytes(passCode);
            byte[] _codeByte = { };
            _codeByte = Encoding.UTF8.GetBytes(password);
            byte[] inputStringByteArray = Encoding.UTF8.GetBytes(saveText);
            using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();\
                var cryptoStream = new CryptoStream(memoryStream, dsp.CreateEncryptor()
            }


        }
    }
    public static string DecryptSave()
    {

    }
}
