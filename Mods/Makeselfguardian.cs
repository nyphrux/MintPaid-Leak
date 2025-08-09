using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using StupidTemplate.Notifications;

namespace StupidTemplate.Mods
{
    internal class Makeselfguardian
    {
        public static void SetGuardianTarget(NetPlayer target)
        {
            if (!NetworkSystem.Instance.IsMasterClient) { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); return; }
            foreach (GorillaGuardianZoneManager zoneManager in GorillaGuardianZoneManager.zoneManagers)
            {
                if (zoneManager.enabled)
                    zoneManager.SetGuardian(NetworkSystem.Instance.LocalPlayer);
            }
        }
        public static void GuardianSelf() =>
        SetGuardianTarget(PhotonNetwork.LocalPlayer);
    }
}
