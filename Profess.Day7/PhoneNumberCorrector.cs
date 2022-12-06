using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Profess.Day7
{
    public class PhoneNumberCorrector
    {
        string _phoneNumber;
        public PhoneNumberCorrector(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public string Correct()
        {
            string result;

            if (IsRightFormat())
            {
                result = _phoneNumber;
                return result;
            }

            if (!IsNumberFormatCorrect())
            {
                throw new Exception("The number is incorrect!");
            }

            return "";
        }

        public bool IsRightFormat()
        {
            string numberPattern = @"\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}";
            return Regex.IsMatch(_phoneNumber, numberPattern);
        }

        public string ClearFromAnotherChars()
        {
            string pattern = @"[\+\s\-\(\)]*";
            string target = "";
            return Regex.Replace(_phoneNumber, pattern, target);
        }

        public bool IsNumberFormatCorrect()
        {
            string result = ClearFromAnotherChars();
            return !Regex.IsMatch(result, @"[^\d]+") && Regex.IsMatch(result, @"^(7|8)") && result.Length == 11;
        }
    }
}
