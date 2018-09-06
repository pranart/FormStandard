using System;
using System.Collections.Generic;
using System.IO;

namespace FormStandard.Shared.ThaiLineBreaker.util
{
    public class Utils
    {
        private Utils()
        {
        }

        public static List<string> LongStringToList(string longString)
        {
            if (longString == null)
                throw new ArgumentNullException();
            var reader = new StringReader(longString);
            var data = new List<string>();
            string line;
            try
            {
                while ((line = reader.ReadLine()) != null)
                    data.Add(line);
                return data;
            }
            catch (IOException e)
            {
                throw new Exception(
                        "io error on string reader should never happen", e);
            }
        }

        public static string TrimTrailingWhiteSpace(string s)
        {
            int lastPos = s.Length;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (Char.IsWhiteSpace(c))
                    lastPos--;
                else
                    break;
            }
            return s.Substring(0, lastPos);
        }

    }

}
