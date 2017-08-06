namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            string input;

            Type classType = Type.GetType("_02BlackBoxInteger.BlackBoxInt");

            Object classInstance = Activator.CreateInstance(classType,
                                                            BindingFlags.NonPublic |
                                                            BindingFlags.Instance,
                                                            null,
                                                            new object[] { 0 },
                                                            null);
            
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split('_');
                string method = tokens[0];
                int parameter = int.Parse(tokens[1]);

                MethodInfo methodInfo = classType.GetMethod(method,
                                                        BindingFlags.NonPublic |
                                                        BindingFlags.Instance);

                methodInfo.Invoke(classInstance, new object[] { parameter });

                FieldInfo field = classInstance.GetType().GetField("innerValue",
                                                                BindingFlags.NonPublic |
                                                                BindingFlags.Instance |
                                                                BindingFlags.Static);

                Console.WriteLine(field.GetValue(classInstance));
            }
        }
    }
}
