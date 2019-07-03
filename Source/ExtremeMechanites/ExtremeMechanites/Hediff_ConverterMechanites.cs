using System;
using Verse;

namespace ExtremeMechanites
{
    public class Hediff_ConverterMechanites : HediffWithComps
    {
        public override void PostMake()
        {
            base.PostMake();

            this.pawn.SetFaction(Find.FactionManager.OfPlayer);
        }
    }
}
