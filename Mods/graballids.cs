using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static StupidTemplate.Classes.RigManager;
using System.Text;

namespace AetherTemp.Mods
{
    internal class graballids
    {
        public static void GrabPlayerInfo()
        {
            string text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                float r = 0f;
                float g = 0f;
                float b = 0f;
                string cosmetics = "";
                try
                {
                    VRRig plr = GetVRRigFromPlayer(player);
                    r = plr.playerColor.r * 255;
                    g = plr.playerColor.g * 255;
                    b = plr.playerColor.b * 255;
                    cosmetics = plr.concatStringOfCosmeticsAllowed;
                }
                catch { }
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
                        "), Cosmetics: ",
                        cosmetics
                    });
                }
                catch {  }
            }
            text += "\n====================================\n";
            text += "Ids Logged";
            string fileName = $"{StupidTemplate.PluginInfo.Grabbedname}/PlayerInfo/" + PhotonNetwork.CurrentRoom.Name + ".txt";

            File.WriteAllText(fileName, text);

            string filePath = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, fileName);
            filePath = filePath.Split("BepInEx\\")[0] + fileName;

            Process.Start(filePath);
        }
    }
}
