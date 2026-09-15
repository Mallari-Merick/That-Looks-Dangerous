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
        private static void CheckForDangerSFXOneShot(Stance_Warmup __instance)
        {
            // One-shot instead of sustainer sound.
            SoundInfo info = SoundInfo.InMap(__instance.verb.caster, MaintenanceType.PerTick);
            if (__instance.verb.CasterIsPawn)
                info.pitchFactor = 1f / __instance.verb.CasterPawn.GetStatValue(StatDefOf.AimingDelayFactor, true, 1);

            ThatLooksDangerousSoundDefOf.DangerousWeapon_Aiming.PlayOneShot(info);
        }
        private static void CheckForLaser(Stance_Warmup __instance)
        {
            Map map = __instance.verb.caster.Map;
            LocalTargetInfo focusTarg = __instance.focusTarg;
            TargetInfo target = focusTarg.ToTargetInfo(map);

            ThingDef laserMoteDef = ThatLooksDangerousLaserDefOf.DangerousWeapon_Laser;

            MoteDualAttached storedLaser = MoteMaker.MakeInteractionOverlay(laserMoteDef, __instance.verb.Caster, target);
            DangerUtility.laserFX.Add(__instance, storedLaser);
        }
        public static void Postfix(Stance_Warmup __instance)
        {
            if (!DangerUtility.IsDangerousStance(__instance))
                return;

            CheckForDangerSFXOneShot(__instance);
            CheckForLaser(__instance);
        }

    }
}