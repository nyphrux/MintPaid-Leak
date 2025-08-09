using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Classes
{
    internal class rpcgetindexshit

    {
        public static bool leftgrip;
        public static bool rightgrip;
        
        public static float cooldown;
        public static bool leftPrimary;
        public static bool leftSecondary;
        public static bool rightPrimary;
        public static bool rightSecondary;

        public static float leftTrigger;
        public static float rightTrigger;
        public static Vector3 World2Player(Vector3 world) =>
         world - GorillaTagger.Instance.bodyCollider.transform.position + GorillaTagger.Instance.transform.position;

        public static bool cooldownformultiframes;
        public static bool disableoverlapingrpcs = true;
        private static Dictionary<string, GameObject> objectPool = new Dictionary<string, GameObject> { };
        public static GameObject GetObject(string find)
        {
            if (objectPool.TryGetValue(find, out GameObject go))
                return go;

            GameObject tgo = GameObject.Find(find);
            if (tgo != null)
                objectPool.Add(find, tgo);

            return tgo;
        }

        public static Vector3 RandomVector3(float range = 1f) =>
            new Vector3(UnityEngine.Random.Range(-range, range),
                        UnityEngine.Random.Range(-range, range),
                        UnityEngine.Random.Range(-range, range));

        public static Quaternion RandomQuaternion(float range = 360f) =>
            Quaternion.Euler(UnityEngine.Random.Range(0f, range),
                        UnityEngine.Random.Range(0f, range),
                        UnityEngine.Random.Range(0f, range));

        public static Color RandomColor(byte range = 255, byte alpha = 255) =>
            new Color32((byte)UnityEngine.Random.Range(0, range),
                        (byte)UnityEngine.Random.Range(0, range),
                        (byte)UnityEngine.Random.Range(0, range),
                        alpha);
        public static void flush() 
        {
            try
            {
                if (Somethingfrig)
                {
                    return;
                }
                Somethingfrig = true;
                RaiseEventOptions options = new RaiseEventOptions
                {
                    CachingOption = EventCaching.RemoveFromRoomCache,
                    TargetActors = new int[] { PhotonNetwork.LocalPlayer.ActorNumber }
                };
                PhotonNetwork.NetworkingClient.OpRaiseEvent(200, null, options, SendOptions.SendReliable);
                GorillaNot.instance.rpcErrorMax = int.MaxValue;
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                GorillaNot.instance.logErrorMax = int.MaxValue;
                PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                PhotonNetwork.QuickResends = int.MaxValue;
                PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
                PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
                PhotonView playerPhotonView = GorillaTagger.Instance.myVRRig.GetComponent<PhotonView>();
                if (playerPhotonView != null)
                {
                    if (playerPhotonView.Owner == null)
                    {
                        playerPhotonView.TransferOwnership(PhotonNetwork.LocalPlayer);
                    }
                    PhotonNetwork.OpCleanRpcBuffer(playerPhotonView);
                }
                PhotonNetwork.SendAllOutgoingCommands();
                GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaGameManager.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                try
                {
                    PhotonNetwork.NetworkingClient.EventReceived -= PhotonNetwork.NetworkingClient.OnEvent;
                    PhotonNetwork.NetworkingClient.EventReceived += (eventData) =>
                    {
                        if (eventData.Sender != PhotonNetwork.LocalPlayer.ActorNumber)
                        {
                            return;
                        }
                    };
                    PhotonNetwork.NetworkingClient.LoadBalancingPeer.LimitOfUnreliableCommands = 0;
                }
                catch (Exception ex)
                { }
                if (GorillaNot.instance != null)
                {
                    FieldInfo report = typeof(GorillaNot).GetField("sendReport", BindingFlags.NonPublic);
                    if (report != null)
                    {
                        report.SetValue(GorillaNot.instance, false);
                    }
                    report = typeof(GorillaNot).GetField("_sendReport", BindingFlags.NonPublic);
                    if (report != null)
                    {
                        report.SetValue(GorillaNot.instance, false);
                    }
                }
            }
            catch (Exception ex)
            { Debug.Log("{ERROR} : " + ex.Message); }
        }
        private static bool Somethingfrig = false;
      
    }
}
