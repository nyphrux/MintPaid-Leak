using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Menu
{
    internal class removeslide
    {
        public static void disableslide()
        {
               
        
            GameObject obj = GameObject.Find("UnityTempFile-7b49f8f5e77e5bf49916aeafab347965(combined by EdMeshCombiner");
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
