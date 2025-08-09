using POpusCodec.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StupidTemplate.Mods
{
    internal class High_quality_mic
    {
        public static void HighQualityMicrophone()
        {
            Photon.Voice.Unity.Recorder mic = GameObject.Find("Photon Manager").GetComponent<Photon.Voice.Unity.Recorder>();
            mic.SamplingRate = SamplingRate.Sampling16000;
            mic.Bitrate = 30000;

            mic.RestartRecording(true);
        }
    }
}
