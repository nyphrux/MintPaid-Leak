using Photon.Pun;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using static StupidTemplate.Settings;
using static AetherTemp.Menu.SettingsMods;
using System.Collections;
namespace StupidTemplate.Mods
{
    internal class Boards
    {

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
        public class CoroutineRunner : MonoBehaviour
        {
            private static CoroutineRunner _instance;

            public static CoroutineRunner Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        var go = new GameObject("CoroutineRunner");
                        UnityEngine.Object.DontDestroyOnLoad(go);
                        _instance = go.AddComponent<CoroutineRunner>();
                    }
                    return _instance;
                }
            }
        }
        
        public static void UpdateMatchMenuThemeMaterial()
        {
            int currentTheme = ThemeSettings.GetCurrentThemeIndex();


            Color themeButtonColor = ThemeSettings.themes[ThemeSettings.currentThemeIndex].buttonColors[0].colors[0].color;
            matchhmenutheme.color = themeButtonColor;

        }

        public static Material matchhmenutheme = new Material(Shader.Find("GorillaTag/UberShader"));

        public static string StumpLeaderboardID = "UnityTempFile";
        public static Color32 DarkDodgerBlue = new Color32(8, 90, 177, byte.MaxValue);

        public static Color32 DarkSeaGreen = new Color32(143, 188, 143, byte.MaxValue);
        public static IEnumerator FadeToBlackAndBack(TextMeshPro tmp, float duration)
        {
            if (tmp == null) yield break;

            Color originalColor = tmp.color;
            Color black = Color.black;
            float halfDuration = duration / 2f;
            float timer = 0f;

            // Fade from original color to black
            while (timer < halfDuration)
            {
                timer += Time.deltaTime;
                tmp.color = Color.Lerp(originalColor, black, timer / halfDuration);
                yield return null;
            }

            timer = 0f;

            // Fade from black back to original color
            while (timer < halfDuration)
            {
                timer += Time.deltaTime;
                tmp.color = Color.Lerp(black, originalColor, timer / halfDuration);
                yield return null;
            }

            // Ensure the final color is exactly original
            tmp.color = originalColor;
        }
        public static int StumpLeaderboardIndex = 5;
        public static Material StumpMat = null;
        public static void SetMOTDText()
        {
            int indexOfThatThing = 0;
            for (int i = 0; i < GetObject("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.childCount; i++)
            {
                GameObject v = GetObject("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.GetChild(i).gameObject;
                if (v.name.Contains(StumpLeaderboardID))
                {
                    indexOfThatThing++;
                    if (indexOfThatThing == StumpLeaderboardIndex)
                    {
                        if (StumpMat == null)
                            StumpMat = v.GetComponent<Renderer>().material;

                        v.GetComponent<Renderer>().material = matchhmenutheme;
                        break;
                    }

                    // above forest trigger


                    // keyboard color
                    GameObject keyboard = GameObject.Find(
                "Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)"
            );

                    if (keyboard != null)
                    {
                        MeshRenderer meshRenderer = keyboard.GetComponent<MeshRenderer>();
                        if (meshRenderer != null)
                        {
                            meshRenderer.material = matchhmenutheme; // Set to blue
                        }
                        else
                        {
                            Debug.LogWarning("No MeshRenderer found on keyboard (1)!");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Keyboard (1) object not found!");
                    }

                    // Change monitor color
                    GameObject monitorObject = GameObject.Find(
                        "Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor"
                    );
                    if (monitorObject != null && monitorObject.TryGetComponent<Renderer>(out var monitorRenderer))
                    {
                        monitorRenderer.material = matchhmenutheme;
                        Debug.Log("[NEBULAS] Monitor color set to blue.");
                    }
                    else
                    {
                        Debug.LogWarning("Monitor object not found or has no Renderer.");
                    }

                    // Change TreeRoom object color
                    string objPath = "Environment Objects/LocalObjects_Prefab/TreeRoom/UnityTempFile-f9a1cde2b72a87d47ba8862da10cd648";
                    GameObject target = GameObject.Find(objPath);
                    if (target != null)
                    {
                        Renderer renderer2 = target.GetComponent<Renderer>();
                        if (renderer2 != null)
                        {
                            renderer2.sharedMaterial = matchhmenutheme;
                        }
                        else
                        {
                            Debug.LogWarning("Renderer not found on TreeRoom object.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("TreeRoom object not found.");
                    }

                    // Define nebula theme color
                    Color nebulaColor = new Color(0.2f, 0.0f, 0.6f, 1f); // Deep purple-blue

                    // Change wall monitor color
                    GameObject vr3 = GetObject(
                        "Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg"
                    );
                    if (vr3 != null && vr3.TryGetComponent<Renderer>(out Renderer wallRenderer))
                    {
                        wallRenderer.material = matchhmenutheme;
                    }
                    else
                    {
                        Debug.LogWarning("Could not find the wall monitor or its Renderer.");
                    }

                    // Change computer monitor color
                    GameObject computerMonitor = GetObject(
                        "Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen"
                    );
                    if (computerMonitor != null && computerMonitor.TryGetComponent<Renderer>(out Renderer compRenderer))
                    {
                        compRenderer.material = matchhmenutheme;
                        Debug.Log("[NEBULAS] Computer monitor color set to nebula theme.");
                    }
                    else
                    {
                        Debug.LogWarning("Could not find the computer monitor or its Renderer.");
                    }

                    // MOTD Title
                    GameObject titleObject = GameObject.Find("CodeOfConductHeadingText");
                    if (titleObject != null && titleObject.TryGetComponent<TextMeshPro>(out var titleTMP))
                    {
                        titleTMP.color = DarkSeaGreen; // or any other Color32

                        titleTMP.text = "Mint Paid | Authorized!";
                    }
               
                    

        // MOTD Body
        GameObject bodyObject = GameObject.Find("COCBodyText_TitleData");
                    if (bodyObject != null && bodyObject.TryGetComponent<TextMeshPro>(out var bodyTMP))
                    {
                        // Optionally set the color, if you want to use DarkDodgerBlue:
                        bodyTMP.color = DarkDodgerBlue;

                        bodyTMP.text =
                            "discord.gg/R7eFesbKDr\n" +
                            "Status | Undetected\n" +
                            "I MINT Am Not Responsible For Any Bans\n" +
                            "Using This Menu U Agree All Bans Are Not My fault\n";
                    }

                    // motdBodyText
                    GameObject motdBodyObject = GameObject.Find("motdBodyText");
                    if (motdBodyObject != null && motdBodyObject.TryGetComponent<TextMeshPro>(out var motdBodyTMP))
                    {
                        string nickname = string.IsNullOrEmpty(PhotonNetwork.NickName) ? "Player" : PhotonNetwork.NickName;
                        motdBodyTMP.text =
                            $"Mint Paid v1.0 Thank U {nickname} for using our menu</color>\n<color=white>Join our Discord for news & updates!</color>";
                        Debug.Log("[NEBULAS] motdBodyText updated.");

                        // Start fading coroutine (needs to be started from a MonoBehaviour)
                        CoroutineRunner.Instance.StartCoroutine(Boards.FadeToBlackAndBack(motdBodyTMP, 2f));

                    }


                    // motdHeadingText
                    GameObject motdHeadingObject = GameObject.Find("motdHeadingText");
                    if (motdHeadingObject != null && motdHeadingObject.TryGetComponent<TextMeshPro>(out var motdHeadingTMP))
                    {
                        motdHeadingTMP.text = "<color=#33CCFF><b>>>>></b></color>";
                        Debug.Log("[NEBULAS] motdHeadingText updated.");
                    }
                }
            }
        }


        public static void ResetMOTDText()
        {
            // Title Reset
            GameObject titleObject = GameObject.Find("CodeOfConductHeadingText");
            if (titleObject != null)
            {
                TextMeshPro titleTMP = titleObject.GetComponent<TextMeshPro>();
                if (titleTMP != null)
                {
                    titleTMP.text = "GORILLA CODE OF CONDUCT";
                    Debug.Log("[NEBULAS] Title reset.");
                }
            }

            // Body Reset
            GameObject bodyObject = GameObject.Find("COCBodyText_TitleData");
            if (bodyObject != null)
            {
                TextMeshPro bodyTMP = bodyObject.GetComponent<TextMeshPro>();
                if (bodyTMP != null)
                {
                    bodyTMP.text = "-NO RACISM, SEXISM, HOMOPHOBIA, TRANSPHOBIA, OR OTHER BIGOTRY\r\n-NO CHEATS OR MODS\r\n-DO NOT HARASS OTHER PLAYERS OR INTENTIONALLY MAKE THEM UNCOMFORTABLE\r\n-DO NOT TROLL OR GRIEF LOBBIES BY BEING UNCATCHABLE OR BY ESCAPING THE MAP. TRY TO MAKE SURE EVERYONE IS HAVING FUN\r\n-IF SOMEONE IS BREAKING THIS CODE, PLEASE REPORT THEM\r\n-PLEASE BE NICE GORILLAS AND HAVE A GOOD TIME";
                    Debug.Log("[NEBULAS] Body reset.");
                }
            }

            // motdBodyText Reset
            GameObject motdBodyObject = GameObject.Find("motdBodyText");
            if (motdBodyObject != null)
            {
                TextMeshPro motdBodyTMP = motdBodyObject.GetComponent<TextMeshPro>();
                if (motdBodyTMP != null)
                {
                    motdBodyTMP.text = "EVER NEEDED HELP OR WANTED TO TRY SOMETHING NEW WITH FELLOW MONKE?\r\n\r\n- CAN'T REACH THAT BRANCH? A FRIEND CAN PULL YOU UP.\r\n- STUCK AT THE BEACH? SOMEONE CAN HAUL YOU OUT.\r\n- FACING A LONG JUMP? A MONKE CAN GRAB YOU MID-AIR.\r\n\r\nNO FORCED GRABBING - IF YOU DON'T WANT TO HOLD ON, JUST LET GO.\r\n\r\nIT'S SIMPLE, FUN, AND FULL OF SILLY POSSIBILITIES.\r\nNOW GET OUT THERE AND TAKE SOMEONE'S HAND!";
                    Debug.Log("[NEBULAS] motdBodyText reset.");
                }
            }

            // motdHeadingText Reset
            GameObject motdHeadingObject = GameObject.Find("motdHeadingText");
            if (motdHeadingObject != null)
            {
                TextMeshPro motdHeadingTMP = motdHeadingObject.GetComponent<TextMeshPro>();
                if (motdHeadingTMP != null)
                {
                    motdHeadingTMP.text = "MESSAGE OF THE DAY";
                    Debug.Log("[NEBULAS] motdHeadingText reset.");
                }
            }
        }
    }
    }
    
