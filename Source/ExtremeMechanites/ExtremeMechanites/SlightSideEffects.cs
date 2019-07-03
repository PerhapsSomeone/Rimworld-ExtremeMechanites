using System;
using RimWorld;
using Verse;

namespace ExtremeMechanites
{
    public class SlightSideEffects
    {

        private static HediffDef HungerEffect = HediffDef.Named("HungryMechanites");


        private static HediffDef[] AllEffects = new HediffDef[]
        {
            HungerEffect
        };

        private static Random rg = new Random();

        public static HediffDef getSlightSideEffect()
        {
            int choice = rg.Next(0, AllEffects.Length);

            return AllEffects[choice];
        }
    }
}
