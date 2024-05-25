using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    //- Has a 20% chance to deal a critical hit that doubles damage.
    //- Each attack restores 5% of his maximum health.
    public class Controller : Hero
    {
        public Controller(string name) : base(name)
        {
        }

        public override int Attack()
        {
            int baseAttack = base.Attack();
            int dice = Random.Shared.Next(0, 100);
            if (dice < 20)
            {
                baseAttack *= 2; //Critical hit
            }
            Heal(0.05 * MaxHealth); //Restores 5% of maximum health
            return baseAttack;
        }

        private void Heal(double healthPoints)
        {
            Health += (int)healthPoints;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}
