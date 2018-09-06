using System;
using System.Text;

namespace FormStandard.Shared.ThaiLineBreaker.engine
{
    public class WordPosition
    {
        private int start, end;

        public WordPosition(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public bool isEmpty()
        {
            return start == end;
        }

        public int getEnd()
        {
            return end;
        }

        public int getStart()
        {
            return start;
        }

        public int length()
        {
            return end - start;
        }


        public override string ToString()
        {
            return new StringBuilder("[").Append(start).Append(", ").Append(end)
                    .Append(']').ToString();
        }
    }

}
