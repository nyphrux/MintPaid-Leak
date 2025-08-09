using ExitGames.Client.Photon;
using GorillaTagScripts;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaGameModes;
using GorillaLocomotion;
using GorillaLocomotion.Gameplay;
using GorillaTagScripts;
using StupidTemplate.Classes;

using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;


using static StupidTemplate.Classes.rpcgetindexshit;
namespace AetherTemp.Menu
{
    internal class lagall
    {
        private static float _lagCooldown;
        public static void LagAll()
        {
            if (Time.time > _lagCooldown)
            {
                for (int i = 0; i < 50; i++)
                    PhotonNetwork.RaiseEvent(199, null, new RaiseEventOptions { Receivers = ReceiverGroup.Others }, SendOptions.SendReliable);
                _lagCooldown = Time.time + 0.3f;
            }
        }
    }
}
