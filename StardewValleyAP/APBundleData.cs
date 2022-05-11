using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewValleyAP
{
    public class APBundleData : Dictionary<int, APBundle>
    {
        public const int AREA_Pantry = 0;
        public const int AREA_CraftsRoom = 1;
        public const int AREA_FishTank = 2;
        public const int AREA_BoilerRoom = 3;
        public const int AREA_Vault = 4;
        public const int AREA_Bulletin = 5;
        public const int AREA_AbandonedJojaMart = 6;
        public const int AREA_Bulletin2 = 7;
        public const int AREA_JunimoHut = 8;

        private IMonitor Monitor;

        //default constructor can be standard bundles.
        public APBundleData(IMonitor monitor, IModHelper helper )
        {
            this.Monitor = monitor;
            Add(0,  new APBundle(monitor, helper, AREA_Pantry,      0,  "Pantry 1"));
            Add(1,  new APBundle(monitor, helper, AREA_Pantry,      1,  "Pantry 2"));
            Add(2,  new APBundle(monitor, helper, AREA_Pantry,      2,  "Pantry 3"));
            Add(3,  new APBundle(monitor, helper, AREA_Pantry,      3,  "Pantry 4"));
            Add(4,  new APBundle(monitor, helper, AREA_Pantry,      4,  "Pantry 5"));
            Add(5,  new APBundle(monitor, helper, AREA_Pantry,      5,  "Pantry 6"));
            Add(6,  new APBundle(monitor, helper, AREA_FishTank,    6,  "Fish Tank 1"));
            Add(7,  new APBundle(monitor, helper, AREA_FishTank,    7,  "Fish Tank 2"));
            Add(8,  new APBundle(monitor, helper, AREA_FishTank,    8,  "Fish Tank 3"));
            Add(9,  new APBundle(monitor, helper, AREA_FishTank,    9,  "Fish Tank 4"));
            Add(10, new APBundle(monitor, helper, AREA_FishTank,    10, "Fish Tank 5"));
            Add(11, new APBundle(monitor, helper, AREA_FishTank,    11, "Fish Tank 6"));
            Add(13, new APBundle(monitor, helper, AREA_CraftsRoom,  13, "Crafts Room 1"));
            Add(14, new APBundle(monitor, helper, AREA_CraftsRoom,  14, "Crafts Room 2"));
            Add(15, new APBundle(monitor, helper, AREA_CraftsRoom,  15, "Crafts Room 3"));
            Add(16, new APBundle(monitor, helper, AREA_CraftsRoom,  16, "Crafts Room 4"));
            Add(17, new APBundle(monitor, helper, AREA_CraftsRoom,  17, "Crafts Room 5"));
            Add(18, new APBundle(monitor, helper, AREA_CraftsRoom,  19, "Crafts Room 6"));
            Add(20, new APBundle(monitor, helper, AREA_BoilerRoom,  20, "Boiler Room 1"));
            Add(21, new APBundle(monitor, helper, AREA_BoilerRoom,  21, "Boiler Room 2"));
            Add(22, new APBundle(monitor, helper, AREA_BoilerRoom,  22, "Boiler Room 3"));
            Add(23, new APBundle(monitor, helper, AREA_Vault,       23, "Vault 1"));
            Add(24, new APBundle(monitor, helper, AREA_Vault,       24, "Vault 2"));
            Add(25, new APBundle(monitor, helper, AREA_Vault,       25, "Vault 3"));
            Add(26, new APBundle(monitor, helper, AREA_Vault,       26, "Vault 4"));
            Add(31, new APBundle(monitor, helper, AREA_Bulletin,    31, "Bulletin Board 1"));
            Add(32, new APBundle(monitor, helper, AREA_Bulletin,    32, "Bulletin Board 2"));
            Add(33, new APBundle(monitor, helper, AREA_Bulletin,    33, "Bulletin Board 3"));
            Add(34, new APBundle(monitor, helper, AREA_Bulletin,    34, "Bulletin Board 4"));
            Add(35, new APBundle(monitor, helper, AREA_Bulletin,    35, "Bulletin Board 5"));
            Add(36, new APBundle(monitor, helper, AREA_AbandonedJojaMart, 36, "Abandoned Joja Mart 0"));
        }

        public List<int> doAllChecks()
        {
            List<int> output = new List<int>();
            foreach (APBundle bundle in Values)
            {
                if (bundle.check())//this also changes the check
                {
                    //if check() is true, then that means the value actually changed, and needs to be sent to the server
                    output.Add(bundle.BundleIndex);
                }
            }
            return output;
        }
    }
}
