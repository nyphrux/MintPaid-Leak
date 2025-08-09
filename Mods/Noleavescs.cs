using System.Collections.Generic;
using UnityEngine;

namespace AetherTemp.Menu
{
    internal class noleaves
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
        public static string leavesName = "UnityTempFile-f2bd9d00466e74f4086a76332b98515f";
        public static List<GameObject> leaves = new List<GameObject> { };
        public static void Removeallleaves()
        {
            GameObject Forest = GetObject("Environment Objects/LocalObjects_Prefab/Forest");
            if (Forest != null)
            {
                for (int i = 0; i < Forest.transform.childCount; i++)
                {
                    GameObject v = Forest.transform.GetChild(i).gameObject;
                    if (v.name.Contains(leavesName))
                    {
                        v.SetActive(false);
                        leaves.Add(v);
                    }
                }
            }
        
        }


    }
}

