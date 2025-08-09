using System;
using System.Collections.Generic;
using UnityEngine;
using GorillaNetworking;
using StupidTemplate.Classes;

namespace StupidTemplate.Mods
{
    internal class disable_chams
    {
        public static void DisableAllChams()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    if (vrrig.mainSkin != null && vrrig.mainSkin.material != null)
                    {
                        vrrig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                        vrrig.mainSkin.material.color = vrrig.playerColor;
                    }
                }
            }
        }
    }
}
