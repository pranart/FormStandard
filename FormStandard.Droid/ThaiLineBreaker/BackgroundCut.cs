using System;
using System.Runtime.Remoting.Contexts;
using Android.OS;
using Java.Lang;

namespace NeatLibrary.Shared.ThaiLineBreaker
{
    public class BackgroundCut : AsyncTask
    {
        public BackgroundCut()
        {
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            ThaiLineBreaker temp = Holder.breaker;
            if (temp == null)
            { // first lock
                Holder.init(params[0].getResources());
                return true;
            }
            return false;
        }
        protected Boolean doInBackground(Context... params)
        {
            // double lock lazy init pattern
        };

        protected override void onPostExecute(Boolean result)
        {
            if (result && shouldRefresh && getEllipsize() == null)
                setText(doBreakText(originalString, getInnerWidth(),
                        getPaint()));
        }

    }
}
