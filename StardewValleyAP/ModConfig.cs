using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardewValleyAP
{
    public class ModConfig
    {
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string ServerPassword { get; set; }
        public string SlotName { get; set; }

        public ModConfig()
        {
            ServerIP = "Archipelago.gg";
            ServerPort = "38281";
            ServerPassword = "";
            SlotName = "";
        }
    }
}
