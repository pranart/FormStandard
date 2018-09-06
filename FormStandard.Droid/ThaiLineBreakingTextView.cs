using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Java.Lang;
using FormStandard.Shared.ThaiLineBreaker.engine;
using FormStandard.Shared.ThaiLineBreaker.Interface;
using FormStandard.Shared.ThaiLineBreaker.util;

namespace FormStandard.Shared
{
    public class ThaiLineBreakingTextView : TextView
    {
        private static class Holder
        {
            private static volatile IThaiLineBreaker breaker;
        }
        public ThaiLineBreakingTextView(Context context) :
            base(context)
        {

        }

        public ThaiLineBreakingTextView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {

        }

        public ThaiLineBreakingTextView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {

        }

        private string OriginalString { get; set; } = "";
        private static char NBSP = '\u00a0';
        private static int JELLY_BEAN = 16;
        private volatile bool shouldRefresh = false;

        private void init(Context context)
        {

            //AsyncTask<Context, Void, Boolean> atask = new AsyncTask<Context, Void, Boolean>()
            //{

            //    protected Boolean doInBackground(Context... params)
            //    {
            //        // double lock lazy init pattern
            //        ThaiLineBreaker temp = Holder.breaker;
            //        if (temp == null)
            //        { // first lock
            //            Holder.init(params[0].getResources());
            //            return true;
            //        }       
            //        return false;
            //    };

            //    protected override void onPostExecute(Boolean result)
            //    {
            //        if (result && shouldRefresh && getEllipsize() == null)
            //            setText(doBreakText(originalString, getInnerWidth(),
            //                    getPaint()));
            //    }
            //};
            //atask.execute(context);
        }

        public void SetText2(int resid)
        {
            SetText2(this.Context.Resources.GetText(resid));

        }

        public void SetText2(string text)
        {
            OriginalString = text;
            Refresh();
        }

        protected override void OnTextChanged(ICharSequence text, int start, int lengthBefore, int lengthAfter)
        {
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            Refresh();
        }

        public string getText2()
        {
            return OriginalString;
        }

        private int getInnerWidth()
        {
            int ans = Width - TotalPaddingLeft - TotalPaddingRight - 5;
            // FIXME troublesome jellybean and correct this function when android
            // fix this problem
            return Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean ? ans - 5 : ans;
        }

        private void Refresh()
        {
            //if (Holder.breaker == null)
            //{
            //    shouldRefresh = true;
            //    return;
            //}
            if (Ellipsize != null)
                Text = OriginalString;
            else
                Text = (doBreakText(OriginalString, getInnerWidth(), Paint));
        }

        // ========================================================================
        // ======================end of obligatory methods=========================
        // ========================================================================

        private static string doBreakText(string originalString,
                int innerWidth, Android.Graphics.Paint textPainter)
        {
            if (innerWidth <= 0)
                return originalString;
            string nbspString = originalString.Replace(' ', NBSP);
            List<string> lines = Utils.LongStringToList(nbspString);
            var ans = new System.Text.StringBuilder();
            foreach (var s in lines)
                ans.Append(breakLine(s, innerWidth, textPainter)).Append('\n');
            return Utils.TrimTrailingWhiteSpace(ans.ToString());
        }

        private static string breakLine(string oneLine, int innerWidth,
                Paint textPainter)
        {
            IThaiLineBreaker breaker = new LineBreaker();
            StringBuilder ans = new StringBuilder(oneLine);
            int pos = 0, count = 0;
            /*
             * FIXME count < oneLine.length() to prevent infinite loop in jb??
             */
            while (pos <= oneLine.Length && count < oneLine.Length)
            {
                // TODO trim leading space
                pos = offsetLeadingSpace(oneLine, pos);
                int maxText = textPainter.BreakText(oneLine, pos, oneLine.Length,
                        true, innerWidth, null);
                // FIXME troublesome jellybean and correct this function when
                // android fix this problem
                //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
                    //maxText = resolveCorrectPositionForJB(oneLine, pos,
                                                          //oneLine.Length, maxText);
                int breakAt = breaker.BreakLine(oneLine, pos + maxText);
                count += addAdditionalSpacing(pos + maxText, breakAt, oneLine, ans,
                        pos, count);
                pos = breakAt;
                ans.Insert(pos + count, '\n');
                count++;
            }
            return ans.ToString();
        }

        private static int offsetLeadingSpace(string line, int offset)
        {
            while (offset < line.Length)
            {
                char c = line[offset];
                if (Character.IsWhitespace(c))
                    offset++;
                else
                    break;
            }
            return offset;
        }

        /**
         * Make all spaces in this line become double space if not already is. We do
         * this only when the right side has too many space to spare from line
         * breaking algorithm.
         */
        private static int addAdditionalSpacing(int attempt, int actualBreak,
                string s, StringBuilder ans, int offset, int offset2)
        {
            int countSpace = ThaiUtil.CountNonZeroWidth(s, actualBreak,
                    attempt);
            List<int> addingPlaces = new List<int>();
            bool isPreviousOneSpace = false;
            for (int i = offset + offset2 + 1; i < actualBreak + offset2 - 2; i++)
            {
                if (!ThaiUtil.IsWhiteSpace(ans.ToString()[i]))
                {
                    isPreviousOneSpace = false;
                    continue;
                }
                if (isPreviousOneSpace)
                {
                    if (addingPlaces[addingPlaces.Count - 1] == i - 1)
                        addingPlaces.Remove(addingPlaces.Count - 1);
                    continue;
                }
                addingPlaces.Add(i);
                isPreviousOneSpace = true;
            }
            if (countSpace < addingPlaces.Count)
                return 0;
            for (int i = 0; i < addingPlaces.Count; i++)
                ans.Insert(i + addingPlaces[i], NBSP);
            return addingPlaces.Count;
        }

        /**
         * SaraUm which is one character is misunderstood by native android to be 2
         * chars so we need to convert it back. Damned u Android!!
         * 
         */
        //private static int resolveCorrectPositionForJB(string s, int start,
        //        int end, int pos)
        //{
        //    TreeSet<Integer> saraUmPos = new TreeSet<Integer>();
        //    for (int i = start; i < end; i++)
        //        if (s.charAt(i) == 'ำ')
        //            saraUmPos.add(i - start);
        //    return pos - saraUmPos.headSet(pos).size();
        //}
    }

}

