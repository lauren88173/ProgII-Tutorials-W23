using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

public class Encryption : MonoBehaviour
{
    

    
   public static string EncryptSave(string saveText, string password)
 {
     //using try makes it so that the game doesnt crash if it is unable to perform what is being asked
     try
     {//privateKey = passCode, privateKeyByte = passCodeByte, keyByte = codeByte
         //A key for reading and writing the encrypted data
         string passCode = "sdfhrtj";
         byte[] passCodeByte = { };
         passCodeByte = Encoding.UTF8.GetBytes(passCode);
         byte[] _codeByte = { };
         _codeByte = Encoding.UTF8.GetBytes(password);
         byte[] inputStringByteArray = Encoding.UTF8.GetBytes(saveText);
         using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
         {
             var memoryStream = new MemoryStream();
             var cryptoStream = new CryptoStream(memoryStream, dsp.CreateEncryptor(_codeByte, passCodeByte), CryptoStreamMode.Write);
             cryptoStream.Write(inputStringByteArray, 0, inputStringByteArray.Length);
             cryptoStream.FlushFinalBlock();
             return Convert.ToBase64String(memoryStream.ToArray());
         }
     }
        catch (Exception ex)
        {
            return ex.Message;
        }
 }
    public static string DecryptSave(string encryptedText, string password)
    {
        try
        {
            string passCode = "sdfhrtj";
            byte[] passCodeByte = { };
            passCodeByte = Encoding.UTF8.GetBytes(passCode);
            byte[] _codeByte = { };
            _codeByte = Encoding.UTF8.GetBytes(password);
            byte[] inputStringByteArray = System.Convert.FromBase64String(encryptedText.Replace("", "+"));
            using (DESCryptoServiceProvider dEsp = new DESCryptoServiceProvider())
            {
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, dEsp.CreateDecryptor(_codeByte, passCodeByte), CryptoStreamMode.Write);
                cryptoStream.Write(inputStringByteArray, 0, inputStringByteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }
    }
