using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "StanceTick")]
    public static class StanceTick_Patch
    {
        public static void Postfix(Stance_Warmup __instance)
        {
            if(!DangerUtility.laserFX.TryGetValue(__instance, out MoteDualAttached mote))
                return;
            
            mote.Maintain();
        }
    }
}