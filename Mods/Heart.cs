using UnityEngine;

namespace AetherTemp.Menu
{
    internal class Heart
    {
        public static void heart()
        {
            GameObject obj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/ILavaYou_ForestArt_Prefab");
            if (obj != null)
            {
                obj.SetActive(true); // Enable the object
                Debug.Log("Heart object enabled.");
            }
            else
            {
                Debug.LogWarning("Heart object not found!");
            }
        }
    }
}
