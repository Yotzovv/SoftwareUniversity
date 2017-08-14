namespace _05.Security_Door
{
    public class KeyCardCheck : SecurityCheck
    {
        private IKeyCardUI keyCardUI;

        public KeyCardCheck(IKeyCardUI keyCardUI)
        {
            this.keyCardUI = keyCardUI;
        }

        private bool IsValid(string code)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            string code = keyCardUI.RequestKeyCard();
            if (IsValid(code))
            {
                return true;
            }

            return false;
        }
    }
}