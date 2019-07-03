using System;
using System.Threading;
using HugsLib;
using HugsLib.Settings;

namespace ExtremeMechanites 
{
    public class HugsLibModBase : ModBase
    {
        public override string ModIdentifier
        {
            get { return "ExtremeMechanites"; }
        }

        //private SettingHandle<bool> toggle;

        public override void DefsLoaded()
        {
            changeConfigValues();
        }

        public void changeConfigValues()
        {
            bool pawnsCanExplode = Settings.GetHandle<bool>("pawnsCanExplode", "People explode", "Toggle explosive side effects of mechanites.", true);
            ConfigClass.pawnsExplode = pawnsCanExplode;

            bool slightSideEffects = Settings.GetHandle<bool>("slightSideEffects", "Slight Side Effects", "Toggle slight side effects.", true);
            ConfigClass.slightSideEffects = slightSideEffects;

            bool applyAllSideEffects = Settings.GetHandle<bool>("allSideEffects", "Debugging mode (DANGER)", "All bad effects of mechanites will be instantly applied. Your pawns will probably die instantly.", false);
            ConfigClass.instantlyApplySideEffects = applyAllSideEffects;


        }

        public override void SettingsChanged()
        {
            base.SettingsChanged();
            changeConfigValues();
        }
    }
}
