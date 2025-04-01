using ConsoleAppForWeapon.Models;

namespace ConsoleAppForWeapon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu();

            static void Menu()
            {

                Console.Write("Enter the maximum bullet count: ");
                int maxBullets = int.Parse(Console.ReadLine());

                Console.Write("Enter the initial bullet count: ");
                int bullets = int.Parse(Console.ReadLine());

                Console.Write("Should the weapon be automatic? (true/false): ");
                bool isAuto = bool.Parse(Console.ReadLine());

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
                    userChoise = GetAndValidateUserChoise();
                    

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
            static int GetAndValidateUserChoise()
            {
                int choise = int.Parse(Console.ReadLine());
                if (choise >= 0)
                    return choise;
                else
                {
                    Console.WriteLine("Wrong imput");
                    return 0;
                }
            }
        }
    }
}
