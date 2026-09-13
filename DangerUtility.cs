using RimWorld;
using Verse;
namespace ThatLooksDangerous
{
    public static class DangerUtility
    {
        static float maxWeaponRangeThreat = 40f;

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
    }
}