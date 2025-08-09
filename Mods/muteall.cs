using System;
using System.Collections.Generic;
using System.Text;

namespace AetherTemp.Menu
{
    internal class muteall
    {
        public static void MuteAll()
        {
            foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                if (!line.muteButton.isAutoOn)
                    line.PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);
            }
        }
        public static void UnmuteAll()
        {
            foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                if (line.muteButton.isAutoOn)
                    line.PressButton(false, GorillaPlayerLineButton.ButtonType.Mute);
            }
        }
    }
}
