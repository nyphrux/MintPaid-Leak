using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace AetherTemp.Menu
{
    internal class destroyall
    {
        public static void DestroyPlayer(NetPlayer player) =>
      PhotonNetwork.OpRemoveCompleteCacheOfPlayer(player.ActorNumber);

        public static void DestroyAll()
        {
            foreach (Player player in PhotonNetwork.PlayerListOthers)
                DestroyPlayer(player);
        }
    }
}
