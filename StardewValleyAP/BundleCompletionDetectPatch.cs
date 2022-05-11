using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using HarmonyLib;
using Microsoft.Xna.Framework;
using Archipelago.MultiClient.Net;

namespace StardewValleyAP
{
    public class BundleCompletionDetectPatch
    {
        private static int archipelagoOffset = 1984000;

        private static IMonitor Monitor;
        private static APBundleData bundles;
        private static ArchipelagoSession session;

        // call this method from your Entry class
        public static void Initialize(IMonitor monitor, APBundleData bundleData, ArchipelagoSession sesh)
        {
            Monitor = monitor;
            bundles = bundleData;
            session = sesh;
        }

        public static void Apply(Harmony harmony)
        {
            try
            {
                Monitor.Log("Adding Harmony postfix to completionAnimation() in Bundle.cs", LogLevel.Trace);
                harmony.Patch(
                    original: AccessTools.Method(typeof(StardewValley.Menus.Bundle), nameof(StardewValley.Menus.Bundle.completionAnimation), new Type[] { typeof(bool) }),
                    postfix: new HarmonyMethod(typeof(BundleCompletionDetectPatch), nameof(BundleCompletionDetectPatch.BundleCompletionDetectPatch_Postfix))
                );
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed to add postfix to completionAnimation() in Bundle.cs with exception: {ex}", LogLevel.Error);
            }
        }

        public static void BundleCompletionDetectPatch_Postfix()
        {
            try
            {
                List<int> completedBundles = bundles.doAllChecks();

                Monitor.Log($"These bundles were completed:", LogLevel.Debug);
                foreach(int b in completedBundles)
                {
                    session.Locations.CompleteLocationChecks(b + archipelagoOffset);
                    Monitor.Log($"Bundle {b}", LogLevel.Debug);
                } 

            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed in {nameof(BundleCompletionDetectPatch_Postfix)}:\n{ex}", LogLevel.Error);
            }
        }
    }
}
