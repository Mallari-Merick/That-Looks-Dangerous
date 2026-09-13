using HarmonyLib;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "StanceDraw")]
    public static class StanceDraw_Patch_laser
    {
        static void Postfix()
        {
            
        }
    }
}