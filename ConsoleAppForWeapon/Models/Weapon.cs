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
            if (DoesHaveBullet(_bullets))
                MakeGunSound();
            else
                Console.WriteLine("No bullets left...");
        }
        public void MakeGunSound()
        {
            if (IsAuto)
            {
                while (DoesHaveBullet(_bullets))
                {
                    Console.WriteLine(GunSound());
                    _bullets--;
                }
                Console.WriteLine("Auto Mode");
            }
            else
            {
                Console.WriteLine(GunSound());
                Console.WriteLine("Single Mode");
                _bullets--;
            }
        }
        public string GunSound()
        {
            return "Pew";
        }
        public bool DoesHaveBullet(int bullets)
        {
            if (bullets > 0)
                return true;
            else return false;
        }
        public int GetRemainBulletCount()
        {
            return MaxBullets - _bullets;
        }
        public void Reload()
        {
            _bullets = MaxBullets;
        }
        public void ChangeFireMode()
        {
            IsAuto = !IsAuto;
        }
    }
}
