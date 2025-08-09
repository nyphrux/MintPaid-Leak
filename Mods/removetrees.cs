using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Menu
{
    
    internal class removetrees
    {
        public static void notrees()
        {

     
            GameObject obj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/UnityTempFile-ebf133343a4f23740b98057ab3c69091 (combined by EdMeshCombiner)");
            if (obj != null)
            {
                obj.SetActive(false); // disable the object
                Debug.Log("Heart object enabled.");
            }
            else
            {
                Debug.LogWarning("Heart object not found!");
            }
            
        }
    }
}
