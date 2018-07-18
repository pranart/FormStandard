namespace FormStandard
{
    public interface IHardwareSecurity
    {
        bool IsJailBreaked();
        bool IsInEmulator();
    }
}