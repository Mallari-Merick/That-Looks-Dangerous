using HarmonyLib;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "Interrupt")]
    public static class Interrupt_Patch
    {
        public static void Postfix(Stance_Warmup __instance)
        {
            DangerUtility.CleanupLaser(__instance);
        }
    }
}