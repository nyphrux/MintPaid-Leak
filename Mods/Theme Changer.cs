using UnityEngine;

namespace YourNamespace
{
    // Define ExtGradient with GradientColorKey[] colors
    public class ExtGradient
    {
        public bool isRainbow;
        public GradientColorKey[] colors;
    }

    // Static class holding current menu colors
    public static class MenuColors
    {
        public static ExtGradient backgroundColor;
        public static ExtGradient[] buttonColors;
        public static Color[] textColors;
        public static Color ButtonColor;
    }

    // Theme manager class
    public static class MenuThemes
    {
        // Helper: Create a solid gradient with same color at 0 and 1
        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[]
            {
                new GradientColorKey(color, 0f),
                new GradientColorKey(color, 1f)
            };
        }

        // List of themes: background, buttons, text colors, button highlight
        public static (ExtGradient bg, ExtGradient[] buttons, Color[] text, Color buttonColor)[] Themes =
        {
            (
                new ExtGradient
                {
                    isRainbow = false,
                    colors = GetSolidGradient(new Color(0.02f, 0.05f, 0.04f)) // Dark evergreen
                },
                new ExtGradient[]
                {
                    new ExtGradient
                    {
                        colors = GetSolidGradient(new Color(0.08f, 0.12f, 0.10f)) // Disabled button
                    },
                    new ExtGradient
                    {
                        isRainbow = false,
                        colors = GetSolidGradient(new Color(0.12f, 0.25f, 0.18f)) // Enabled button
                    }
                },
                new Color[]
                {
                    new Color(0.75f, 0.80f, 0.75f), // Disabled text
                    new Color(0.85f, 0.15f, 0.15f)  // Enabled text (dark candy red)
                },
                new Color(0.12f, 0.25f, 0.18f) // Button highlight
            ),

            (
                new ExtGradient
                {
                    isRainbow = false,
                    colors = GetSolidGradient(new Color(0.03f, 0.06f, 0.09f)) // Frozen winter bg
                },
                new ExtGradient[]
                {
                    new ExtGradient
                    {
                        colors = GetSolidGradient(new Color(0.10f, 0.15f, 0.20f)) // Disabled button
                    },
                    new ExtGradient
                    {
                        isRainbow = false,
                        colors = GetSolidGradient(new Color(0.25f, 0.55f, 0.90f)) // Enabled button
                    }
                },
                new Color[]
                {
                    new Color(0.80f, 0.85f, 0.90f), // Disabled text
                    Color.white                     // Enabled text
                },
                new Color(0.25f, 0.55f, 0.90f) // Button highlight
            )
        };

        public static int CurrentThemeIndex = 0;

        public static void ApplyTheme()
        {
            var theme = Themes[CurrentThemeIndex];

            MenuColors.backgroundColor = theme.bg;
            MenuColors.buttonColors = theme.buttons;
            MenuColors.textColors = theme.text;
            MenuColors.ButtonColor = theme.buttonColor;
        }

        public static void NextTheme()
        {
            CurrentThemeIndex = (CurrentThemeIndex + 1) % Themes.Length;
            ApplyTheme();
        }
    }
}
