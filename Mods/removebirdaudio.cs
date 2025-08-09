using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Menu
{
    internal class removebirdaudio
    {
        public static void DisableBirdAudio()
        {
            GameObject birds = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/AudioBirds");

            if (birds != null)
            {
                birds.SetActive(false);
                Debug.Log("[NEBULAS] Bird audio disabled.");
            }
            else
            {
                Debug.LogWarning("Bird audio GameObject not found.");
            }
        }

    }
}
