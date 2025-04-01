using ConsoleAppForWeapon.Models;

namespace ConsoleAppForWeapon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu();
        }
        public static void Menu()
        {
            int bullets = 0;
            bool isAuto = false;
            int maxBullets = 0;

            Console.Write("Enter the maximum bullet count: ");
            GetAndValidateMaxBullets(maxBullets);

            Console.Write("Enter the initial bullet count: ");
            GetAndValidateInitialBulletCount(bullets, maxBullets);

            Console.Write("Should the weapon be automatic? (true/false): ");
            GetAndValidateBool(isAuto);

            Weapon myWeapon = new Weapon(maxBullets, bullets, isAuto);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("0 - İnformasiya almaq üçün");
                Console.WriteLine("1 - Shoot metodu üçün (hazirki moda uygun gulle atacaq)");
                Console.WriteLine("2 - GetRemainBulletCount metodu üçün");
                Console.WriteLine("3 - Reload metodu üçün");
                Console.WriteLine("4 - ChangeFireMode metodu üçün");
                Console.WriteLine("5 - Proqramdan dayandırmaq üçün");
                Console.WriteLine();

                int userChoise = 0;
                userChoise = GetAndValidateUserChoise(userChoise);

                switch (userChoise)
                {
                    case 0:
                        Console.WriteLine($"Sizin silahınızın güllə sayı: {myWeapon.Bullets}. Maximum güllə sayı : {myWeapon.MaxBullets}. Silahınız {(myWeapon.IsAuto ? "Avtomatik" : "Tək-tək")} atış modundadır");
                        break;

                    case 1:
                        myWeapon.Shoot();
                        break;

                    case 2:
                        Console.WriteLine($"Doldurmaq üçün lazım olan güllə sayı: {myWeapon.GetRemainBulletCount()}");
                        break;

                    case 3:
                        myWeapon.Reload();
                        break;

                    case 4:
                        myWeapon.ChangeFireMode();
                        Console.WriteLine($"{(myWeapon.IsAuto ? "Avtomatik" : "Tək-tək")} atış moduna keçdi.");
                        break;

                    case 5:
                        Console.WriteLine("Proqram dayandırıldı.");
                        return;

                    default:
                        Console.WriteLine("Yanlış seçim, yenidən daxil et.");
                        break;
                }
            }
        }

        public static int GetAndValidateMaxBullets(int maxBullets)
        {
            bool checkBox;
            while (!int.TryParse(Console.ReadLine(), out maxBullets))
            {
                Console.WriteLine("Invalid input. Please enter int:");
            }
            return maxBullets;
        }
        public static int GetAndValidateUserChoise(int choise)
        {
            bool checkBox = false;

            while (!checkBox)
            {
                checkBox = int.TryParse(Console.ReadLine(), out choise);
            }

            if (choise >= 0)
                return choise;
            else
            {
                Console.WriteLine("Wrong imput");
                return 0;
            }
        }
        public static int GetAndValidateInitialBulletCount(int bullets, int maxBullets)
        {
            bool checkBox;
            while (!int.TryParse(Console.ReadLine(), out bullets))
            {
                Console.WriteLine("Invalid input. Please enter int:");
            }
            if (bullets > maxBullets)
            {
                Console.WriteLine("Your initial bullet(s) count cannot be more than maxBullets");
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
