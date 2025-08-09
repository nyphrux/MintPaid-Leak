using UnityEngine;
using StupidTemplate.Classes;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate
{
    public static class Settings
    {
        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool animateTitle = true;
        public static bool pingcounter = true;
        public static bool version = false;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1.05f);
        public static int buttonsPerPage = 8;
    }

    internal class ThemeSettings : MonoBehaviour
    {



        private static GradientColorKey[] ShiftGradientHue(GradientColorKey[] keys, float hueShift)
        {
            GradientColorKey[] shifted = new GradientColorKey[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                shifted[i] = new GradientColorKey(ShiftHue(keys[i].color, hueShift), keys[i].time);
            }
            return shifted;
        }

        private static Color ShiftHue(Color color, float hueShift)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            h += hueShift;
            if (h > 1f) h -= 1f;
            return Color.HSVToRGB(h, s, v);
        }



        public static int GetCurrentThemeIndex() => currentThemeIndex;
        public static int GetThemeCount() => themes.Length;

        public static ExtGradient backgroundColor = new ExtGradient
        {
            isRainbow = false,
            colors = GetSolidGradient(new Color(0.02f, 0.05f, 0.04f))
        };

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient { colors = GetSolidGradient(new Color(0.08f, 0.12f, 0.10f)) },
            new ExtGradient { colors = GetSolidGradient(new Color(0.12f, 0.25f, 0.18f)) }
        };

        public static string GetCurrentThemeName()
        {
            return themes[currentThemeIndex].name;
        }

        public static Color[] textColors = new Color[]
        {
            new Color(0.75f, 0.80f, 0.75f),
            new Color(0.85f, 0.15f, 0.15f)
        };

        public static Color ButtonColor = new Color(0.12f, 0.25f, 0.18f);

        public static int currentThemeIndex = 0;

        public static (string name, ExtGradient background, ExtGradient[] buttonColors, Color[] textColors, Color buttonColor)[] themes =
      {
    // 1. Forest
    ("Forest",
        new ExtGradient { colors = GetSolidGradient(new Color(0.02f,0.05f,0.04f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.08f,0.12f,0.10f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.12f,0.25f,0.18f)) }
        },
        new[]{ new Color(0.75f,0.80f,0.75f), new Color(0.85f,0.15f,0.15f) },
        new Color(0.12f,0.25f,0.18f)
    ),

    // 2. Ocean Blue
    ("Ocean Blue",
        new ExtGradient { colors = GetSolidGradient(new Color(0.0f,0.15f,0.25f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.0f,0.3f,0.6f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.2f,0.7f,1.0f)) }
        },
        new[]{ new Color(0.8f,0.9f,1.0f), new Color(0.4f,0.9f,1.0f) },
        new Color(0.2f,0.7f,1.0f)
    ),

    // 3. Sunset
    ("Sunset",
        new ExtGradient { colors = GetSolidGradient(new Color(0.8f,0.3f,0.1f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(1f,0.5f,0.2f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.9f,0.2f,0.1f)) }
        },
        new[]{ new Color(1f,0.8f,0.6f), new Color(1f,0.4f,0.2f) },
        new Color(1f,0.5f,0.2f)
    ),

    // 4. Neon Green
    ("Neon Green",
        new ExtGradient { colors = GetSolidGradient(new Color(0.05f,0.2f,0.05f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.0f,0.8f,0.2f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.1f,1.0f,0.3f)) }
        },
        new[]{ new Color(0.7f,1.0f,0.7f), new Color(0.2f,1.0f,0.2f) },
        new Color(0.1f,0.9f,0.2f)
    ),

    // 5. Cyberpunk Purple
    ("Cyberpunk Purple",
        new ExtGradient { colors = GetSolidGradient(new Color(0.1f,0.0f,0.2f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.5f,0.0f,1.0f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.0f,0.8f)) }
        },
        new[]{ new Color(1.0f,0.7f,1.0f), new Color(0.8f,0.3f,1.0f) },
        new Color(0.8f,0.0f,1.0f)
    ),

    // 6. Ice / Arctic
    ("Ice / Arctic",
        new ExtGradient { colors = GetSolidGradient(new Color(0.1f,0.2f,0.3f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.2f,0.5f,0.9f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.5f,0.8f,1.0f)) }
        },
        new[]{ new Color(0.8f,0.9f,1.0f), new Color(0.6f,0.8f,1.0f) },
        new Color(0.3f,0.6f,1.0f)
    ),

    // 7. Candy Pink
    ("Candy Pink",
        new ExtGradient { colors = GetSolidGradient(new Color(0.3f,0.05f,0.1f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.2f,0.5f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.4f,0.6f)) }
        },
        new[]{ new Color(1.0f,0.6f,0.8f), new Color(1.0f,0.3f,0.6f) },
        new Color(1.0f,0.3f,0.6f)
    ),

    // 8. Matrix Green
    ("Matrix Green",
        new ExtGradient { colors = GetSolidGradient(new Color(0.0f,0.05f,0.0f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.0f,0.6f,0.0f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.0f,1.0f,0.0f)) }
        },
        new[]{ new Color(0.5f,1.0f,0.5f), new Color(0.0f,1.0f,0.0f) },
        new Color(0.0f,0.8f,0.0f)
    ),

    // 9. Lava
    ("Lava",
        new ExtGradient { colors = GetSolidGradient(new Color(0.2f,0.0f,0.0f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.7f,0.1f,0.0f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.4f,0.0f)) }
        },
        new[]{ new Color(1.0f,0.6f,0.3f), new Color(1.0f,0.3f,0.1f) },
        new Color(0.8f,0.2f,0.0f)
    ),

    // 10. Midnight
    ("Midnight",
        new ExtGradient { colors = GetSolidGradient(new Color(0.01f,0.01f,0.05f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.05f,0.05f,0.1f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.1f,0.1f,0.2f)) }
        },
        new[]{ new Color(0.6f,0.6f,0.8f), new Color(0.4f,0.4f,0.6f) },
        new Color(0.1f,0.1f,0.2f)
    ),

    // 11. Desert Sand (Beige-ish)
    ("Desert Sand",
        new ExtGradient { colors = GetSolidGradient(new Color(0.85f,0.78f,0.66f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.94f,0.88f,0.68f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.96f,0.90f,0.70f)) }
        },
        new[]{ new Color(0.55f,0.48f,0.36f), new Color(0.60f,0.50f,0.40f) },
        new Color(0.75f,0.65f,0.40f)
    ),

    // 12. Lilac
    ("Lilac",
        new ExtGradient { colors = GetSolidGradient(new Color(0.72f,0.56f,0.83f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.80f,0.70f,0.90f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.90f,0.80f,0.95f)) }
        },
        new[]{ new Color(0.4f,0.3f,0.5f), new Color(0.5f,0.4f,0.6f) },
        new Color(0.6f,0.4f,0.7f)
    ),

    // 13. Mint Green
    ("Mint Green",
        new ExtGradient { colors = GetSolidGradient(new Color(0.60f,0.85f,0.70f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.70f,0.95f,0.80f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.80f,1.0f,0.90f)) }
        },
        new[]{ new Color(0.3f,0.5f,0.3f), new Color(0.35f,0.6f,0.35f) },
        new Color(0.4f,0.7f,0.4f)
    ),

    // 14. Coral
    ("Coral",
        new ExtGradient { colors = GetSolidGradient(new Color(1.0f,0.5f,0.4f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.6f,0.5f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.7f,0.6f)) }
        },
        new[]{ new Color(0.6f,0.3f,0.2f), new Color(0.7f,0.4f,0.3f) },
        new Color(1.0f,0.55f,0.45f)
    ),

    // 15. Taupe
    ("Taupe",
        new ExtGradient { colors = GetSolidGradient(new Color(0.50f,0.45f,0.42f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.60f,0.55f,0.52f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.70f,0.65f,0.62f)) }
        },
        new[]{ new Color(0.3f,0.25f,0.20f), new Color(0.4f,0.35f,0.30f) },
        new Color(0.5f,0.45f,0.40f)
    ),

    // 16. Steel Blue
    ("Steel Blue",
        new ExtGradient { colors = GetSolidGradient(new Color(0.27f,0.51f,0.71f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.38f,0.60f,0.80f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.48f,0.70f,0.90f)) }
        },
        new[]{ new Color(0.8f,0.85f,0.9f), new Color(0.6f,0.65f,0.7f) },
        new Color(0.3f,0.5f,0.7f)
    ),

    // 17. Plum
    ("Plum",
        new ExtGradient { colors = GetSolidGradient(new Color(0.58f,0.44f,0.86f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.65f,0.50f,0.90f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.75f,0.60f,1.0f)) }
        },
        new[]{ new Color(0.3f,0.2f,0.5f), new Color(0.4f,0.3f,0.6f) },
        new Color(0.5f,0.35f,0.7f)
    ),

    // 18. Sandstone
    ("Sandstone",
        new ExtGradient { colors = GetSolidGradient(new Color(0.76f,0.70f,0.50f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.85f,0.80f,0.60f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.95f,0.90f,0.70f)) }
        },
        new[]{ new Color(0.65f,0.60f,0.40f), new Color(0.70f,0.65f,0.45f) },
        new Color(0.70f,0.65f,0.40f)
    ),

    // 19. Warm Gray
    ("Warm Gray",
        new ExtGradient { colors = GetSolidGradient(new Color(0.66f,0.60f,0.58f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.75f,0.70f,0.68f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.85f,0.80f,0.78f)) }
        },
        new[]{ new Color(0.45f,0.40f,0.38f), new Color(0.50f,0.45f,0.43f) },
        new Color(0.60f,0.55f,0.53f)
    ),

    // 20. Beige
    ("Beige",
        new ExtGradient { colors = GetSolidGradient(new Color(0.96f,0.96f,0.86f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.98f,0.98f,0.90f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,1.0f,0.95f)) }
        },
        new[]{ new Color(0.65f,0.65f,0.55f), new Color(0.70f,0.70f,0.60f) },
        new Color(0.80f,0.80f,0.70f)
    ),

    // 21. Coffee Brown
    ("Coffee Brown",
        new ExtGradient { colors = GetSolidGradient(new Color(0.4f,0.26f,0.13f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.5f,0.35f,0.20f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.6f,0.45f,0.25f)) }
        },
        new[]{ new Color(0.3f,0.20f,0.10f), new Color(0.35f,0.25f,0.15f) },
        new Color(0.45f,0.30f,0.15f)
    ),

    // 22. Steel Gray
    ("Steel Gray",
        new ExtGradient { colors = GetSolidGradient(new Color(0.35f,0.4f,0.45f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.45f,0.50f,0.55f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.55f,0.60f,0.65f)) }
        },
        new[]{ new Color(0.75f,0.8f,0.85f), new Color(0.55f,0.6f,0.65f) },
        new Color(0.45f,0.50f,0.55f)
    ),

    // 23. Pale Blue
    ("Pale Blue",
        new ExtGradient { colors = GetSolidGradient(new Color(0.68f,0.85f,0.90f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.78f,0.90f,0.95f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.88f,0.95f,1.0f)) }
        },
        new[]{ new Color(0.4f,0.6f,0.7f), new Color(0.5f,0.7f,0.8f) },
        new Color(0.55f,0.75f,0.85f)
    ),

    // 24. Rose
    ("Rose",
        new ExtGradient { colors = GetSolidGradient(new Color(0.85f,0.50f,0.55f)) },
        new []{
            new ExtGradient{ colors=GetSolidGradient(new Color(0.90f,0.60f,0.65f)) },
            new ExtGradient{ colors=GetSolidGradient(new Color(0.95f,0.70f,0.75f)) }
        },
        new[]{ new Color(0.50f,0.25f,0.30f), new Color(0.55f,0.30f,0.35f) },
        new Color(0.80f,0.40f,0.45f)
                ),
    ("Warm Taupe",
    new ExtGradient { colors = GetSolidGradient(new Color(0.59f,0.51f,0.45f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.69f,0.61f,0.55f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.79f,0.71f,0.65f)) }
    },
    new[]{ new Color(0.38f,0.31f,0.26f), new Color(0.45f,0.37f,0.31f) },
    new Color(0.65f,0.56f,0.49f)
),

// 26. Dusty Rose
("Dusty Rose",
    new ExtGradient { colors = GetSolidGradient(new Color(0.64f,0.46f,0.49f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.74f,0.56f,0.59f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.84f,0.66f,0.69f)) }
    },
    new[]{ new Color(0.35f,0.22f,0.25f), new Color(0.45f,0.30f,0.33f) },
    new Color(0.70f,0.50f,0.53f)
),

// 27. Slate Blue
("Slate Blue",
    new ExtGradient { colors = GetSolidGradient(new Color(0.42f,0.50f,0.70f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.52f,0.60f,0.80f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.62f,0.70f,0.90f)) }
    },
    new[]{ new Color(0.72f,0.79f,0.90f), new Color(0.52f,0.59f,0.70f) },
    new Color(0.35f,0.40f,0.55f)
),

// 28. Olive Drab
("Olive Drab",
    new ExtGradient { colors = GetSolidGradient(new Color(0.42f,0.43f,0.20f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.52f,0.53f,0.30f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.62f,0.63f,0.40f)) }
    },
    new[]{ new Color(0.30f,0.30f,0.15f), new Color(0.40f,0.40f,0.25f) },
    new Color(0.45f,0.46f,0.22f)
),

// 29. Sepia
("Sepia",
    new ExtGradient { colors = GetSolidGradient(new Color(0.44f,0.26f,0.11f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.54f,0.36f,0.21f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.64f,0.46f,0.31f)) }
    },
    new[]{ new Color(0.35f,0.18f,0.07f), new Color(0.45f,0.28f,0.17f) },
    new Color(0.56f,0.33f,0.16f)
),

// 30. Periwinkle
("Periwinkle",
    new ExtGradient { colors = GetSolidGradient(new Color(0.62f,0.66f,0.91f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.72f,0.76f,0.95f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.82f,0.86f,1.0f)) }
    },
    new[]{ new Color(0.45f,0.50f,0.70f), new Color(0.55f,0.60f,0.80f) },
    new Color(0.52f,0.58f,0.88f)
),

// 31. Rust
("Rust",
    new ExtGradient { colors = GetSolidGradient(new Color(0.72f,0.25f,0.17f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.82f,0.35f,0.27f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.92f,0.45f,0.37f)) }
    },
    new[]{ new Color(0.45f,0.15f,0.07f), new Color(0.55f,0.25f,0.17f) },
    new Color(0.75f,0.30f,0.22f)
),

// 32. Moss Green
("Moss Green",
    new ExtGradient { colors = GetSolidGradient(new Color(0.44f,0.57f,0.29f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.54f,0.67f,0.39f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.64f,0.77f,0.49f)) }
    },
    new[]{ new Color(0.35f,0.46f,0.19f), new Color(0.45f,0.56f,0.29f) },
    new Color(0.60f,0.70f,0.40f)
),

// 33. Charcoal
("Charcoal",
    new ExtGradient { colors = GetSolidGradient(new Color(0.20f,0.20f,0.20f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.30f,0.30f,0.30f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.40f,0.40f,0.40f)) }
    },
    new[]{ new Color(0.75f,0.75f,0.75f), new Color(0.55f,0.55f,0.55f) },
    new Color(0.25f,0.25f,0.25f)
),

// 34. Coral Reef
("Coral Reef",
    new ExtGradient { colors = GetSolidGradient(new Color(0.99f,0.56f,0.56f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.66f,0.66f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.76f,0.76f)) }
    },
    new[]{ new Color(0.80f,0.40f,0.40f), new Color(0.90f,0.50f,0.50f) },
    new Color(0.95f,0.55f,0.55f)
),

// 35. Blue Gray
("Blue Gray",
    new ExtGradient { colors = GetSolidGradient(new Color(0.40f,0.50f,0.60f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.50f,0.60f,0.70f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.60f,0.70f,0.80f)) }
    },
    new[]{ new Color(0.80f,0.85f,0.90f), new Color(0.70f,0.75f,0.80f) },
    new Color(0.45f,0.55f,0.65f)
),

// 36. Wheat
("Wheat",
    new ExtGradient { colors = GetSolidGradient(new Color(0.96f,0.87f,0.70f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.98f,0.91f,0.74f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.95f,0.80f)) }
    },
    new[]{ new Color(0.75f,0.67f,0.50f), new Color(0.85f,0.77f,0.60f) },
    new Color(0.90f,0.82f,0.65f)
),

// 37. Mauve
("Mauve",
    new ExtGradient { colors = GetSolidGradient(new Color(0.88f,0.69f,0.75f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.94f,0.79f,0.85f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.89f,0.95f)) }
    },
    new[]{ new Color(0.55f,0.42f,0.48f), new Color(0.65f,0.52f,0.58f) },
    new Color(0.80f,0.59f,0.65f)
),

// 38. Blue Steel
("Blue Steel",
    new ExtGradient { colors = GetSolidGradient(new Color(0.40f,0.55f,0.65f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.50f,0.65f,0.75f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.60f,0.75f,0.85f)) }
    },
    new[]{ new Color(0.80f,0.90f,0.95f), new Color(0.60f,0.70f,0.75f) },
    new Color(0.45f,0.60f,0.70f)
),

// 39. Burnt Sienna
("Burnt Sienna",
    new ExtGradient { colors = GetSolidGradient(new Color(0.91f,0.45f,0.32f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.95f,0.55f,0.42f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.65f,0.52f)) }
    },
    new[]{ new Color(0.70f,0.30f,0.17f), new Color(0.80f,0.40f,0.27f) },
    new Color(0.90f,0.50f,0.35f)
),

// 40. Light Sage
("Light Sage",
    new ExtGradient { colors = GetSolidGradient(new Color(0.71f,0.78f,0.68f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(0.81f,0.88f,0.78f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(0.91f,0.98f,0.88f)) }
    },
    new[]{ new Color(0.50f,0.55f,0.40f), new Color(0.60f,0.65f,0.50f) },
    new Color(0.70f,0.75f,0.60f)
),

// 41. Antique White
("Antique White",
    new ExtGradient { colors = GetSolidGradient(new Color(0.98f,0.92f,0.84f)) },
    new []{
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.96f,0.90f)) },
        new ExtGradient{ colors=GetSolidGradient(new Color(1.0f,0.98f,0.95f)) }
    },
    new[]{ new Color(0.65f,0.55f,0.40f), new Color(0.75f,0.65f,0.50f) },
    new Color(0.85f,0.75f,0.60f)
),

("Dusty Blue",
    new ExtGradient { colors = GetSolidGradient(new Color(0.58f,0.66f,0.74f)) },
    new []{
        new ExtGradient{ colors = GetSolidGradient(new Color(0.68f,0.76f,0.84f)) },
        new ExtGradient{ colors = GetSolidGradient(new Color(0.78f,0.86f,0.94f)) }
    },
    new[]{ new Color(0.40f,0.48f,0.56f), new Color(0.50f,0.58f,0.66f) },
    new Color(0.60f,0.68f,0.76f)
),
};

        public static void NextTheme()
        {
            currentThemeIndex = (currentThemeIndex + 1) % themes.Length;
            ApplyTheme(currentThemeIndex);
        }

        public static void ApplyTheme(int index)
        {
            var theme = themes[index];
            backgroundColor = theme.background;
            buttonColors = theme.buttonColors;
            textColors = theme.textColors;
            ButtonColor = theme.buttonColor;

          
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[]
            {
                new GradientColorKey(color, 0f),
                new GradientColorKey(color, 1f)
            };
        }
    }
}
