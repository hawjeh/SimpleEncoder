using System;
using System.Linq;
using System.Collections.Generic;

namespace EncoderCore
{
    public class Work : IWork
    {
        private static readonly char[] _alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789()*+,-./".ToCharArray();
        private readonly char _mappingType;

        public Work(char MappingType)
        {
            _mappingType = MappingType;
        }

        public string Encode(string plainText)
        {
            plainText = plainText.Trim().ToUpper();
            var encodedStr = string.Empty;

            var tableIndex = Array.FindIndex(_alphabets, x => x == _mappingType);
            if (tableIndex == 0) return plainText;

            var cutArray = ShiftTable(tableIndex);
            var listOfIndexes = CheckStringArray(plainText, _alphabets);
            var number = 0;

            encodedStr += _mappingType.ToString();
            foreach (var i in listOfIndexes)
            {
                int.TryParse(i, out number);
                encodedStr = number == 0 ? encodedStr += i : encodedStr += cutArray[number];
            }

            return encodedStr;
        }

        public string Decode(string encodedText)
        {
            encodedText = encodedText.Trim().ToUpper();
            var decodedStr = string.Empty;

            var tableIndex = Array.FindIndex(_alphabets, x => x == encodedText[0]);
            if (tableIndex == 0) return encodedText;

            var cutArray = ShiftTable(tableIndex);
            var listOfIndexes = CheckStringArray(encodedText.Substring(1), cutArray);
            var number = 0;

            foreach (var i in listOfIndexes)
            {
                int.TryParse(i, out number);
                decodedStr = number == 0 ? decodedStr += i : decodedStr += _alphabets[number];
            }

            return decodedStr;
        }

        private List<string> CheckStringArray(string plaintext, char[] arraylist)
        {
            var listOfIndexes = new List<string>();

            for (var i = 0; i < plaintext.Length; i++)
            {
                if (arraylist.Contains(plaintext.ToUpper()[i]))
                {
                    listOfIndexes.Add(Array.FindIndex(arraylist, x => x == plaintext.ToUpper()[i]).ToString());
                }
                else
                {
                    listOfIndexes.Add(plaintext[i].ToString());
                }
            }
            return listOfIndexes;
        }

        private char[] ShiftTable(int index)
        {
            var temp = new string(_alphabets);
            var cutString = temp.Substring(temp.Length - index, index) + temp.Substring(0, (temp.Length - index));
            return cutString.ToCharArray();
        }
    }
}
