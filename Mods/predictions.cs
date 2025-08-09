using BepInEx;
using GorillaLocomotion;
using Photon.Realtime;
using System;
using UnityEngine;

namespace MadeByCokeLOL
{
    // Token: 0x02000002 RID: 2
    [BepInPlugin("com.Coke.gorillatag.edp", "Preds By Null Creds To coke for base", "1.0.0")]
    public class predslider : BaseUnityPlugin
    {
        public static predslider Instance { get; private set; }

        public bool showWindow = false;  // add this toggle field
        // Token: 0x06000001 RID: 1 RVA: 0x00002080 File Offset: 0x00000280
        private void OnGUI()
        {
            float r = Mathf.Abs(Mathf.Sin(Time.time * this.GaySped));
            float g = Mathf.Abs(Mathf.Sin(Time.time * this.GaySped + 1.0471976f));
            float b = Mathf.Abs(Mathf.Sin(Time.time * this.GaySped + 2.0943952f));
            GUI.color = new Color(r, g, b);
            GUI.backgroundColor = new Color(r, g, b);
            GUI.contentColor = new Color(r, g, b);
            bool flag = GUI.Button(new Rect(10f, 10f, 200f, 30f), predslider.ILoveKids ? "Hide Slider" : "Show Slider");
            if (flag)
            {
                predslider.ILoveKids = !predslider.ILoveKids;
            }
            bool iloveKids = predslider.ILoveKids;
            if (iloveKids)
            {
                GUI.Label(new Rect(10f, 50f, 200f, 20f), "NULL Pred Slider");
                predslider.EDP = GUI.HorizontalSlider(new Rect(10f, 80f, 200f, 20f), predslider.EDP, 0f, 100f);
                GUI.Label(new Rect(220f, 80f, 100f, 20f), string.Format(" > {0:F1}", predslider.EDP));
            }
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000021E8 File Offset: 0x000003E8
        private void Update()
        {
            
            bool iloveKids = predslider.ILoveKids;
            if (iloveKids)
            {
                predslider.Predictions();
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002208 File Offset: 0x00000408
        public static void Predictions()
        {
            predslider.Cum = Time.deltaTime;
            predslider.PLR = GTPlayer.Instance.AveragedVelocity;
            Vector3 position = GTPlayer.Instance.leftControllerTransform.position;
            Vector3 position2 = GTPlayer.Instance.rightControllerTransform.position;
            Vector3 vector = ((position - predslider.LLP) / predslider.Cum - predslider.PLR) * predslider.smoothdick + predslider.LLV * (1f - predslider.smoothdick);
            Vector3 vector2 = ((position2 - predslider.LRP) / predslider.Cum - predslider.PLR) * predslider.smoothdick + predslider.LRV * (1f - predslider.smoothdick);
            Vector3 position3 = predslider.PredictedPosition(GTPlayer.Instance.leftControllerTransform, vector);
            Vector3 position4 = predslider.PredictedPosition(GTPlayer.Instance.rightControllerTransform, vector2);
            GTPlayer.Instance.leftControllerTransform.position = position3;
            GTPlayer.Instance.rightControllerTransform.position = position4;
            predslider.LLP = position;
            predslider.LRP = position2;
            predslider.LLV = vector;
            predslider.LRV = vector2;
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002338 File Offset: 0x00000538
        public static Vector3 PredictedPosition(Transform target, Vector3 velocity)
        {
            return target.position + velocity * (predslider.EDP * 0.01f / 2f);
        }

        // Token: 0x04000001 RID: 1
        public static Vector3 LLP;

        // Token: 0x04000002 RID: 2
        public static Vector3 LRP;

        // Token: 0x04000003 RID: 3
        public static float Cum;

        // Token: 0x04000004 RID: 4
        public static Vector3 PLR;

        // Token: 0x04000005 RID: 5
        public static Vector3 Nut;

        // Token: 0x04000006 RID: 6
        public static Vector3 LLV;

        // Token: 0x04000007 RID: 7
        public static Vector3 LRV;

        // Token: 0x04000008 RID: 8
        public static float smoothdick = 0.1f;

        // Token: 0x04000009 RID: 9
        public static float EDP = 0f;

        // Token: 0x0400000A RID: 10
        private float GaySped = 0.8f;

        // Token: 0x0400000B RID: 11
        public static bool ILoveKids = false;
    }
}
