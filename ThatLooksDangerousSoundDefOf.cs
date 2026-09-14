using RimWorld;
using Verse;

namespace ThatLooksDangerous
{
    [DefOf]
    public static class ThatLooksDangerousSoundDefOf
    {
        static ThatLooksDangerousSoundDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThatLooksDangerousSoundDefOf));
        }
        public static SoundDef DangerousWeapon_Aiming;
    }
    
}