using System;
using System.Collections;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Fairwood.InfoValidation
{
    public static class AlphabeticUnderbar
    {
        static readonly Regex r = new Regex(@"[a-zA-Z0-9_]+$");
        public static bool CheckValid(string text)
        {
            return r.IsMatch(text);
        }
    }
    public static class ChineseCivilizationID
    {
        static readonly int[] coefs = new int[17] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        /// <summary>
        /// 15位数一代身份证号都算失效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckValid(string id)
        {
            if (id.Length != 18) return false;
            int sum = 0;
            int b;
            for (int i = 0; i < id.Length - 1; i++)
            {
                b = -1;
                if (int.TryParse(id.Substring(i, 1), out b))
                {
                    sum += b * coefs[i];
                }
                else
                    return false;
            }
            if (!int.TryParse(id.Substring(id.Length - 1, 1), out b))
            {
                if (char.ToUpper(id[id.Length - 1]) == 'X')
                    b = 10;
                else
                    return false;
            }
            if ((12 - sum % 11) % 11 != b)
                return false;
            return true;
        }
    }

    public static class Email
    {
        static readonly Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
        public static bool CheckAddressValid(string emailAddr)
        {
            return r.IsMatch(emailAddr);
        }
    }
}