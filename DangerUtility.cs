using System.Collections.Generic;
using RimWorld;
using Verse;
// using Verse.Sound;
namespace ThatLooksDangerous
{
    public static class DangerUtility
    {
        static float maxWeaponRangeThreat = 40f;
        // public static readonly Dictionary<Stance_Warmup, Sustainer> soundFX = new Dictionary<Stance_Warmup, Sustainer>();
        // Commented out, because this is required for a sustainer function.
        public static readonly Dictionary<Stance_Warmup, MoteDualAttached> laserFX = new Dictionary<Stance_Warmup, MoteDualAttached>();

        public static bool IsDangerousStance(Stance_Warmup stance)
        {
            Pawn targetPawn = stance.focusTarg.Thing as Pawn;
            Verb verb = stance.verb;

            if(targetPawn == null || !targetPawn.IsColonist)
                return false;

            float weaponRange = verb.verbProps.range;
            bool isWeaponExplosive = verb.verbProps.CausesExplosion;

            if(weaponRange >= maxWeaponRangeThreat || isWeaponExplosive)
            {
                bool hostilityCheck = verb.caster.HostileTo(targetPawn);
                if(hostilityCheck)
                {
                    return true;
                }
            }
            return false;
        }
        public static void CleanupLaser(Stance_Warmup stance)
        {
            if(!laserFX.TryGetValue(stance, out MoteDualAttached mote))
                return;
            mote.Destroy(DestroyMode.Vanish);
            laserFX.Remove(stance);
        }
    }
}