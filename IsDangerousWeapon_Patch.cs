using HarmonyLib;
using RimWorld;
using Verse;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Verb), "TryStartCastOn")]
    public static class IsDangerousWeapon_Patch
    {
        static float maxWeaponRangeThreat = 40f;
        static void Postfix(Verb __instance, bool __result, LocalTargetInfo castTarg)
        {
            Pawn targetPawn = castTarg.Pawn;
            if(targetPawn == null || !targetPawn.IsColonist)
                return;

            float weaponRange = __instance.verbProps.range;
            bool isWeaponExplosive = __instance.verbProps.CausesExplosion;

            if(weaponRange >= maxWeaponRangeThreat || isWeaponExplosive)
            {
                bool hostilityCheck = __instance.caster.HostileTo(targetPawn);
                if (__result && hostilityCheck)
                {
                    Log.Message("[That Looks Dangerous] Aiming a dangerous weapon!");
                }
            }
        }
    }
}