using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StupidTemplate.Classes.rpcgetindexshit;

namespace AetherTemp.Menu
{
    internal class skyboxes
    {
        private static Coroutine rgbRoutine;
        private static Color originalSkyColor;
        private static Material originalSkyMaterial;
        private static bool originalSaved = false;

      
        private static readonly Color[] skyColors = new Color[]
        {
            Color.gray,
            Color.magenta,
            Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            Color.cyan,
            Color.black,
            Color.white
        };

        public static void GraySky() => SetSkyColor(Color.gray);
        public static void MagentaSky() => SetSkyColor(Color.magenta);
        public static void RedSky() => SetSkyColor(Color.red);
        public static void BlueSky() => SetSkyColor(Color.blue);
        public static void GreenSky() => SetSkyColor(Color.green);
        public static void YellowSky() => SetSkyColor(Color.yellow);
        public static void CyanSky() => SetSkyColor(Color.cyan);
        public static void BlackSky() => SetSkyColor(Color.black);
        public static void WhiteSky() => SetSkyColor(Color.white);

     
        public static void RGBSkybox()
        {
            if (rgbRoutine != null)
            {
                StopRGBSkybox();
            }
            rgbRoutine = GorillaTagger.Instance.StartCoroutine(FadeThroughSkyColors());
        }


        public static void StopRGBSkybox()
        {
            if (rgbRoutine != null)
            {
                GorillaTagger.Instance.StopCoroutine(rgbRoutine);
                rgbRoutine = null;
            }
            RestoreOriginalSky();
        }

        /// <summary>
        /// Coroutine that fades between all sky colors
        /// </summary>
        private static IEnumerator FadeThroughSkyColors()
        {
            int index = 0;
            float fadeDuration = 2f; // seconds to fade between colors

            while (true)
            {
                Color startColor = skyColors[index];
                Color endColor = skyColors[(index + 1) % skyColors.Length];
                float t = 0f;

                while (t < 1f)
                {
                    t += Time.deltaTime / fadeDuration;
                    Color current = Color.Lerp(startColor, endColor, t);
                    SetSkyColor(current);
                    yield return null;
                }

                index = (index + 1) % skyColors.Length; 
            }
        }

     
        private static void SetSkyColor(Color color)
        {
            Renderer skyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky")?.GetComponent<Renderer>();
            if (skyObject != null)
            {
                // Save original only once
                if (!originalSaved)
                {
                    originalSaved = true;
                    originalSkyMaterial = skyObject.material;
                    originalSkyColor = skyObject.material.color;
                }

                skyObject.material.shader = Shader.Find("GorillaTag/UberShader");
                skyObject.material.color = color;
            }
        }

        public static void RestoreOriginalSky()
        {
            Renderer skyObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky")?.GetComponent<Renderer>();
            if (skyObject != null && originalSaved)
            {
                skyObject.material = originalSkyMaterial;
                skyObject.material.color = originalSkyColor;
            }
        }
    }
}
