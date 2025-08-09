using StupidTemplate.Patches;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    internal class tagself
    {
        public static void TagSelf()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.rightButton.isPressed)
                {
                    if (vrrig.mainSkin.material.name.Contains("fected") && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }
    }
}
