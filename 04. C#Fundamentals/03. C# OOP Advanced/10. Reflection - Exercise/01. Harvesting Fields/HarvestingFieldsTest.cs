namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        public void Harvest()
        {
            Type classType = Type.GetType("_01HarestingFields.HarvestingFields");

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
                                                     BindingFlags.NonPublic|
                                                     BindingFlags.Public);
            
            string cmd;

            while((cmd = Console.ReadLine()) != "HARVEST")
            {
                switch (cmd)
                {
                    case "private":
                        GetPrivateFields(fields);
                        break;
                    case "protected":
                        GetProtectedFields(fields);
                        break;
                    case "public":
                        GetPublicFields(fields);
                        break;
                    case "all":
                        GetAllFields(fields);
                        break;
                }
            }
        }

        private void GetAllFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                if(field.Attributes.ToString() == "Family")
                {
                    Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                }
                else
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                }

            }

        }

        private static void GetPublicFields(FieldInfo[] fields)
        {
            fields.Where(f => f.IsPublic)
                  .ToList()
                  .ForEach(f =>
                   Console.WriteLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));
        }

        private static void GetProtectedFields(FieldInfo[] fields)
        {
            fields.Where(f => f.IsFamily)
                  .ToList()
                  .ForEach(f =>
                   Console.WriteLine($"protected {f.FieldType.Name} {f.Name}"));
        }

        public static void GetPrivateFields(FieldInfo[] fields)
        {
            fields.Where(f => f.IsPrivate)
                  .ToList()
                  .ForEach(f => 
                   Console.WriteLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));
        }
    }
}
