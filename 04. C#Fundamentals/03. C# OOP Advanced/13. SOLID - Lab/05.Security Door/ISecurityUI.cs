namespace _05.Security_Door
{
    public interface IPinCodeCheck
    {
        string RequestKeyCard();

        int RequestPinCode();
    }
}