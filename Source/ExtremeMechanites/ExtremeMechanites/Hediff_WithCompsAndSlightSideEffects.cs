using System;
using RimWorld;
using Verse;

namespace ExtremeMechanites
{
    public class Hediff_WithCompsAndSlightSideEffects : HediffWithComps
    {
        private double chance = 1d;
        private Random rg = new Random();

        public override void PostMake()
        {
            var chances = this.def.GetModExtension<effectChances>();

            if (chances != null)
            {
                chance = chances.slightSideEffectChance / 20000;
            }
            else
            {
                chance = 0.20 / 20000;
            }
        }

        public override void Tick()
        {
            base.Tick();


            if((ConfigClass.slightSideEffects && rg.NextDouble() < chance) || ConfigClass.instantlyApplySideEffects)
            {
                HediffDef sideEffect = SlightSideEffects.getSlightSideEffect();
                this.pawn.health.AddHediff(sideEffect);

                Find.LetterStack.ReceiveLetter("Side Effect", this.pawn.Name + " has encountered the following mechanoid side effect: " + sideEffect.label, LetterDefOf.NegativeEvent, null, null, null);
            }
        }
    }
}
