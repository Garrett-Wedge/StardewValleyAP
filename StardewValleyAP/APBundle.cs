using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace StardewValleyAP
{
    public class APBundle
    {
        IMonitor Monitor;
        IModHelper helper;
        public int RoomID { get; set; }
        public int BundleIndex { get; set; }

        private string name { get; set; }
        private bool isCompleted { get; set; }

        public APBundle( IMonitor monitor, IModHelper modHelper, int setRoomID, int setBundleIndex, string setName )
        {
            Monitor = monitor;
            helper = modHelper;
            RoomID = setRoomID;
            BundleIndex = setBundleIndex;
            name = setName;
            isCompleted = false;
        }

        public bool check()
        {
            try
            {
                Game1 gameInfo = new Game1();
                var bundleCompletion = true;
                //TODO this works perfectly on all bundles except vault, gotta find an alternative
                foreach(bool b in Game1.netWorldState.Value.Bundles[BundleIndex] )
                {
                    if ( b & RoomID == 4)
                    {//vault bundles behave differently, this should allow them to detect properly
                        break;
                    }
                    if (!b)
                    {
                        bundleCompletion = false;
                        break;
                    }
                }
                if (!isCompleted & bundleCompletion )//if our internal structure says it's not done but we can see that it is done
                    {
                    isCompleted = true;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Monitor.Log($"Failed in {nameof(check)}:\n{e}", LogLevel.Error);
                return false;
            }
        }

    }
}
