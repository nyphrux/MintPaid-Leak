using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Legitcompspeedboost
    {

        public static bool oiwefkwenfjk;

        private static int speed;
        public static void MosaSpeed()
        {
            if (!Legitcompspeedboost.oiwefkwenfjk)
            {
                foreach (GorillaSurfaceOverride gorillaSurfaceOverride in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                {
                    if (Legitcompspeedboost.speed == 0)
                    {
                        gorillaSurfaceOverride.extraVelMaxMultiplier = 1.2f;
                        gorillaSurfaceOverride.extraVelMultiplier = 1.1f;
                    }
                }
            }
        }
    }
}
