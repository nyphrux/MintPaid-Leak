using System;
using System.Collections.Generic;
using System.Text;

namespace AetherTemp.Menu
{
    internal class grabrig
    {
        public static void GrabRig()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
            else
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                }
                else GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
    }
}
