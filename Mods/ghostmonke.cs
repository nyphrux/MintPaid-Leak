using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Unity;
using GorillaLocomotion;
using GorillaNetworking;
using GorillaGameModes;
using StupidTemplate.Classes;
using BepInEx;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;
using Player = GorillaLocomotion.GTPlayer;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Notifications;
using StupidTemplate.Patches;

namespace StupidTemplate.Mods
{
    internal class ghostmonke
    {
        public static bool ghost = false;
        public static bool ghost1 = false;
        public static bool Prefix(VRRig __instance)
        {
            return !(__instance == GorillaTagger.Instance.offlineVRRig);
        }
        public static void Ghost()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            bool Rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
            if (!ghost && Rp || Mouse.current.rightButton.isPressed)
            {
                ghost1 = !ghost1;
            }
            ghost = Rp || Mouse.current.rightButton.isPressed;
            if (ghost1)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                float h = (Time.frameCount / 180f) % 1f;
                 gameObject1.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject1.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                Object.Destroy(gameObject1.GetComponent<Rigidbody>());
                Object.Destroy(gameObject1.GetComponent<Collider>());
                Object.Destroy(gameObject1, Time.deltaTime);
                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));//free diddy
                gameObject2.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);//free diddy
                gameObject2.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;//free diddy
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());//free diddy
                Object.Destroy(gameObject2.GetComponent<Collider>());
                Object.Destroy(gameObject2, Time.deltaTime);
                Prefix(GorillaTagger.Instance.offlineVRRig);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }

    }
}
