using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForWeapon.Models
{
    class Weapon
    {
        int _bullets;
        public Weapon(int maxBullets, int bullets, bool isAuto)
        {
            MaxBullets = maxBullets;
            Bullets = bullets;
            IsAuto = isAuto;
        }

        public int Bullets
        {
            get
            {
                return _bullets;
            }
            set
            {
                if (value < MaxBullets)
                    _bullets = value;
                else
                    _bullets = MaxBullets;
            }
        }
        public int MaxBullets { get; set; }
        public bool IsAuto { get; set; }


        public void Shoot()
        {
            if (HaveBullet(_bullets))
            {
                if (IsAuto)
                {
                    while (HaveBullet(_bullets))
                    {
                        MakeGunSound();
                        _bullets--;
                    }
                    Console.WriteLine("Auto Mode");
                }
                else
                {
                    MakeGunSound();
                    Console.WriteLine("Single Mode");
                    _bullets--;
                }
            }
            else
                Console.WriteLine("No bullets left...");
        }
        public void MakeGunSound()
        {
            Console.WriteLine("Pew");
        }
        public bool HaveBullet(int bullets)
        {
            if (bullets > 0)
                return true;
            else return false;
        }
        public int GetRemainBulletCount()
        {
            int needForBullets = MaxBullets - _bullets;
            return needForBullets;
        }
        public void Reload()
        {
            if (_bullets < MaxBullets)
                _bullets = MaxBullets;
        }
        public void ChangeFireMode()
        {
            if (IsAuto)
                IsAuto = false;
            else
                IsAuto = true;
        }
    }
}
