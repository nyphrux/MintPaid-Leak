using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using BepInEx;
using ExitGames.Client.Photon;
using GorillaLocomotion;
using GorillaLocomotion.Climbing;
using GorillaLocomotion.Swimming;


using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using TagEffects;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


namespace StupidTemplate.Mods
{
    internal class strongwallwalk
    {
        public static void ZeroGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static Vector3 walkPos;
        public static bool rightGrab = false;
        public static Vector3 walkNormal;
        public static void StrongWallWalk()
        {
            if (GTPlayer.Instance.IsHandTouching(true) || GTPlayer.Instance.IsHandTouching(false))
            {
        
            }

            if (walkPos != Vector3.zero && rightGrab)
            {
                GorillaTagger.Instance.rigidbody.AddForce(walkNormal * -50f, ForceMode.Acceleration);
                ZeroGravity();
            }
        }
    }
}
