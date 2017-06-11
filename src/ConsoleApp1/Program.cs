using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var killer = KillerFactory.CreateKillerWithBomb();

            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var isKill = random.Next() % 5 == 0;
                if (isKill)
                {
                    killer.Weapon.Kill();
                    killer.SumKill++;
                }
                else
                {
                    Console.WriteLine("Killer failed");
                    killer.ChangeWeapon();
                    killer.ChangeIpoteka(110000);
                }
            }

            Console.WriteLine($"{killer.FullName} kills: {killer.SumKill}");
            Console.WriteLine($"{killer.GetSumIpoteka()}");

            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public static class KillerFactory
    {
        public static Killer CreateKillerWithBomb()
        {
            return new Killer("Petr", "Semenov", "Petrovich")
            {
                Weapon = new Bomb()
            };
        }
    }

    public interface IWeapon
    {
        void Kill();
    }

    public class Knife : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Knife");
        }
    }

    public class Gun : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Gun");
        }
    }

    public class Bomb : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Bomb");
        }
    }

    public abstract class Human
    {
        private int _countLegs;

        protected Human()
        {
            _countLegs = 2;
        }

        protected decimal SumIpoteka;

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string SurName { get; protected set; }

        public string FullName => $"{FirstName} {LastName} {SurName}";
    }

    public class Killer : Human
    {
        public Killer(string firstName, string lastName, string surName)
        {
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
        }

        public int SumKill { get; set; }
        public IWeapon Weapon { get; set; }

        public void ChangeIpoteka(decimal sum)
        {
            SumIpoteka = sum;
        }

        public decimal GetSumIpoteka()
        {
            return SumIpoteka;
        }

        public void ChangeWeapon()
        {
            if (Weapon is Knife)
            {
                Weapon = new Gun();
                return;
            }

            if (Weapon is Gun)
            {
                Weapon = new Bomb();
                return;
            }

            if (Weapon is Bomb)
            {
                Weapon = new Knife();
            }
        }
    }
}
