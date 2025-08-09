using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class boneesp
    {
        public static int[] bones = new int[] {
            4, 3, 5, 4, 19, 18, 20, 19, 3, 18, 21, 20, 22, 21, 25, 21, 29, 21, 31, 29, 27, 25, 24, 22, 6, 5, 7, 6, 10, 6, 14, 6, 16, 14, 12, 10, 9, 7
        };
        public static void bone()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig == null) continue;

                UnityEngine.Color thecolor = vrrig.playerColor;

                // Head line so i dont forget ig
                LineRenderer liner = vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                liner.startWidth = 0.025f;
                liner.endWidth = 0.025f;
                liner.startColor = thecolor;
                liner.endColor = thecolor;
                liner.material.shader = Shader.Find("GUI/Text Shader");
                liner.SetPosition(0, vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f));
                liner.SetPosition(1, vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));
                UnityEngine.Object.Destroy(liner, Time.deltaTime);

                // Bones lines
                for (int i = 0; i < bones.Length; i += 2)
                {
                    liner = vrrig.mainSkin.bones[bones[i]].gameObject.AddComponent<LineRenderer>();
                    liner.startWidth = 0.025f;
                    liner.endWidth = 0.025f;
                    liner.startColor = thecolor;
                    liner.endColor = thecolor;
                    liner.material.shader = Shader.Find("GUI/Text Shader");
                    liner.SetPosition(0, vrrig.mainSkin.bones[bones[i]].position);
                    liner.SetPosition(1, vrrig.mainSkin.bones[bones[i + 1]].position);
                    UnityEngine.Object.Destroy(liner, Time.deltaTime);
                }
            }
        }

    }
}
        