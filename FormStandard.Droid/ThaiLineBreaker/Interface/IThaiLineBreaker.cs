namespace FormStandard.Shared.ThaiLineBreaker.Interface
{
    public interface IThaiLineBreaker
    {
        int BreakLine(string longString, int breakingAttempt);
    }
}
