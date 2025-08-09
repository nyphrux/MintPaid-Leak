using System;
using System.IO;
using StupidTemplate.Notifications;
using UnityEngine;

namespace AetherTemp.Mods
{
    internal class ButtonTapChanger
    {
        public static int[] soundIDs = new int[] { 169, 66, 4, 23, 32, 241, 131, 8, 84, 189, 106 };

        public static string[] soundNames = new string[] { "creamy", "Keyboard", "pillow", "Crystal", "Snow", "Pumpkin", "Globe", "wood", "bubble", "wall", "jar" };

        
        public static int currentIndex = 0;


        public static int CurrentSoundID => soundIDs[currentIndex];

 
        public static string CurrentSoundName => soundNames[currentIndex];


        public static void NextSound()
        {
            currentIndex = (currentIndex + 1) % soundIDs.Length;
        }

       
        public static void PlayTap(bool rightHanded)
        {
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(CurrentSoundID, rightHanded, 1f);
        }
    }
}
