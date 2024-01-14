using UnityEngine;

namespace KnowEncumbrance.Components
{
    public class EncumbranceManager : MonoBehaviour
    {
        public static bool Active = false;
        public static EncumbranceManager Instance => _instance; 
        
        private int previousSlotCount;
        private static EncumbranceManager _instance;
        public Player PlayerController; 

        public void Awake()
        {
            _instance = this;
            KnowEncumbrance.Log.LogDebug($"EncumbranceComponent Added");
            Active = true;
        }

        public void Start()
        {
            var consolidatedSlotCount = Player.instance.inventory.myInv.numConsolidatedSlots;
            var maxConsolidatedSlotCount = GameState.instance.nonEncumberedSlotsCount;
            KnowEncumbrance.Log.LogDebug($"Player Encumbrance: Current Slot Count: {consolidatedSlotCount} / Max Slot Count: {maxConsolidatedSlotCount}");
            previousSlotCount = consolidatedSlotCount;
            InvokeRepeating(nameof(UpdateEncumbrance),0.0f,0.4f);
        }

        private void UpdateEncumbrance()
        {
            if (EncumbranceChanged())
            {
                var consolidatedSlotCount = Player.instance.inventory.myInv.numConsolidatedSlots;
                var maxConsolidatedSlotCount = GameState.instance.nonEncumberedSlotsCount;
                KnowEncumbrance.Log.LogDebug($"Player Encumbrance Changed: Current Slot Count: {consolidatedSlotCount} / Max Slot Count: {maxConsolidatedSlotCount}");
            }
        }

        private bool EncumbranceChanged()
        {
            if (Player.instance.inventory.myInv.numConsolidatedSlots == previousSlotCount) 
                return false;
            
            previousSlotCount = Player.instance.inventory.myInv.numConsolidatedSlots;
            return true;

        }

        public string GetCurrentEncumbrance()
        {
            return $"{Player.instance.inventory.myInv.numConsolidatedSlots}/{GameState.instance.nonEncumberedSlotsCount}";
        }

        public bool IsEncumbered()
        {
            return Player.instance.inventory.myInv.numConsolidatedSlots > GameState.instance.nonEncumberedSlotsCount;
        }
    }
}