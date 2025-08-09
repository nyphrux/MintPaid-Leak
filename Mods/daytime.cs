using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class daytime
    {

        public static void DayTime()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }
    }
}
