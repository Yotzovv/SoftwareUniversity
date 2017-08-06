namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        public static void Harvest()
        {
            Type classType = Type.GetType("HarvestingFields");

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
                                                     BindingFlags.NonPublic|
                                                     BindingFlags.Public);
            
            string cmd;

            while((cmd = Console.ReadLine()) != "HARVEST")
            {
                switch (cmd)
                {
                    case "private":

                }
            }
        }

        public void GetPrivateFields(FieldInfo[] fields)
        {
            foreach (var field in fields.Where(f => f.IsPrivate))
            {
                Console.WriteLine();
            }
        }
    }
}
