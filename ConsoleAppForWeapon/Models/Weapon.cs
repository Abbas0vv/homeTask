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
        int _maxBullets;

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
                if (value <= MaxBullets && value >= 0)
                    _bullets = value;
                else
                    _bullets = MaxBullets;
            }
        }
        public int MaxBullets
        {
            get { return _maxBullets; }
            set
            {
                if (value > 0)
                    _maxBullets = value;
            }
        }

        public bool IsAuto { get; set; }


        public void Shoot()
        {
            if (HaveBullet(_bullets))
                MakeGunSound();
            else
                Console.WriteLine("No bullets left...");
        }
        public void MakeGunSound()
        {
            if (IsAuto)
            {
                while (HaveBullet(_bullets))
                {
                    GunSound();
                    _bullets--;
                }
                Console.WriteLine("Auto Mode");
            }
            else
            {
                GunSound();
                Console.WriteLine("Single Mode");
                _bullets--;
            }
        }

        public void GunSound()
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
