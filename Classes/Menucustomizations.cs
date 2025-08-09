using UnityEngine;
using Photon.Pun;
using GorillaLocomotion;
using static StupidTemplate.Menu.Main;
using System.Collections;

namespace AetherTemp.Menu
{
    internal class MenuPhysicsMods
    {

        public static Rigidbody menuRb;
        public static GameObject menu = MenuPhysicsMods.menu;

     
        private static GameObject trailObj;
        private static TrailRenderer trail;

        private static bool isHeld = true;
    
        //this trail is ass and rushed
        public static void InitMenuTrail()
        {
            menu = MenuPhysicsMods.menu;
            if (menu == null) return;

            if (trailObj != null)
            {
                Object.Destroy(trailObj);
                trailObj = null;
                trail = null;
            }

            trailObj = new GameObject("MenuTrail");
            trailObj.transform.SetParent(menu.transform, false);
            

            trail = trailObj.AddComponent<TrailRenderer>();
            trail.time = 0.6f;
            trail.startWidth = 0.05f;
            trail.endWidth = 0f;
            trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            trail.receiveShadows = false;
            trail.material = new Material(Shader.Find("GorillaTag/UberShader"));

     
            trail.material.color = new Color32(220, 20, 60, 180);

            isHeld = true;
            CoroutineHandler.Instance.StartCoroutine(WiggleTrail());


            CoroutineHandler.Instance.StartCoroutine(DestroyTrailWhenMenuDestroyed());
        }


        private static IEnumerator WiggleTrail()
        {
            while (trailObj != null && trailObj.activeInHierarchy)
            {
                trailObj.transform.position += Vector3.zero;
                yield return new WaitForSeconds(0.05f);
            }
        }


        private static IEnumerator DestroyMenuAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            if (trailObj != null)
            {
                Object.Destroy(trailObj);
                trailObj = null;
                trail = null;
            }
            if (menu != null)
            {
                Object.Destroy(menu);
                menu = null;
            }
        }

        private static IEnumerator DestroyTrailWhenMenuDestroyed()
        {
            while (menu != null) yield return null;

            if (trailObj != null)
                Object.Destroy(trailObj);
            trailObj = null;
            trail = null;
        }

        public static void Spinmenux()
        {
            if (menu == null) return;
            menuRb = menu.GetComponent<Rigidbody>() ?? menu.AddComponent<Rigidbody>();
            menuRb.useGravity = false; 
            menuRb.angularVelocity = new Vector3(1f, 0, 0); 
        }

        public static void Spinmenuy()
        {
            if (menu == null) return;
            menuRb = menu.GetComponent<Rigidbody>() ?? menu.AddComponent<Rigidbody>();
            menuRb.useGravity = false; 
            menuRb.angularVelocity = new Vector3(0, 1f, 0f); 
        }


        public static void SpinMenuz()
        {
            if (menu == null) return;
            menuRb = menu.GetComponent<Rigidbody>() ?? menu.AddComponent<Rigidbody>();
            menuRb.useGravity = false; 
            menuRb.angularVelocity = new Vector3(0, 0, 1f);
        }

        public static float orbitSpeed = 30f;

        public static void UpdateOrbit(string command)
        {
            if (menu == null) return;

            switch (command.ToLower())
            {
                case "faster":
                    orbitSpeed *= 1.5f;
                    break;
                case "slower":
                    orbitSpeed /= 1.5f;
                    break;
                case "superfast":
                    orbitSpeed *= 3f;
                    break;
                case "ultrafast":
                    orbitSpeed *= 5f;
                    break;
                case "normal":
                    orbitSpeed = 30f;
                    break;
            }

            if (orbitSpeed > 675f)
                orbitSpeed = 30f;
        }


        public static void OrbitMenu()
        {
            if (menu == null) return;
            menu.transform.RotateAround(GTPlayer.Instance.bodyCollider.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
         }


        }

    
}
