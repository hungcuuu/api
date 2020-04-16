using CorePush.Google;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Helpers
{
    public class Services 
    {
        public string GetMd5Hash(string input)
        {
            MD5 md5Hash =  MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash( string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void sendMessageAsync()
        {
            using (var fcm = new FcmSender("AAAAANIAdg4:APA91bHMu_e6u-n6LhobVUTHGT5AsGhRmp3y9nQSMTE3VPh-QUbwgX_8w8kA8b3BOT6mfaRRSATsGNqe7_az5clbXvS3j7xKfyuYXB0t6TGtjFlYavNmUi-Hwc2YR9wmgh99mHiv263q", "3523245582"))
            {
                fcm.SendAsync("BMbolvHP5_Rl_XEoxNgVBTV4ZrFUIV4iyssRRQTk60HVWvBH5UaBkplgtZEyjMm_TMa4LfCtfw2jtUZhQBLnPME",
                   new
                   {
                       notification = new
                       {
                           title = "Test",
                           body = "Yeah",

                       },
                   });
            }
        }
    }
}
