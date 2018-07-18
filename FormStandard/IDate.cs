using System;
namespace FormStandard
{
	public interface IDate
	{
		string ToChristainDateString(DateTime dateTime);
		string ToBuddhishDateString(DateTime dateTime);

        string ToChristainDateString(DateTime dateTime, string format);
        string ToBuddhishDateString(DateTime dateTime, string format);
	}
}
