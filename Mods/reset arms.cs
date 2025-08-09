using System;
using System.Collections.Generic;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class reset_arms
    {
        public static void NormalArms()
        {
            GorillaLocomotion.GTPlayer.Instance.transform.localScale = new UnityEngine.Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
