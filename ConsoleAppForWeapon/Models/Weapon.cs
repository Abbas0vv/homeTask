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
            }
        }
        public int MaxBullets
        {
            get { return _maxBullets; }
            set
            {
                if (value > 0)
                    _maxBullets = value;
                else
                    _maxBullets = 0;
            }
        }
        public bool IsAuto { get; set; }


        public void Shoot()
        {
            if (DoesHaveBullet())
                MakeGunSound();
            else
                Console.WriteLine("No bullets left...");
        }
        public void MakeGunSound()
        {
            if (IsAuto)
            {
                while (DoesHaveBullet())
                {
                    Console.WriteLine(GunSound());
                    _bullets--;
                }
                Console.WriteLine("Auto Mode");
            }
            else
            {
                if (DoesHaveBullet())
                {
                    Console.WriteLine(GunSound());
                    Console.WriteLine("Single Mode");
                    _bullets--;
                }
            }
        }
        public string GunSound()
        {
            return "Pew";
        }
        public bool DoesHaveBullet()
        {
            return _bullets > 0;
        }
        public int GetRemainBulletCount()
        {
            return MaxBullets - _bullets;
        }
        public void Reload()
        {
            if (_bullets < MaxBullets)
            {
                _bullets = MaxBullets;
                Console.WriteLine("Reloaded!");
            }
            else
                Console.WriteLine("Already Reloaded!");
            
        }
        public void ChangeFireMode()
        {
            IsAuto = !IsAuto;
        }
    }
}
