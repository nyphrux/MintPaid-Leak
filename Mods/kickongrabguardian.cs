using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class kickongrabguardian
    {
        public static void KickOnGrab()
        {
            VRRig.LocalRig.enabled = true;
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isLocal) /*&& rig.transform.position.x < 80)*/
                {
                    if (rig.leftHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer || rig.rightHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        VRRig.LocalRig.enabled = false;
                        VRRig.LocalRig.transform.position = new Vector3(-71.33718f, 101.4977f, -93.09029f);
                        VRRig.LocalRig.leftHand.rigTarget.transform.position = VRRig.LocalRig.transform.position;
                        VRRig.LocalRig.rightHand.rigTarget.transform.position = VRRig.LocalRig.transform.position;
                    }
                }
            }
        }
    }
}
