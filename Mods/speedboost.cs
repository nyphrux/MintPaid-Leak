using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class speedboost
    {
        public static void SpeedBoostMod()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 7f;
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 7f;
        }
    }
    }

