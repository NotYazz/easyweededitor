using MelonLoader;
using HarmonyLib;
using UnityEngine;

[assembly: MelonInfo(typeof(ezweededit.Core), "EasyWeedEditor", "1.0.0", "Yazz")]
[assembly: MelonGame("TVGS", "Schedule I Free Sample")]

namespace ezweededit
{
    public class Core : MelonMod
    {
        public static Core Instance { get; private set; }
        public GUI GuiInstance { get; private set; }
        public Hooks HooksInstance { get; private set; }

        public override void OnApplicationStart()
        {
            Instance = this;
            LoggerInstance.Msg("EasyWeedEditor!");
            LoggerInstance.Warning("THIS PRODUCT IS FREE!");
            LoggerInstance.Msg("Made by notyazzzz on discord!");
            GuiInstance = new GUI();
            HooksInstance = new Hooks();

            HarmonyLib.Harmony harmony = new HarmonyLib.Harmony("Sum");
            harmony.PatchAll();
        }

        public override void OnGUI()
        {
            GuiInstance.OnGUI();
        }

        public override void OnUpdate()
        {
            GuiInstance.OnUpdate();
        }
    }
}
