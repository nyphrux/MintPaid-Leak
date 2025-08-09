using System.Collections;
using BepInEx;
using GorillaLocomotion;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;
using static StupidTemplate.Classes.rpcgetindexshit;

namespace StupidTemplate.Mods
{
    internal class TeleportMods : MonoBehaviour
    {
        private static GameObject playerRig => GorillaLocomotion.GTPlayer.Instance.gameObject;
        private static bool isTeleporting = false;



        private static TeleportMods _instance;

        public static void tptomountains()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                GTPlayer.Instance.transform.position = new Vector3(-15.42047f, 16.43979f, -109.9514f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void Tptolouds()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                GTPlayer.Instance.transform.position = new Vector3(-75.48952f, 161.1079f, -97.0518f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void tptostumps()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                GTPlayer.Instance.transform.position = new Vector3(-66.27626f, 10.41657f, -83.09951f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void TpToTut()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                GTPlayer.Instance.transform.position = new Vector3(-81.53886f, 34.88655f, -66.2029f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }


        public static void TpToCity()
        {

            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                GTPlayer.Instance.transform.position = new Vector3(-52.66594f, 15.042f, -108.0526f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        private static TeleportMods Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject("TeleportMods");
                    _instance = obj.AddComponent<TeleportMods>();
                    Object.DontDestroyOnLoad(obj);
                }
                return _instance;
            }
        }
        public static bool noclip;

        public static void UpdateClipColliders(bool enabled)
        {
            foreach (MeshCollider v in Resources.FindObjectsOfTypeAll<MeshCollider>())
                v.enabled = enabled;
        }

        public static void Noclip()
        {
            if (!noclip)
            {
                noclip = true;
                UpdateClipColliders(false);
            }
            else
            {
                noclip = false;
                UpdateClipColliders(true);
            }
        }
        public static void disablenoclip()
        {
            noclip = false;
            UpdateClipColliders(true);
        }

      // You must assign this with your rig prefab somewhere

        private static void TeleportTo(Vector3 destination)
        {
            if (isTeleporting || playerRig == null) return;
            isTeleporting = true;

            var offlineVRRig = GorillaTagger.Instance.offlineVRRig;
            if (offlineVRRig != null)
            {
                offlineVRRig.enabled = false; // Disable rig

                // Update position without moving the whole rig transform hierarchy unnecessarily
                GorillaLocomotion.GTPlayer.Instance.transform.position = destination;

                offlineVRRig.enabled = true; // Re-enable rig
            }

            isTeleporting = false;
        }


      

        private void ReEnableRig()
        {
            if (playerRig != null)
                GorillaTagger.Instance.offlineVRRig.enabled = true;

            isTeleporting = false;
        }
    }
}
