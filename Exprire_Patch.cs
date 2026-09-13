using HarmonyLib;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "Expire")]
    public static class Expire_Patch
    {
        public static void Postfix()
        {
            Log.Message("[ThatLooksDangerous] Expire Postfix Success!");
        }
    }
}