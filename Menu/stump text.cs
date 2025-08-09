using StupidTemplate.Mods;
using TMPro;
using UnityEngine;
using static StupidTemplate.Mods.Boards;

namespace AetherTemp.Mods
{
    internal class FloatingStumpText
    {
        private static GameObject stumpObjInstance;

        // Unity color cycle list
        private static readonly Color[] unityColors = new Color[]
        {
            Color.red, Color.green, Color.blue, Color.cyan, Color.magenta,
            Color.yellow, Color.black, Color.white, Color.gray, Color.grey
        };

        private static readonly string[] unityColorNames = new string[]
        {
            "Red","Green","Blue","Cyan","Magenta","Yellow","Black","White","Gray","Grey"
        };

        private static int colorIndex = 0;
        private static bool followTheme = true; 

        public static string CurrentColorName => followTheme ? "Theme" : unityColorNames[colorIndex];

        public static void StumpText()
        {
            if (stumpObjInstance != null) return;

            stumpObjInstance = new GameObject("STUMPOBJ");
            TextMeshPro textobj = stumpObjInstance.AddComponent<TextMeshPro>();

            textobj.text = "Mint Paid\nVersion 1.0";
            textobj.fontSize = 2f;
            textobj.alignment = TextAlignmentOptions.Center;

            textobj.color = Boards.matchhmenutheme.color;

            textobj.font = GameObject.Find("motdHeadingText").GetComponent<TextMeshPro>().font;
            textobj.fontSharedMaterial = new Material(textobj.font.material);
            textobj.fontSharedMaterial.shader = Shader.Find("TextMeshPro/Distance Field");



            stumpObjInstance.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            stumpObjInstance.transform.position = new Vector3(-63.5511f, 12.2094f, -82.6264f);

            if (stumpObjInstance.GetComponent<Billboard>() == null)
            {
                stumpObjInstance.AddComponent<Billboard>();
            }
        }

    
        public static void NextColor()
        {
            if (stumpObjInstance == null) return;

            if (followTheme)
            {
                followTheme = false;
                colorIndex = 0;
            }
            else
            {
              
                colorIndex++;

              
                if (colorIndex >= unityColors.Length)
                {
                    colorIndex = 0;
                    followTheme = true;
                }
            }

            TextMeshPro tmp = stumpObjInstance.GetComponent<TextMeshPro>();
            if (tmp != null)
            {
                tmp.color = followTheme ? Boards.matchhmenutheme.color : unityColors[colorIndex];
            }
        }


        public static void FollowTheme()
        {
            followTheme = true;
        }

        public static void NoMatchTheme()
        {
            followTheme = false;
            if (stumpObjInstance != null)
            {
                TextMeshPro tmp = stumpObjInstance.GetComponent<TextMeshPro>();
                if (tmp != null)
                {
                    tmp.color = unityColors[colorIndex]; 
                }
            }
        }

        private class Billboard : MonoBehaviour
        {
            void Update()
            {
                if (GorillaLocomotion.GTPlayer.Instance != null)
                {
                    Transform head = GorillaLocomotion.GTPlayer.Instance.headCollider.transform;
                    transform.LookAt(head.position);
                    transform.Rotate(0f, 180f, 0f);

                    // Only follow theme if enabled
                    TextMeshPro tmp = GetComponent<TextMeshPro>();
                    if (tmp != null && followTheme)
                    {
                        tmp.color = Boards.matchhmenutheme.color;
                    }
                }
            }
        }

        public static void Restore()
        {
            if (stumpObjInstance != null)
            {
                UnityEngine.Object.Destroy(stumpObjInstance);
                stumpObjInstance = null;
            }
        }
    }
}
