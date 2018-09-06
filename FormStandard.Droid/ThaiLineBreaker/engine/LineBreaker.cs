using System;
using System.Linq;
using System.Text;
using THSplit;

namespace FormStandard.Shared.ThaiLineBreaker.engine
{
    public class LineBreaker : Interface.IThaiLineBreaker
    {
        public static Spliter Spliter { get; set; } = new Spliter();

        public LineBreaker()
        {
            
        }

        public int BreakLine(string longString, int breakingAttempt)
        {
            if (longString.Length == breakingAttempt + 1)
                breakingAttempt = longString.Length;
            
            var list = Spliter.SegmentByDictionary(longString);

            //int breakPosition = list?.FirstOrDefault()?.Length ?? int.MaxValue;
            var strings = new StringBuilder();
            foreach(var each in list)
            {
                if(strings.Length+each.Length == breakingAttempt)
                {
                    return breakingAttempt;
                }
                if(strings.Length+each.Length > breakingAttempt)
                {
                    return Math.Min(strings.Length, breakingAttempt);
                }
                strings.Append(each);
            }


            return Math.Min(strings.Length, breakingAttempt);
        }
    }
}
