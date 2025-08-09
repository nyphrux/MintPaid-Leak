using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace AetherTemp.Menu
{
    internal class helicopter
    {
        public static GorillaTagger taggerInstance;
        public static ControllerInputPoller pollerInstance;
        public static void HelicopterMonke()
        {
            bool flag = (double)pollerInstance.rightControllerIndexFloat > 0.1;
            if (flag)
            {
                taggerInstance.offlineVRRig.enabled = false;
                taggerInstance.offlineVRRig.transform.position += new Vector3(0f, 0.075f, 0f);
                taggerInstance.offlineVRRig.transform.rotation = Quaternion.Euler(taggerInstance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                taggerInstance.offlineVRRig.leftHand.rigTarget.transform.position = taggerInstance.offlineVRRig.transform.position + taggerInstance.offlineVRRig.transform.right * -1f;
                taggerInstance.offlineVRRig.rightHand.rigTarget.transform.position = taggerInstance.offlineVRRig.transform.position + taggerInstance.offlineVRRig.transform.right * 1f;
            }
            else
            {
                taggerInstance.offlineVRRig.enabled = true;
            }
        }
    }
}
