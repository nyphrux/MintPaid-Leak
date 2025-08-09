using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GorillaNetworking;
using StupidTemplate.Classes;

namespace StupidTemplate.Mods
{
    internal class rgbchams
    {
        private static bool espEnabled = false;

        public static void Rgbchamsfr()
        {
            float speed = 2f;
            float t = Time.time * speed;

            Color rgbColor = new Color(
                Mathf.Sin(t) * 0.5f + 0.5f,
                Mathf.Sin(t + 2f) * 0.5f + 0.5f,
                Mathf.Sin(t + 4f) * 0.5f + 0.5f,
                0.5f
            );

            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                {
                    vrrig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    vrrig.mainSkin.material.color = rgbColor;
                }
            }

            espEnabled = true;
        }
    }
    }
