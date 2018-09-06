namespace FormStandard.Shared.ThaiLineBreaker.util
{
    public class ThaiUtil
    {
        private ThaiUtil()
        {
        }

        public static bool IsWhiteSpace(char c)
        {
            return c == ' ' || c == '\u00a0';
        }

        public static bool IsThaiChar(char c)
        {
            return c >= '\u0e01' && c <= '\u0e5b';
        }

        public static bool IsZeroWidth(char c)
        {
            // wannayuk
            if (c <= '\u0e4d' && c >= '\u0e47')
                return true;
            // sara
            if (c <= '\u0e3a' && c >= '\u0e31' && c != '\u0e32' && c != '\u0e33')
                return true;
            return false;
        }

        public static int CountNonZeroWidth(string s, int from, int to)
        {
            int ans = 0;
            for (int i = from; i < to; i++)
                if (!IsZeroWidth(s[i]))
                    ans++;
            return ans;
        }

        public static bool IsPunctuation(char c)
        {
            // not dot
            return c == ' ' || c == '\'' || c == '"' || c == '\u00a0' || c == '’'
                    || c == '”' || c == '‘' || c == '“';
        }

        public static bool IsFrontDependentChar(char c)
        {
            return c == 'ะ' || c == 'า' || c == 'ำ' || c == '\'' || c == '"'
                    || c == '’' || c == '”' || c == 'ๆ' || IsZeroWidth(c);
        }

        public static bool IsRearDependentChar(char c)
        {
            return (c <= 'ไ' && c >= 'เ') || c == 'ั' || c == '\'' || c == '"'
                    || c == '‘' || c == '“';
        }
    }
}
