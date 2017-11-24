using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerport
{
 public static class EncodeString
    {

     public static string Encrypt(string inputText)
     {


         //string inputText = textBox1.Text;
         byte[] bytesToEncode = Encoding.Unicode.GetBytes(inputText);
         //string encodedText = Convert.ToBase64String(bytesToEncode);
         return Convert.ToBase64String(bytesToEncode);
     }

     public static string Decrypt(string EncryptedText)

     {

         byte[] decodedBytes = Convert.FromBase64String(EncryptedText);
         //string decodedText = Encoding.Unicode.GetString(decodedBytes);
         return Encoding.Unicode.GetString(decodedBytes);




     
     }



    }
}
