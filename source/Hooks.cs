using HarmonyLib;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;

namespace ezweededit
{
    public class Hooks
    {
        [HarmonyPatch(typeof(WeedPlant), nameof(WeedPlant.GetHarvestedProduct))]
        public static class WeedPlantPatch
        {
            static bool Prefix(WeedPlant __instance, ref ItemInstance __result, int quantity = 1)
            {
                GUI guiInstance = Core.Instance.GuiInstance;

                if (guiInstance != null)
                {
                    quantity = guiInstance.HarvestQuantity;
                    EQuality customQuality = (EQuality)guiInstance.QualityIndex;

                    QualityItemInstance qualityItemInstance =
                        __instance.BranchPrefab.Product.GetDefaultInstance(quantity) as QualityItemInstance;

                    if (qualityItemInstance != null)
                    {
                        qualityItemInstance.Quality = customQuality;
                        __result = qualityItemInstance;
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
