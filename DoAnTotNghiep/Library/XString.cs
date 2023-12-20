using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Library
{
    public static class XString
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static string Str_Slug(string s)
        {
            String[][] symbols =
            {
                new String[] { "[áàảãạăắằẳẵặâấầẩẫậ]", "a" },
                new String[] { "[đ]", "d" },
                new String[] { "[éèẽẻẹêếềễểệ]", "e" },
                new String[] { "[íìĩỉị]", "i" },
                new String[] { "[óòõỏọôồốổỗộơờớởỡợ]", "o" },
                new String[] { "[úùũủụưừứửữự]", "u" },
                new String[] { "[ýỳỹỷỵ]", "y" },
                new String[] { "[\\s'\";']", "-" }
            };
            s = s.ToLower();
            foreach (var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
            return s;
        }
    }
}