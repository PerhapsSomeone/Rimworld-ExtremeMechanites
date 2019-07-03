using System;
using RimWorld;
using Verse;

namespace ExtremeMechanites
{
    public class Hediff_ExtremeMechanites : Hediff
    {

        // 20.000 Ticks in one day

        private double chance = 0.5 / (20000 * 10);
        Random rg = new Random();

        public override void Tick()
        {

            if(!ConfigClass.pawnsExplode)
            {
                return;
            }

            double generatedNum = rg.NextDouble();
            //Log.Message(generatedNum.ToString());

            if (rg.NextDouble() < chance || ConfigClass.instantlyApplySideEffects)
            {
                Map map = this.pawn.Map;
                IntVec3 pos = this.pawn.Position;
                float radius = 5f;
                Thing launcher = null;
                int damage = 20;
                float armorPenetration = 1f;
                DamageDef bomb = DamageDefOf.Bomb;

                DamageInfo exploded = new DamageInfo(bomb, damage, armorPenetration, -1f, this.pawn);

                GenExplosion.DoExplosion(pos, map, radius, bomb, launcher, damage, armorPenetration);

                if(!this.pawn.Dead)
                {
                    this.pawn.Kill(exploded);
                }
            }

            base.Tick();
        }
    }
}
