namespace _05.Security_Door
{
    public class PinCodeCheck : SecurityCheck
    {
        private IPinCodeCheck pinCodeCheck;

        public PinCodeCheck(IPinCodeCheck pinCodeCheck)
        {
            this.pinCodeCheck = pinCodeCheck;
        }

        private bool IsValid(int pin)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            int pin = pinCodeCheck.RequestPinCode();
            if (IsValid(pin))
            {
                return true;
            }

            return false;
        }
    }
}