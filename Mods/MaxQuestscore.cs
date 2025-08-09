using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Mods
{
    internal class MaxQuestscore
    {
        private static float Delay = 0f;
        public static void MaxQuestScore()
        {
            if (Time.time > Delay)
            {
                Delay = Time.time + 1f;
                VRRig.LocalRig.SetQuestScore(int.MaxValue);
            }
        }
    }
}
