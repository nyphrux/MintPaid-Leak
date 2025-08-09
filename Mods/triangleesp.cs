using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Mods
{

    internal class triangleesp
    {
        private static float h;

        public static void triangle3d()
        {
            h += Time.deltaTime * 0.5f;
            if (h > 1f) h -= 1f;

            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
       

                GameObject triangle = new GameObject("triangleESP");
                LineRenderer lr = triangle.AddComponent<LineRenderer>();
                lr.positionCount = 12;
                lr.useWorldSpace = false;
                lr.widthMultiplier = 0.01f;
                lr.loop = false;
                lr.material.shader = Shader.Find("GUI/Text Shader");

                lr.startColor = Color.HSVToRGB(h, 1f, 1f);
                lr.endColor = Color.HSVToRGB(Mathf.Repeat(h + 0.2f, 1f), 1f, 1f);

                float baseRadius = 0.2f;
                float height = 0.25f;

                Vector3 p0 = new Vector3(Mathf.Cos(0) * baseRadius, 0, Mathf.Sin(0) * baseRadius);
                Vector3 p1 = new Vector3(Mathf.Cos(2 * Mathf.PI / 3) * baseRadius, 0, Mathf.Sin(2 * Mathf.PI / 3) * baseRadius);
                Vector3 p2 = new Vector3(Mathf.Cos(4 * Mathf.PI / 3) * baseRadius, 0, Mathf.Sin(4 * Mathf.PI / 3) * baseRadius);
                Vector3 top = new Vector3(0, height, 0);

                Vector3[] positions = new Vector3[]
                {
                p0, p1,
                p1, p2,
                p2, p0,
                p0, top,
                p1, top,
                p2, top
                };

                lr.positionCount = positions.Length;
                lr.SetPositions(positions);

                triangle.transform.position = rig.headMesh.transform.position + new Vector3(0, -0.3f, 0); // offset to show above head Change if needed !!!! 
                UnityEngine.Object.Destroy(triangle, Time.deltaTime);
            }
        }




        public static void Triangle()
        {
            int count = 36;
            float size = 0.3f;
            for (int i = 0; i < count; i++)
            {
                float angle = 360f * i / count;
                GameObject triObj = new GameObject("Triangle" + i);
                LineRenderer line = triObj.AddComponent<LineRenderer>();
                line.positionCount = 4;
                line.widthMultiplier = 0.01f;
                line.useWorldSpace = true;
                line.material.shader = Shader.Find("GUI/Text Shader");
                line.startColor = Color.red;
                line.endColor = Color.red;
                Vector3 p1 = Quaternion.Euler(0, angle, 0) * new Vector3(0, 0, size);
                Vector3 p2 = Quaternion.Euler(0, angle, 0) * new Vector3(-size, 0, -size);
                Vector3 p3 = Quaternion.Euler(0, angle, 0) * new Vector3(size, 0, -size);
                line.SetPosition(0, GorillaTagger.Instance.offlineVRRig.transform.position + p1);
                line.SetPosition(1, GorillaTagger.Instance.offlineVRRig.transform.position + p2);
                line.SetPosition(2, GorillaTagger.Instance.offlineVRRig.transform.position + p3);
                line.SetPosition(3, GorillaTagger.Instance.offlineVRRig.transform.position + p1);
                UnityEngine.Object.Destroy(triObj, Time.deltaTime);
            }
        }
    }
}
