using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using static StupidTemplate.Classes.RigManager;

namespace StupidTemplate.Mods
{
    internal class NameTagsTMP : MonoBehaviour
    {
        private class Billboard : MonoBehaviour
        {
            void Update()
            {
                if (GorillaLocomotion.GTPlayer.Instance != null)
                {
                    Transform head = GorillaLocomotion.GTPlayer.Instance.headCollider.transform;
                    transform.LookAt(head.position);
                    transform.Rotate(0f, 180f, 0f);

                    TextMeshPro tmp = GetComponent<TextMeshPro>();
                    if (tmp != null)
                    {
                        tmp.color = Boards.matchhmenutheme.color;
                    }
                }
            }
        }

        private static readonly Dictionary<int, GameObject> nameTags = new Dictionary<int, GameObject>();

        void Update()
        {
            UpdateNameTags();
        }

        private void UpdateNameTags()
        {
            // Clean up removed players' tags
            var currentActors = new HashSet<int>();
            foreach (var player in PhotonNetwork.PlayerList)
            {
                currentActors.Add(player.ActorNumber);

                if (!nameTags.ContainsKey(player.ActorNumber))
                {
                    CreateNameTagForPlayer(player);
                }
                else
                {
                    UpdateNameTagPosition(player);
                }
            }

            // Remove tags for players no longer in room
            var toRemove = new List<int>();
            foreach (var actor in nameTags.Keys)
            {
                if (!currentActors.Contains(actor))
                {
                    if (nameTags[actor] != null)
                        Destroy(nameTags[actor]);
                    toRemove.Add(actor);
                }
            }
            foreach (int actor in toRemove)
                nameTags.Remove(actor);
        }

        private void CreateNameTagForPlayer(Photon.Realtime.Player player)
        {
            GameObject playerObj = GetVRRigByActor(player.ActorNumber);
            if (playerObj == null) return;

            GameObject nameObj = new GameObject("PlayerNameTag_" + player.NickName);
            nameObj.transform.SetParent(playerObj.transform);
            nameObj.transform.localPosition = new Vector3(0, 2.3f, 0);
            nameObj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            TextMeshPro tmp = nameObj.AddComponent<TextMeshPro>();
            tmp.text = player.NickName;
            tmp.fontSize = 2f;
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.color = Boards.matchhmenutheme.color;

            // Use existing font and material properly
            var fontRef = GameObject.Find("motdHeadingText")?.GetComponent<TextMeshPro>();
            if (fontRef != null)
            {
                tmp.font = fontRef.font;
                tmp.fontSharedMaterial = new Material(fontRef.font.material);
                tmp.fontSharedMaterial.shader = Shader.Find("TextMeshPro/Distance Field");
            }

            nameObj.AddComponent<Billboard>();

            nameTags[player.ActorNumber] = nameObj;
        }
        public static void EnableNameTags()
        {
            if (GameObject.Find("NameTagTMPHandler") == null)
            {
                GameObject obj = new GameObject("NameTagTMPHandler");
                obj.AddComponent<NameTagsTMP>();
            }
        }

        private void UpdateNameTagPosition(Photon.Realtime.Player player)
        {
            GameObject playerObj = GetVRRigByActor(player.ActorNumber);
            if (playerObj == null) return;

            GameObject nameObj = nameTags[player.ActorNumber];
            if (nameObj == null) return;

            nameObj.transform.SetParent(playerObj.transform);
            nameObj.transform.localPosition = new Vector3(0, 2.3f, 0);
            nameObj.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

            TextMeshPro tmp = nameObj.GetComponent<TextMeshPro>();
            if (tmp != null)
            {
                tmp.color = Boards.matchhmenutheme.color;
            }
        }

        private static GameObject GetVRRigByActor(int actorNumber)
        {
            foreach (VRRig rig in GameObject.FindObjectsOfType<VRRig>())
            {
                Photon.Realtime.Player player = GetPlayerFromVRRig(rig);
                if (player != null && player.ActorNumber == actorNumber)
                {
                    return rig.gameObject;
                }
            }
            return null;
        }
    }
}