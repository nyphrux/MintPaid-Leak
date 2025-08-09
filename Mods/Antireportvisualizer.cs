using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using static StupidTemplate.Classes.rpcgetindexshit;

namespace StupidTemplate.Mods
{
    internal class Antireportvisualizer
    {
        private static GameObject visualizer;
        public static float DistanceSetting = 0.51f; 
       public static readonly List<string> distanceNames = new List<string> { "super small", "small", "medium", "large", "super large" };
      public
            static int currentDistanceIndex = 2; 
        public static void DistanceChanger(string size)
        {
            switch (size.ToLower())
            {
                case "super small":
                    Antireportvisualizer.DistanceSetting = 0.1f;
                    break;
                case "small":
                    Antireportvisualizer.DistanceSetting = 0.25f;
                    break;
                case "medium":
                    Antireportvisualizer.DistanceSetting = 0.5f;
                    break;
                case "large":
                    Antireportvisualizer.DistanceSetting = 1.0f;
                    break;
                case "super large":
                    Antireportvisualizer.DistanceSetting = 2.0f;
                    break;
                default:
                    Antireportvisualizer.DistanceSetting = 0.51f; 
                    break;
            }
        }
        public static void AntiReport()
        {
            if (GorillaScoreboardTotalUpdater.allScoreboardLines == null || GorillaParent.instance.vrrigs == null)
                return;

            int localActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;

            foreach (var scoreboardLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                if (scoreboardLine == null || scoreboardLine.reportButton == null)
                    continue;

                if (scoreboardLine.playerActorNumber == localActorNumber)
                {
                    Vector3 reportPos = scoreboardLine.reportButton.transform.position;

                    if (visualizer == null)
                    {
                        visualizer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Object.Destroy(visualizer.GetComponent<Collider>());
                        visualizer.transform.localScale = Vector3.one * 0.3f;

                        var renderer = visualizer.GetComponent<Renderer>();
                        renderer.material = new Material(Shader.Find("GorillaTag/UberShader"));
                        renderer.material.color = Color.green;
                    }

                    visualizer.transform.position = reportPos;
               visualizer.transform.localScale = Vector3.one * Antireportvisualizer.DistanceSetting;
                    visualizer.SetActive(true);

                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (vrrig == null) continue;

                        float rightDis = Vector3.Distance(vrrig.rightHandTransform.position, reportPos);
                        float leftDis = Vector3.Distance(vrrig.leftHandTransform.position, reportPos);

                        if ((rightDis <= DistanceSetting || leftDis <= DistanceSetting) && vrrig != GorillaTagger.Instance.offlineVRRig)
                        {
                            NetworkSystem.Instance.ReturnToSinglePlayer();
                            flush();
                        }
                    }

                    return;
                }
            }

            if (visualizer != null)
                visualizer.SetActive(false);
        }
    }
}
