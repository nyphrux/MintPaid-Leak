using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Menu
{
    internal class Launchrockets
    {
        public static void LaunchRocket()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/RocketShip_IdleDummy").SetActive(false);
            ScheduledTimelinePlayer.FindObjectOfType<ScheduledTimelinePlayer>().timeline.Play();
        }
    }
}
