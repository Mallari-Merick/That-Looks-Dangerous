using UnityEngine;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.Sound;

namespace ThatLooksDangerous
{
    [HarmonyPatch(typeof(Stance_Warmup), "InitEffects")]
    public static class InitEffects_Patch
    {
        // public static void Postfix(Stance_Warmup __instance)
        // {
        //     if (DangerUtility.IsDangerousStance(__instance))
        //     {
        //         SoundInfo info = SoundInfo.InMap(__instance.verb.caster, MaintenanceType.PerTick);
        //         if(__instance.verb.CasterIsPawn)
        //             info.pitchFactor = 1f / __instance.verb.CasterPawn.GetStatValue(StatDefOf.AimingDelayFactor, true, 1);

        //         DangerUtility.soundFX[__instance] = __instance.verb.verbProps.soundAiming.TrySpawnSustainer(info);
        //     }
        // } This is a sustainer logic, sustainer is going to be ongoing work.
        private static void CheckForDangerSFX(Stance_Warmup __instance)
        {
            if (DangerUtility.IsDangerousStance(__instance))
            {
                SoundInfo info = SoundInfo.InMap(__instance.verb.caster, MaintenanceType.PerTick);
                if (__instance.verb.CasterIsPawn)
                    info.pitchFactor = 1f / __instance.verb.CasterPawn.GetStatValue(StatDefOf.AimingDelayFactor, true, 1);

                ThatLooksDangerousSoundDefOf.DangerousWeapon_Aiming.PlayOneShot(info);
            }
        }
        public static void Postfix(Stance_Warmup __instance)
        {
            CheckForDangerSFX(__instance);
            
            VerbProperties verbProp = __instance.verb.verbProps;
            LocalTargetInfo focusTarg = __instance.focusTarg;

            // MoteMaker.MakeInteractionOverlay(verbProp.aimingLineMote, __instance.verb.Caster, new TargetInfo(focusTarg.ToTargetInfo()));
        }
    }
}