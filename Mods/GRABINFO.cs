using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StupidTemplate.Mods
{
    internal class GRABINFO
    
   {
        public static void GrabPlayerInfo()
        {
            string text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                float r = 0f;
                float g = 0f;
                float b = 0f;
                try
                {
                    VRRig plr = GorillaGameManager.instance.FindPlayerVRRig(player);
                    r = plr.playerColor.r * 255;
                    g = plr.playerColor.r * 255;
                    b = plr.playerColor.r * 255;
                }
                catch { UnityEngine.Debug.Log("Failed to log colors, rig most likely nonexistent"); }
                try
                {
                    text += "\n====================================\n";
                    text += string.Concat(new string[]
                    {
                        "Player Name: \"",
                        player.NickName,
                        "\", Player ID: \"",
                        player.UserId,
                        "\", Player Color: (R: ",
                        r.ToString(),
                        ", G: ",
                        g.ToString(),
                        ", B: ",
                        b.ToString(),
                        ")"
                });
                }
                catch { UnityEngine.Debug.Log("Failed to log player"); }
            }
            text += "\n====================================\n";

            string fileName = "Nebula/" + PhotonNetwork.CurrentRoom.Name + " - Player Info.txt";
            if (!Directory.Exists("grabbed-info"))
            {
                Directory.CreateDirectory("Nebulas-Grabbed-info");
            }
            File.WriteAllText(fileName, text);

            string filePath = System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, fileName);
            filePath = filePath.Split("BepInEx\\")[0] + fileName;
 
            try
            {
                Process.Start(filePath);
            }
            catch
            {
                UnityEngine.Debug.Log("Could not open process " + filePath);
            }
        }

    }
}
