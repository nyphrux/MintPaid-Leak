using Photon.Pun;
using StupidTemplate.Notifications;
using UnityEngine;

namespace AetherTemp.Menu
{
    internal class RPCBypass
    {
        private static int originalRpcErrorMax;
        private static int originalRpcCallLimit;
        private static int originalLogErrorMax;
        private static int originalMaxResends;
        private static int originalQuickResends;

        private static bool isBackedUp = false;

        public static void EnableNoLimitRPCs()
        {
            try
            {
                if (!isBackedUp)
                {
                    originalRpcErrorMax = GorillaNot.instance.rpcErrorMax;
                    originalRpcCallLimit = GorillaNot.instance.rpcCallLimit;
                    originalLogErrorMax = GorillaNot.instance.logErrorMax;
                    originalMaxResends = PhotonNetwork.MaxResendsBeforeDisconnect;
                    originalQuickResends = PhotonNetwork.QuickResends;
                    isBackedUp = true;
                }

                GorillaNot.instance.rpcErrorMax = int.MaxValue;
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                GorillaNot.instance.logErrorMax = int.MaxValue;

                PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                PhotonNetwork.QuickResends = int.MaxValue;

                PhotonNetwork.SendAllOutgoingCommands();

                NotifiLib.SendNotification("Anti RPC Auto Report, Kick, and Call Limit Increments Raised");
            }
            catch { }
        }

        public static void Resetrpcbypasser()
        {
            try
            {
                if (!isBackedUp) return; 

                GorillaNot.instance.rpcErrorMax = originalRpcErrorMax;
                GorillaNot.instance.rpcCallLimit = originalRpcCallLimit;
                GorillaNot.instance.logErrorMax = originalLogErrorMax;

                PhotonNetwork.MaxResendsBeforeDisconnect = originalMaxResends;
                PhotonNetwork.QuickResends = originalQuickResends;

                PhotonNetwork.SendAllOutgoingCommands();

                NotifiLib.SendNotification("RPC settings restored to default.");
            }
            catch { }
        }
    }
}
