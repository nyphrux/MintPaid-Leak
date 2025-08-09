using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GorillaLocomotion;
using GorillaTagScripts;
using Photon.Pun;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class IncreasingSpeedBoost
    {
        public static float jspeed = 7.5f;
        public static bool FactoredSpeedBoostEnabled = true;
        public static bool DisableMaxSpeedModificationEnabled = false;
        public static float jmulti = 1.1f;
        public static bool PlayerIsTagged(VRRig Player)
        {
            List<NetPlayer> infectedPlayers = InfectedList();
            NetPlayer targetPlayer = GetPlayerFromVRRig(Player);

            return infectedPlayers.Contains(targetPlayer);
        }
        public static List<NetPlayer> InfectedList()
        {
            List<NetPlayer> infected = new List<NetPlayer> { };

            if (!PhotonNetwork.InRoom)
                return infected;

            switch (GorillaGameManager.instance.GameType())
            {
                case GorillaGameModes.GameModeType.Infection:
                case GorillaGameModes.GameModeType.InfectionCompetitive:
                case GorillaGameModes.GameModeType.FreezeTag:
                case GorillaGameModes.GameModeType.PropHunt:
                    GorillaTagManager tagManager = (GorillaTagManager)GorillaGameManager.instance;
                    if (tagManager.isCurrentlyTag)
                        infected.Add(tagManager.currentIt);
                    else
                        infected.AddRange(tagManager.currentInfected);
                    break;
                case GorillaGameModes.GameModeType.Ghost:
                case GorillaGameModes.GameModeType.Ambush:
                    GorillaAmbushManager ghostManager = (GorillaAmbushManager)GorillaGameManager.instance;
                    if (ghostManager.isCurrentlyTag)
                        infected.Add(ghostManager.currentIt);
                    else
                        infected.AddRange(ghostManager.currentInfected);
                    break;
            }

            return infected;
        }

        public static NetPlayer GetPlayerFromVRRig(VRRig p) =>
        p.Creator;





        public static void DynamicSpeedBoost()
        {
            bool isTagged = PlayerIsTagged(VRRig.LocalRig);

            VRRig closestRig = GorillaParent.instance.vrrigs
                .Where(rig => rig != null && rig != VRRig.LocalRig &&
                                  (isTagged ? !PlayerIsTagged(rig) : PlayerIsTagged(rig)))
                .OrderBy(rig => Vector3.Distance(rig.transform.position, GorillaTagger.Instance.bodyCollider.transform.position))
                .FirstOrDefault();

            float rigDistance = closestRig == null ? float.MaxValue :
                         Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, closestRig.transform.position);

            if (rigDistance < 15f)
            {
                float jspt = jspeed;
                float jmpt = jmulti;

                if (FactoredSpeedBoostEnabled)
                {
                    jspt = (jspt / 6.5f) * GTPlayer.Instance.maxJumpSpeed;
                    jmpt = (jmpt / 1.1f) * GTPlayer.Instance.jumpMultiplier;
                }

                jspt = Mathf.Lerp(GTPlayer.Instance.maxJumpSpeed, jspt, Mathf.Clamp(rigDistance, 1f, 15f) / 15f);
                jmpt = Mathf.Lerp(GTPlayer.Instance.jumpMultiplier, jmpt, Mathf.Clamp(rigDistance, 1f, 15f) / 15f);

                if (!DisableMaxSpeedModificationEnabled)
                    GTPlayer.Instance.maxJumpSpeed = jspeed;

                GTPlayer.Instance.jumpMultiplier = jmulti;
            }
        }

    }
}
    