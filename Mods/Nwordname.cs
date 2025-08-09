using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using UnityEngine;

namespace AetherTemp.Mods
{
    internal class Nwordname
    {
        public static void Nword()
        {
            PlayerPrefs.SetString("playerName", "NIGGA");
            PhotonNetwork.NickName = PlayerPrefs.GetString("playerName", "NIGGA");
        }


    }
}
