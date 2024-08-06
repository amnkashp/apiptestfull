using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using APITEST.Models.V1.Request;
using APITEST.Models.V1.Responce;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace APITEST.Utility.V1
{
    public class TestUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public TestUtility()
        {
            obj = new DBActivity();
        }

        public string checkUserLogin(reqLogin req)
        {
            string EncrypPassword = "|@|" + encryptstring(req.Password);

            param = new SqlParameter[]
            {
                new SqlParameter("@Username", req.Username),
                new SqlParameter("@Password",req.Password),
                 new SqlParameter("@EncrypPassword", EncrypPassword)
                //new SqlParameter("@RegionId",Convert.ToInt32(req.RegionID))
            };
            return obj.Return_ScalerValue("sp_WebLogin", param);
        }

        public static string encryptstring(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
    }
}