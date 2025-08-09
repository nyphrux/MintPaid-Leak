using System;
using System.Collections.Generic;
using System.Text;
using static StupidTemplate.Settings;
using StupidTemplate;
using static StupidTemplate.Mods.Boards;
using StupidTemplate.Mods;
namespace AetherTemp.Menu
{
    internal class themechangedetecter
    {
        private static void UpdateThemeButtons()//helper method to not forget ig\
        {
            string newText = $"Change Theme ({ThemeSettings.GetCurrentThemeName()})";
            foreach (var category in Buttons.Players)
            {
                foreach (var button in category)
                {
                    if (button.buttonText.StartsWith("Change Theme"))
                    {
                        button.buttonText = newText;
                    }
                }
            }
        }

        public static class ThemeChecker
        {
            private static int lastThemeIndex = -1;

            public static void CheckAndUpdateTheme()
            {
                int currentIndex = ThemeSettings.GetCurrentThemeIndex();

                if (currentIndex != lastThemeIndex)
                {
                    lastThemeIndex = currentIndex;
                    Boards.UpdateMatchMenuThemeMaterial();
                
                }
            }
        }

    }
}
