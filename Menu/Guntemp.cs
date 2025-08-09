using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using StupidTemplate.Notifications;
using ExitGames.Client.Photon;
using HarmonyLib;
using UnityEngine.Animations.Rigging;
using AetherTemp.Menu;
using System.Text.RegularExpressions;
using StupidTemplate.Patches;
using System.Reflection;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Buffers.Text;
using GorillaTagScripts;
using POpusCodec.Enums;
using static KeyAuth.api;

namespace StupidTemplate.Menu
{
    class Mutegun
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void placeholder()
        {

        }
     
        private static float delay3;
        public static GameObject GunSphere;
        private static LineRenderer lineRenderer;
        private static float timeCounter = 0f;
        private static Vector3[] linePositions;
        private static Vector3 previousControllerPosition;

        public static float num = 10f;

        public static void GunSmoothNess()
        {
            if (num == 10f)
                num = 15f;  // Super smooth (slower)
            else if (num == 15f)
                num = 5f;   // Fast (no smoothness)
            else
                num = 10f;  // Normal smoothness
        }

        // List of colors to cycle through
        public static List<(Color color, string name)> colorCycle = new List<(Color, string)>
{
    (new Color(189f / 255f, 251f / 255f, 204f / 255f), "mint"),
    (new Color(255f / 255f, 229f / 255f, 180f / 255f), "peach"),
    (new Color(134f / 255f, 169f / 255f, 188f / 255f), "dustyBlue"),
    (new Color(200f / 255f, 162f / 255f, 200f / 255f), "lilac"),
    (new Color(255f / 255f, 255f / 255f, 204f / 255f), "paleYellow"),
    (new Color(255f / 255f, 182f / 255f, 193f / 255f), "softPink"),
    (new Color(230f / 255f, 230f / 255f, 250f / 255f), "lavender"),
    (new Color(211f / 255f, 211f / 255f, 211f / 255f), "lightGray"),
    (new Color(169f / 255f, 169f / 255f, 169f / 255f), "warmGray"),
    (new Color(255f / 255f, 255f / 255f, 240f / 255f), "ivory"),
    (new Color(245f / 255f, 240f / 255f, 195f / 255f), "beige"),
    (new Color(128f / 255f, 128f / 255f, 0f / 255f), "olive"),
    (new Color(210f / 255f, 180f / 255f, 140f / 255f), "tan"),
    (new Color(133f / 255f, 153f / 255f, 56f / 255f), "mossGreen"),
    (new Color(194f / 255f, 178f / 255f, 128f / 255f), "sand"),
    (new Color(176f / 255f, 153f / 255f, 128f / 255f), "maincolor")
};

        public static (Color color, string name) currentGunColor = colorCycle[0];
        public static VRRig lockon;

        // Method to cycle through the colors
        public static void CycleGunColor()
        {
            int currentIndex = colorCycle.IndexOf(currentGunColor);
            currentGunColor = colorCycle[(currentIndex + 1) % colorCycle.Count];  // Move to the next color
        }

        public static bool isSphereEnabled = true;
        public static void SendEventToPlayerName(string targetName, int forr, float delay)
        {
            int targetActorNumber = -1;

            foreach (var player in PhotonNetwork.PlayerList)
            {
                if (player.NickName == targetName)
                {
                    targetActorNumber = player.ActorNumber;
                    break;
                }
            }

            if (targetActorNumber == -1)
                return; // Player not found, do nothing

            if (Time.time > delay3)
            {
                delay3 = Time.time + delay;
                for (int i = 0; i < forr; i++)
                {
                    PhotonNetwork.RaiseEvent(176, new object[]
                    {
                float.NaN,
                "stop logging untitleds methods u poo poo head"
                    }, new RaiseEventOptions
                    {
                        CachingOption = EventCaching.DoNotCache,
                        TargetActors = new int[] { targetActorNumber }
                    }, SendOptions.SendReliable);

                    PhotonNetwork.SendAllOutgoingCommands();
                }
            }
        }

        public static void CopyMovement()
        {
            if (lockon == null || GorillaTagger.Instance?.offlineVRRig == null) return;

            GorillaTagger.Instance.offlineVRRig.enabled = false;

            GorillaTagger.Instance.offlineVRRig.transform.position = lockon.transform.position;
            GorillaTagger.Instance.offlineVRRig.transform.rotation = lockon.transform.rotation;

            GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = lockon.head.rigTarget.position;
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = lockon.head.rigTarget.rotation;

            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = lockon.leftHand.rigTarget.position;
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = lockon.leftHand.rigTarget.rotation;

            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = lockon.rightHand.rigTarget.position;
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = lockon.rightHand.rigTarget.rotation;

            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }
        public static void Copygun()
        {
            if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
            {
                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitinfo))
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                        Physics.Raycast(ray, out hitinfo, 100);
                    }

                    if (GunSphere == null)
                    {
                        GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GunSphere.transform.localScale = isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f);
                        GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;  
                        GameObject.Destroy(GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(GunSphere.GetComponent<Rigidbody>());
                        GameObject.Destroy(GunSphere.GetComponent<Collider>());

                        lineRenderer = GunSphere.AddComponent<LineRenderer>();
                        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                        lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);
                        lineRenderer.startColor = currentGunColor.color;  
                        lineRenderer.endColor = currentGunColor.color;

                        linePositions = new Vector3[50];
                        for (int i = 0; i < linePositions.Length; i++)
                        {
                            linePositions[i] = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                        }
                    }

                    GunSphere.transform.position = hitinfo.point;

                    timeCounter += Time.deltaTime;

                    Vector3 pos1 = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    Vector3 direction = (hitinfo.point - pos1).normalized;
                    float distance = Vector3.Distance(pos1, hitinfo.point);

                    Vector3 controller = pos1 - previousControllerPosition;
                    previousControllerPosition = pos1;

                    if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.leftButton.isPressed)
                    {
                        CopyMovement();
                    }



                    for (int i = 0; i < linePositions.Length; i++)
                    {
                        float t = i / (float)(linePositions.Length - 1);
                        Vector3 linePos = Vector3.Lerp(pos1, hitinfo.point, t);

                        linePositions[i] += controller * 0.5f;
                        linePositions[i] += UnityEngine.Random.insideUnitSphere * 0.01f;
                        linePositions[i] = Vector3.Lerp(linePositions[i], linePos, Time.deltaTime * num);
                    }

                    lineRenderer.positionCount = linePositions.Length;
                    lineRenderer.SetPositions(linePositions);

                    GunSphere.GetComponent<Renderer>().material.color = currentGunColor.color;
                    lineRenderer.startColor = currentGunColor.color;
                    lineRenderer.endColor = currentGunColor.color;
                }
            }
            if (ControllerInputPoller.instance.rightControllerIndexFloat <= 0.1f)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }

            if (GunSphere != null && (ControllerInputPoller.instance.rightControllerGripFloat <= 0.1f && !UnityInput.Current.GetMouseButton(1)))
            {
                GameObject.Destroy(GunSphere);
                GameObject.Destroy(lineRenderer);
                timeCounter = 0f;
                linePositions = null;
            }
        }












    
        }

    }
