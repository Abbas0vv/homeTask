using ConsoleAppForWeapon.Models;

namespace ConsoleAppForWeapon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            int bullets = 0;
            bool isAuto = false;
            int maxBullets = 0;

            Console.Write("Enter the maximum bullet count: ");
            GetAndValidateMaxBullets(ref maxBullets);

            Console.Write("Enter the initial bullet count: ");
            GetAndValidateInitialBulletCount(ref bullets, maxBullets);

            Console.Write("Should the weapon be automatic? (true/false): ");
            GetAndValidateBool(isAuto);

            Weapon myWeapon = new Weapon(maxBullets, bullets, isAuto);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 - To get information");
                Console.WriteLine("2 - For Shoot method (will shoot a bullet according to the current mode)");
                Console.WriteLine("3 - For GetRemainBulletCount method");
                Console.WriteLine("4 - For Reload method");
                Console.WriteLine("5 - For ChangeFireMode method");
                Console.WriteLine("0 - To stop the program");
                Console.WriteLine();

                int userChoice = 0;
                userChoice = GetAndValidateUserChoice(ref userChoice);

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine($"Your weapon's current bullet count: {myWeapon.Bullets}. Maximum bullet count: {myWeapon.MaxBullets}. Your weapon is in {(myWeapon.IsAuto ? "Automatic" : "Single-shot")} firing mode.");
                        break;

                    case 2:
                        myWeapon.Shoot();
                        break;

                    case 3:
                        Console.WriteLine($"Remaining bullets needed to reload: {myWeapon.GetRemainBulletCount()}");
                        break;

                    case 4:
                        myWeapon.Reload();
                        break;

                    case 5:
                        myWeapon.ChangeFireMode();
                        Console.WriteLine($"{(myWeapon.IsAuto ? "Automatic" : "Single-shot")} firing mode is now active.");
                        break;

                    case 0:
                        Console.WriteLine("Program stopped.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        public static int GetAndValidateMaxBullets(ref int maxBullets)
        {
            while (!int.TryParse(Console.ReadLine(), out maxBullets))
            {
                Console.WriteLine("Invalid input. Please enter an integer:");
            }
            return maxBullets;
        }
        public static int GetAndValidateUserChoice(ref int choice)
        {

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter correct choise:");
            }

            if (choice >= 0)
                return choice;
            else
            {
                Console.WriteLine("Invalid input");
                return 0;
            }
        }
        public static int GetAndValidateInitialBulletCount(ref int bullets, int maxBullets)
        {
            while (!int.TryParse(Console.ReadLine(), out bullets))
            {
                Console.WriteLine("Invalid input. Please enter an integer:");
            }
            if (bullets > maxBullets)
            {
                Console.WriteLine("Your initial bullet count cannot exceed the maximum bullet count.");
                return 0;
            }
            return bullets;
        }
        public static bool GetAndValidateBool(bool box)
        {
            while (!bool.TryParse(Console.ReadLine(), out box))
            {
                Console.WriteLine("Invalid input. Please enter 'true' or 'false':");
            }
            return box;
        }
    }
}
