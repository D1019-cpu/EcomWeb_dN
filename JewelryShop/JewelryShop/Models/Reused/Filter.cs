using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Convert tieng viet co dau -> khong dau
namespace JewelryShop.Models.Reused
{
    public class Filter
    {
        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâầấậẩẫăằắặẳẵ",
            "ÁÀẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴ",
            "èéẹẻẽêềếệểễ",
            "ÈÉẸẺẼÊỀẾỆỂỄ",
            "òóọỏõôồốộổỗơờớợởỡ",
            "ÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠ",
            "ùúụủũưừứựửữ",
            "ÚÙỤỦŨƯỪỨỰỬỮ",
            "ìíịỉĩ",
            "ÌÍỊỈĨ",
            "đ",
            "Đ",
            "ỳýỵỷỹ",
            "ỲÝỴỶỸ"
        };

        public static string FilterChar(string str)
        {
            str = str.Trim();
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                }
            }
            str = str.Replace(" ", "-");
            str = str.Replace("--", "-");
            str = str.Replace("?", "");
            str = str.Replace("&", "");
            str = str.Replace(",", "");
            str = str.Replace(":", "");
            str = str.Replace("!", "");
            str = str.Replace("'", "");
            str = str.Replace("\"", "");
            str = str.Replace("%", "");
            str = str.Replace("#", "");
            str = str.Replace("$", "");
            str = str.Replace("*", "");
            str = str.Replace("`", "");
            str = str.Replace("~", "");
            str = str.Replace("@", "");
            str = str.Replace("^", "");
            str = str.Replace(".", "");
            str = str.Replace("/", "");
            str = str.Replace(">", "");
            str = str.Replace("<", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("{", "");
            str = str.Replace("}", "");
            str = str.Replace(";", "");
            str = str.Replace("+", "");
            return str.ToLower();
        }
    }
}