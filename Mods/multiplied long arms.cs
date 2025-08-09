using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;

namespace StupidTemplate.Mods
{
    internal class multiplied_long_arms
    {
        public static float armlength = 1.25f;
        public static void MultipliedLongArms()
        {
            GTPlayer.Instance.leftControllerTransform.transform.position = GorillaTagger.Instance.headCollider.transform.position - (GorillaTagger.Instance.headCollider.transform.position - GorillaTagger.Instance.leftHandTransform.position) * armlength;
            GTPlayer.Instance.rightControllerTransform.transform.position = GorillaTagger.Instance.headCollider.transform.position - (GorillaTagger.Instance.headCollider.transform.position - GorillaTagger.Instance.rightHandTransform.position) * armlength;
        }
    }
}
