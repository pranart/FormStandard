using System;

namespace FormStandard.Shared.ThaiLineBreaker.Interface
{
    public interface ITextViewReplacementMethod
    {
        void SetText2(int resid);

        void SetText2(string text);

        string GetText2();

        void SetText(int resid);

        void SetText(char[] text, int start, int len);

  //      void SetText(int resid, TextView.BufferType type);

        void SetText(string text);

//        void SetText(string text, TextView.BufferType type);

        string GetText();

    }
}
