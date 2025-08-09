using BepInEx;
using GorillaGameModes;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AetherTemp.Menu
{
    internal class taggun
    {
        public static GameObject GunSphere;
        public static void TagGunMod()
        {
            if (GameMode.ActiveGameMode.GameType() == GameModeType.Infection)
            {
                if (ControllerInputPoller.instance.rightControllerGripFloat > 0.1f || UnityInput.Current.GetMouseButton(1))
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitinfo))
                    {
                        if (Mouse.current.rightButton.isPressed)
                        {
                            Camera cam = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                            Physics.Raycast(ray, out hitinfo, 100);
                        }

                        GunSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        GunSphere.transform.position = hitinfo.point;
                        GunSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        GunSphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        GunSphere.GetComponent<Renderer>().material.color = Color.white;
                        GameObject.Destroy(GunSphere.GetComponent<BoxCollider>());
                        GameObject.Destroy(GunSphere.GetComponent<Rigidbody>());
                    }
                }
            }
                }
            }
}
