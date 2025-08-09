using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class set_rain
    {
        public static void MakeRain()
        {
            for (int i2 = 1; i2 < BetterDayNightManager.instance.weatherCycle.Length; i2++)
            {
                BetterDayNightManager.instance.weatherCycle[i2] = BetterDayNightManager.WeatherType.Raining;
            }
        }
    }
}
