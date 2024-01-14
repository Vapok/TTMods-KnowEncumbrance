using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace KnowEncumbrance
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class KnowEncumbrance : BaseUnityPlugin
    {
        private const string MyGUID = "com.vapok.KnowEncumbrance";
        private const string PluginName = "KnowEncumbrance";
        private const string VersionString = "1.0.1";

        private static Harmony _harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);
        
        private static KnowEncumbrance _instance;

        private void Awake()
        {
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            _instance = this;
            
            Logger.LogInfo($"{PluginName} [{VersionString}] is loading...");
            Log = Logger;
            
            _harmony.PatchAll();
        }
    }
}