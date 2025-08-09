using StupidTemplate.Classes;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;


namespace Aeth.Mods
{
    internal class platforms
    {
        public static Color PlatColorA = new Color32(0, 255, 246, 255);
        public static Color PlatColorB = new Color32(0, 255, 144, 255);

        public static GameObject platl;
        public static GameObject platr;

        public static void Platforms()
        {
            bool leftGrab = ControllerInputPoller.instance.leftGrab;
            bool rightGrab = ControllerInputPoller.instance.rightGrab;

            // Left Hand Platform
            if (leftGrab)
            {
                if (platl == null)
                {
                    platl = CreatePlatform(GorillaTagger.Instance.leftHandTransform);
                }
                else
                {
                    UpdatePlatformPosition(platl, GorillaTagger.Instance.leftHandTransform);
                }
            }
            else
            {
                if (platl != null)
                {
                    UnityEngine.Object.Destroy(platl);
                    platl = null;
                }
            }

            // Right Hand Platform
            if (rightGrab)
            {
                if (platr == null)
                {
                    platr = CreatePlatform(GorillaTagger.Instance.rightHandTransform);
                }
                else
                {
                    UpdatePlatformPosition(platr, GorillaTagger.Instance.rightHandTransform);
                }
            }
            else
            {
                if (platr != null)
                {
                    UnityEngine.Object.Destroy(platr);
                    platr = null;
                }
            }
        }

        // Function to create a platform
        private static GameObject CreatePlatform(Transform handTransform)
        {
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
            platform.transform.position = handTransform.position;
            platform.transform.rotation = handTransform.rotation;

            ColorChanger colorChanger = platform.AddComponent<ColorChanger>();
            colorChanger.colorInfo = new ExtGradient
            {
                colors = new GradientColorKey[]
                {
            new GradientColorKey(PlatColorA, 0f),
            new GradientColorKey(PlatColorB, 0.5f),
            new GradientColorKey(PlatColorA, 1f)
                }
            };
            colorChanger.Start();

            return platform;
        }

        // Function to update platform position
        private static void UpdatePlatformPosition(GameObject platform, Transform handTransform)
        {
            platform.transform.position = handTransform.position;
            platform.transform.rotation = handTransform.rotation;
        }

    }
}