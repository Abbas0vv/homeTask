using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForWeapon
{
    class Weapon
    {
        public Weapon(int bullets, int maxBullets, bool isAuto)
        {
            _bullets = bullets;
            _maxBullets = maxBullets;
            _isAuto = isAuto;
        }

        public int _bullets { get; set; }
        public int _maxBullets { get; set; }
        public bool _isAuto { get; set; }


        public void Shoot()
        {
            if (_bullets > 0)
            {
                if (_isAuto)
                {
                    while (_bullets > 0)
                    {
                        Console.Write("Pew ");
                        _bullets--;
                    }
                    Console.WriteLine("Auto Mode");
                }
                else
                {
                    Console.WriteLine("Pew");
                    Console.WriteLine("Single Mode");
                    _bullets--;
                }
            }
            else
            {
                Console.WriteLine("Güllən qalmayıb :/");
            }
        }
            

        public int GetRemainBulletCount()
        {
            int needForBullets = _maxBullets - _bullets;
            return needForBullets;
        }

        public void Reload()
        {
            if ( _bullets < _maxBullets )
            {
                _bullets = _maxBullets;
            }
        }

        public void ChangeFireMode()
        {
            if (_isAuto)
            {
                _isAuto = false;
            }
            else
            {
                _isAuto = true;
            }
        }
    }
}
