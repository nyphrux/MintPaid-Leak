using System;
using System.Collections.Generic;
using System.Text;

namespace AetherTemp.Menu
{
    internal class lockroom
    {
        public static void LockRoom()
        {
            var Dictionaryig = new Dictionary<byte, object>
                {
                    { 251, new ExitGames.Client.Photon.Hashtable { { 253, false } } },
                    { 250, true }
                };
            Photon.Pun.PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOperation(252, Dictionaryig, ExitGames.Client.Photon.SendOptions.SendReliable);
        
    }
            public static void UnlockRoom()
        {
            var dictionaryfrfr = new Dictionary<byte, object>
                {
                    { 251, new ExitGames.Client.Photon.Hashtable { { 253, false } } },
                    { 250, true }
                };
            Photon.Pun.PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOperation(252, dictionaryfrfr, ExitGames.Client.Photon.SendOptions.SendReliable);
        }
    }
    }
