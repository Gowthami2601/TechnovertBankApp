using System;

namespace Technovert.BankApp.Services
{
    public class BankMessages
    {
        public static string GetStringInput()
        {
            return Console.ReadLine();
        }
        public static int GetIntInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int StringInt(string s)
        {
            return Convert.ToInt32(s);
        }
        public static void UserOutput(string s)
        {
            Console.WriteLine(s);
        }
    }
}
