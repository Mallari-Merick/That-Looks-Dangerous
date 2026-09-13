using HarmonyLib;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "InitEffects")]
    public static class InitEffects_Patch
    {
        public static void Postfix()
        {
            
        }
    }
}