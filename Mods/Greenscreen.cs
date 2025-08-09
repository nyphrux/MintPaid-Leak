using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class Greenscreen
    {
        public static void GreenScreen()
        {
            Color bgcolor = Color.green;

            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-54.0404f, 16.2321f, -124.5915f);
            a.transform.localScale = new Vector3(14.0131f, 0.0347f, 15.8359f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-52.7365f, 17.5233f, -122.333f);
            a.transform.localScale = new Vector3(14.0131f, 6.4907f, 0.0305f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-51.6623f, 17.5233f, -125.9925f);
            a.transform.localScale = new Vector3(15.5363f, 6.4907f, 0.0305f);
            a.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);

            a = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(a.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(a.GetComponent<BoxCollider>());
            a.transform.position = new Vector3(-54.0606f, 18.8161f, -124.6264f);
            a.transform.localScale = new Vector3(14.0131f, 0.0347f, 15.5983f);
            a.GetComponent<Renderer>().material.color = bgcolor;
            UnityEngine.Object.Destroy(a, Time.deltaTime * 2f);
        }
    }
}
