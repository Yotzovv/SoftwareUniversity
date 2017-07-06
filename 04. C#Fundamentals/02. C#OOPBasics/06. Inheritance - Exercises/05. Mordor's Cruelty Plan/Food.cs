namespace _05.Mordor_s_Cruelty_Plan
{
    public class Food
    {
        private string name;
        private int points;

        public Food(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                switch (name.ToLower())
                {
                    case "cram":
                        this.points = 2;
                        break;
                    case "lembas":
                        this.points = 3;
                        break;
                    case "apple":
                        this.points = 1;
                        break;
                    case "melon":
                        this.points = 1;
                        break;
                    case "honeycake":
                        this.points = 5;
                        break;
                    case "mushrooms":
                        this.points = -10;
                        break;
                    default:
                        this.points = -1;
                        break;
                }

                return this.points;
            }
        }
    }
}