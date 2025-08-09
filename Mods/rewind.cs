using GorillaLocomotion;
using Oculus.Interaction;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using static StupidTemplate.Classes.rpcgetindexshit;

namespace StupidTemplate.Mods
{
    internal class rewind
    {
        private static List<object[]> playerPositions = new List<object[]> { };
        public static Vector3 closePosition;
        public static Vector3 lastPosition = Vector3.zero;
        public static void TeleportPlayer(Vector3 pos) // Prevents your hands from getting stuck on trees
        {
            GTPlayer.Instance.TeleportTo(World2Player(pos), GTPlayer.Instance.transform.rotation);
            closePosition = Vector3.zero;
            lastPosition = Vector3.zero;
       
        }
        public static void Rewind()
        {
            if (rightTrigger > 0.5f)
            {
                if (playerPositions.Count > 0)
                {
                    object[] targetPos = playerPositions[^1];

                    TeleportPlayer((Vector3)targetPos[0]);

                    GorillaTagger.Instance.leftHandTransform.position = (Vector3)targetPos[1];
                    GorillaTagger.Instance.leftHandTransform.rotation = (Quaternion)targetPos[2];

                    GorillaTagger.Instance.rightHandTransform.position = (Vector3)targetPos[3];
                    GorillaTagger.Instance.rightHandTransform.rotation = (Quaternion)targetPos[4];

                    GorillaTagger.Instance.rigidbody.velocity = (Vector3)targetPos[5] * -1f;

                    playerPositions.RemoveAt(playerPositions.Count - 1);
                }
            }
            else
            {
                playerPositions.Add(new object[] {
                    GorillaTagger.Instance.bodyCollider.transform.position,

                    GorillaTagger.Instance.leftHandTransform.position,
                    GorillaTagger.Instance.leftHandTransform.rotation,

                    GorillaTagger.Instance.rightHandTransform.position,
                    GorillaTagger.Instance.rightHandTransform.rotation,

                    GorillaTagger.Instance.rigidbody.velocity
                });

                if (playerPositions.Count > 8640)
                    playerPositions.RemoveAt(0);
            }
        }
    }
}
