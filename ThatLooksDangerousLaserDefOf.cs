using RimWorld;
using Verse;
namespace ThatLooksDangerous
{
    [DefOf]
    public static class ThatLooksDangerousLaserDefOf
    {
        static ThatLooksDangerousLaserDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThatLooksDangerousLaserDefOf));
        }
        public static ThingDef DangerousWeapon_Laser;
    }
}