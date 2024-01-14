using HarmonyLib;
using KnowEncumbrance.Components;

namespace KnowEncumbrance.Patches
{
    public class AddComponentPatches
    {
        [HarmonyPatch(typeof(Player), nameof(Player.Awake))]
        public static class PlayerAwakeAddComponent
        {
            public static void Postfix(Player __instance) 
            {
                if (__instance != null)
                {
                    var encumbranceComponent = __instance.gameObject.AddComponent<EncumbranceManager>();
                    encumbranceComponent.PlayerController = __instance;
                }
            }
        }

        [HarmonyPatch(typeof(InventoryNavigator), nameof(InventoryNavigator.Init))]
        public static class InventoryNavigatorInitAddComponent
        {
            public static void Postfix(InventoryNavigator __instance) 
            {
                if (__instance != null)
                {
                    var inventoryManager = __instance.gameObject.AddComponent<InventoryManager>();
                    inventoryManager.Title = __instance.transform.Find("Top Level Container/Container/Player Inventory/Title (Inventory)")?.gameObject;
                }
            }
        }

        [HarmonyPatch(typeof(InventoryPageUI), nameof(InventoryPageUI.Start))]
        public static class InventoryPageUIStartAddComponent
        {
            public static void Postfix(InventoryNavigator __instance) 
            {
                if (__instance != null)
                {
                    var inventoryManager = __instance.gameObject.AddComponent<InventoryManager>();
                    inventoryManager.Title = __instance.transform.Find("Container/Title Bar/Title (Inventory)")?.gameObject;
                }
            }
        }
    }
}