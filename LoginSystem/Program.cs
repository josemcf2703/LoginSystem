using System;

namespace LoginSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("1 - Register");
            Console.WriteLine("2 - Login");

            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1) {
                new RegisterHandler().Register();
            } else {
                new LoginHandler().Login();
            }

        }
    }
}