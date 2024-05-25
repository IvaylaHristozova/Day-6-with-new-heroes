using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    //- Has a 25% chance to avoid an attack entirely.
    //- Every third attack deals damage equal to 2 times his strength.
    public class Speedster : Hero
    {
        public Speedster(string name) : base(name)
        {
            attackCount = 0;
        }

        private int attackCount;

        public override int Attack()
        {
            attackCount++;
            int baseAttack = base.Attack();
            if (attackCount == 3)
            {
                baseAttack = Strength * 2;
                attackCount = 0;
            }
            return baseAttack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            int dice = Random.Shared.Next(0, 100);
            if (dice < 25)
            {
                incomingDamage = 0; //Avoids the attack entirely
            }
            base.TakeDamage(incomingDamage);
        }
    }
}
