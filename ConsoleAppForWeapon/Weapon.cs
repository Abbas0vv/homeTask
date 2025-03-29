using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForWeapon
{
    class Weapon
    {
        public Weapon(int maxBullets, int bullets, bool isAuto)
        {
            _maxBullets = maxBullets;
            _bullets = bullets;
            _isAuto = isAuto;
        }
        public int _bullets 
        { 
            get 
            {
                return _bullets;
            }
            set 
            {
                if (value < _maxBullets)
                    _bullets = value;
                else 
                    _bullets = 0;
            }
        }
        public int _maxBullets { get; set; }
        public bool _isAuto { get; set; }


        public void Shoot()
        {
            if (HaveBullet(_bullets))
            {
                if (_isAuto)
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
            else
                Console.WriteLine("No bullets left...");
        }
        public string GunSound()
        {
            return "Pew";
        }
        public bool HaveBullet(int bullets)
        {
            if (bullets > 0)
                return true;
            else return false;
        }
        public int GetRemainBulletCount()
        {
            int needForBullets = _maxBullets - _bullets;
            return needForBullets;
        }
        public void Reload()
        {
            if (_bullets < _maxBullets)
                _bullets = _maxBullets;
        }
        public void ChangeFireMode()
        {
            if (_isAuto)
                _isAuto = false;
            else
                _isAuto = true;
        }
    }
}
