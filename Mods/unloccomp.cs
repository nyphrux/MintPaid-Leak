using GorillaNetworking;
using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class unloccomp
    {
        public static void UnlockCompetitiveQueue()
        {
            GorillaComputer.instance.CompQueueUnlockButtonPress();
        }

    }
}
