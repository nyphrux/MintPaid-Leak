using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;
using Unity;
using UnityEngine;
using BepInEx;
using UnityEngine.InputSystem;
using Photon.Pun;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;

using StupidTemplate.Patches;
using Player = GorillaLocomotion.GTPlayer;
namespace StupidTemplate.Mods
{
    internal class nebula
    {
        public static void antitag()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float num;
            VRRig vrrig2 = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    if (vrrig.mainSkin.material.name.Contains("fected") || vrrig.mainSkin.material.name.Contains("it") || !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        if (Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position) < 5)
                        {
                            num = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position);
                            vrrig2 = vrrig;
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = -100;
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = -0;
                        }
                    }
                }
            }
        }
    }
}
