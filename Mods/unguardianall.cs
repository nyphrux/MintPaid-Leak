using System;
using System.Collections.Generic;
using System.Text;
using StupidTemplate.Notifications;

namespace StupidTemplate.Mods
{
    internal class unguardianall
    {
        public static void UnguardianAll()
        {
            if (NetworkSystem.Instance.IsMasterClient)
            {
                foreach (GorillaGuardianZoneManager gorillaGuardianZoneManager in GorillaGuardianZoneManager.zoneManagers)
                {
                    if (gorillaGuardianZoneManager.enabled)
                        gorillaGuardianZoneManager.SetGuardian(null);
                }
            }
            else { NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master client.</color>"); }
        }

    }
}
