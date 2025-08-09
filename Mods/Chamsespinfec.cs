using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;
using UnityEngine;
using Unity;
using static StupidTemplate.Menu.Main;
using UnityEngine.UI;
using TMPro;
using Object = UnityEngine.Object;
using System.Net;
using StupidTemplate.Classes;
using Photon.Pun;
using GorillaNetworking;
using StupidTemplate.Notifications;
using System.IO;
using StupidTemplate.Menu;
using Player = GorillaLocomotion.GTPlayer;
using HarmonyLib;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    internal class box_esp
    {
        private static int espcolor;
        private static bool boxesp = false;

        public static void ESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && vrrig.mainSkin.material.name.Contains("fected"))
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    if (box_esp.espcolor == 0)
                    {
                        vrrig.mainSkin.material.color = new Color(9f, 0f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
                else if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    if (box_esp.espcolor == 0)
                    {
                        vrrig.mainSkin.material.color = new Color(0f, 9f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
            }
            box_esp.boxesp = true;
        }
    }
}

