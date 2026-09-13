using HarmonyLib;
using Verse;
namespace ThatLooksDangerous
{
    [StaticConstructorOnStartup]
    public static class ThatLooksDangerousMod
    {
        static ThatLooksDangerousMod()
        {
            var harmony = new Harmony("mercs.thatlooksdangerous");
            harmony.PatchAll();
            Log.Message("[ThatLooksDangerous] Constructor running!");
        }
    }
    
}

