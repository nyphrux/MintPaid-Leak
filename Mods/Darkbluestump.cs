using System;
using UnityEngine;
namespace AetherTemp.Mods
{
    internal class Darkbluestump
    {
        private static Color? originalColor = null;

        private const string StumpPath =
            "Environment Objects/LocalObjects_Prefab/TreeRoom/UnityTempFile-1e627daab0ded9b4790b5c6f788286fb (combined by EdMeshCombiner)";

        public static void Bluestump()
        {
            GameObject combinedMesh = GameObject.Find(StumpPath);

            if (combinedMesh != null)
            {
                MeshRenderer meshRenderer = combinedMesh.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    // Save the original color if we haven't yet
                    if (originalColor == null)
                        originalColor = meshRenderer.material.color;

                    meshRenderer.material.color = Color.blue; // Set to blue
                }
                else
                {
                    Debug.LogWarning("No MeshRenderer found on the combined mesh object!");
                }
            }
            else
            {
                Debug.LogWarning("Combined mesh object not found!");
            }
        }

        public static void RestoreStump()
        {
            GameObject combinedMesh = GameObject.Find(StumpPath);

            if (combinedMesh != null)
            {
                MeshRenderer meshRenderer = combinedMesh.GetComponent<MeshRenderer>();
                if (meshRenderer != null && originalColor != null)
                {
                    meshRenderer.material.color = (Color)originalColor; // Restore
                    Debug.Log("Stump color restored to original.");
                }
                else
                {
                    Debug.LogWarning("MeshRenderer missing or original color not saved!");
                }
            }
            else
            {
                Debug.LogWarning("Combined mesh object not found!");
            }
        }
    }
}
