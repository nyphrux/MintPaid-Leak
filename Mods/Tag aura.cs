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
    internal class Nebulas_tagaura
    {
        public static void TagAura()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        var distance = 7;
                        var vrrigBody = vrrig.transform.position;
                        var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                        var bdy = Vector3.Distance(vrrigBody, bdyc);
                        if (bdy <= distance)
                        {
                            rig = vrrig;
                            var ins = GorillaTagger.Instance.offlineVRRig;
                            ins.enabled = false;
                            ins.transform.position = vrrigBody + Vector3.up;
                            ins.rightHand.rigTarget.transform.position = vrrigBody;
                            ins.leftHand.rigTarget.transform.position = vrrigBody;
                            Player.Instance.rightControllerTransform.position = vrrigBody;
                        }
                        else
                        {
                            var ins = GorillaTagger.Instance.offlineVRRig;
                            ins.enabled = true;
                        }
                    }
                }
            }
        }

    }
}
