using HarmonyLib;
namespace ThatLooksDangerous
{
    public static class ThatLooksDangerousMod
    {
        static ThatLooksDangerousMod()
        {
            var harmony = new Harmony("mercs.thatlooksdangerous");
            harmony.PatchAll();
        }
    }
    
}

