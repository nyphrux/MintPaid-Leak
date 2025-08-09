using System;
using System.Collections.Generic;
using Aeth.Mods;
using AetherTemp.Mods;
using StupidTemplate;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using static AetherTemp.Menu.themechangedetecter;


namespace AetherTemp.Menu
{
    internal class Buttons
    {
        public static List<ButtonInfo> playerButtons = new List<ButtonInfo>();

        public static ButtonInfo[][] Players = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.MainSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "advantages", method =() => SettingsMods.advantages(), isTogglable = false, toolTip = "Opens the advantages page for the menu."},
                new ButtonInfo { buttonText = "Join Discord", method = () => JoinDiscord.joinDiscord(), isTogglable = false, toolTip = "Opens the Discord." },
                new ButtonInfo { buttonText = "visuals", method =() => SettingsMods.visuals(), isTogglable = false, toolTip = "Opens the visuals page for the menu."},
                new ButtonInfo { buttonText = "movement", method =() => SettingsMods.movement(), isTogglable = false, toolTip = "Opens the movement page for the menu."},
                new ButtonInfo { buttonText = "Teleport Mods", method =() => SettingsMods.Teleportmods(), isTogglable = false, toolTip = "Opens the overpowered page for the menu."},
                new ButtonInfo { buttonText = "overpowered", method =() => SettingsMods.overpowered(), isTogglable = false, toolTip = "Opens the overpowered page for the menu."},
                new ButtonInfo { buttonText = "safety", method =() => SettingsMods.safety(), isTogglable = false, toolTip = "Opens the safety page for the menu."},
                new ButtonInfo { buttonText = "Fun", method =() => SettingsMods.fun(), isTogglable = false, toolTip = "Opens the fun page for the menu."},
                new ButtonInfo { buttonText = "guardian", method =() => SettingsMods.guardian(), isTogglable = false, toolTip = "Opens the guardian page for the menu."},
            },
           

            new ButtonInfo[] { // Main Settings
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Stump Text", enableMethod = () => FloatingStumpText.StumpText(), disableMethod = () => FloatingStumpText.Restore(), toolTip = "Spawns Stump text. Creds To Glxy" },
                new ButtonInfo { buttonText = $"Stump Text Color ({FloatingStumpText.CurrentColorName})", method = () => { FloatingStumpText.NextColor(); foreach (var category in Buttons.Players) foreach (var button in category) if (button.buttonText.StartsWith("Stump Text Color")) button.buttonText = $"Stump Text Color ({FloatingStumpText.CurrentColorName})"; }, isTogglable = false, toolTip = "Cycles the floating stump text color dynamically." },
                new ButtonInfo { buttonText = "Boards <color=green><b>(UND)</b></color>", enableMethod = ()  =>   Boards.SetMOTDText(), disableMethod = () =>  Boards.ResetMOTDText(),  toolTip = "Puts the menu on your right hand." },
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the Menu settings for the menu."},
                new ButtonInfo { buttonText = "Visual Settings", method =() => SettingsMods.VisualSettings(), isTogglable = false, toolTip = "Opens the GunLib settings for the menu."},
                new ButtonInfo { buttonText = "GunLib Settings", method =() => SettingsMods.GunLib(), isTogglable = false, toolTip = "Opens the GunLib settings for the menu."},
                new ButtonInfo { buttonText = "Notifications Settings", method =() => SettingsMods.Notification(), isTogglable = false, toolTip = "Opens the GunLib settings for the menu."},
                new ButtonInfo { buttonText = "Projectile Settings", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the GunLib settings for the menu."},
            },

            new ButtonInfo[] { // Advantages
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "placeholder", method =() => Mutegun.placeholder(), isTogglable = false, toolTip = "placeholder."},
            },

           new ButtonInfo[] { // Movement
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Platforms", method = () => platforms.Platforms(), toolTip = "Platforms <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "copy gun", method = () => Riggun.Copygun(), toolTip = "Platforms <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Rig Gun / Tp gun", method =() => Riggun.GunTemplate(), isTogglable = true, toolTip = "Make not appear for The gun."},
                new ButtonInfo { buttonText = "Hold Rig", method =() => grabrig.GrabRig(), isTogglable = true, toolTip = "Make not appear for The gun."},
                new ButtonInfo { buttonText = "Multipiled Long Arms", method = () => multiplied_long_arms.MultipliedLongArms(), toolTip = "MultipIled Long Arms <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Steam Long Arms", method = () => steam_long_arms.SteamLongArms(), toolTip = "Steam Long Arms <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Reset Arms", method = () => reset_arms.NormalArms(), toolTip = "Resets Arm lengths <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Insta Hand Taps", method = () => insta_hand_taps.EnableInstantHandTaps(), toolTip = "Insta hand taps <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Disable Hand Taps", method = () => disable_insta_hand_taps.DisableInstantHandTaps(), toolTip = "Disable Insta hand taps <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Legit Speedboost", method = () => speedboost.SpeedBoostMod(), toolTip = "Speed boost <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Dynamically Changing Speedboost", method = () => IncreasingSpeedBoost.DynamicSpeedBoost(), toolTip = "Changes speedboost when needed <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Fly", method = () => fly.Fly(), toolTip = "Fly <3 D", isTogglable = true },
                new ButtonInfo { buttonText = "Trigger Fly", method = () => TriggerFly.triggerFly(), toolTip = "Use Triggers to fly <3 D", isTogglable = true },
                new ButtonInfo { buttonText = "Strong Wall Walk", method = () => strongwallwalk.StrongWallWalk(), toolTip = "Wall cling on grip <3 UND" },
                new ButtonInfo { buttonText = "Rewind", method = () => rewind.Rewind(), toolTip = "Use Triggers to fly <3 D", isTogglable = true },
                new ButtonInfo { buttonText = "Helicopter", method = () => helicopter.HelicopterMonke(), toolTip = "Use Triggers to fly <3 D", isTogglable = true },
           },


            new ButtonInfo[] { // visuals
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Dark Blue Stump", enableMethod = ()  =>   Darkbluestump.Bluestump(), disableMethod = () =>  Darkbluestump.RestoreStump(),  toolTip = "Puts the menu on your right hand." },
                new ButtonInfo { buttonText = "Globe Esp", method = () => triangleesp.Triangle(), toolTip = "ESP <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "3d Globe Esp", method = () => triangleesp.triangle3d(), toolTip = "ESP <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Set Rain <color=green><b>(UND)</b></color>", method = () => set_rain.MakeRain(), toolTip = "Rain <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "No Rain <color=green><b>(UND)</b></color>", method = () => no_rain.NoRain(), toolTip = "No Rain <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Set Day <color=green><b>(UND)</b></color>", method = () => daytime.DayTime(), toolTip = "Day <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Set Night <color=green><b>(UND)</b></color>", method = () => Night.NightTime(), toolTip = "Night <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Gray Sky", method = () => skyboxes.GraySky(), isTogglable = true, toolTip = "Sets sky to gray." },
                new ButtonInfo { buttonText = "Magenta Sky", method = () => skyboxes.MagentaSky(), isTogglable = true, toolTip = "Sets sky to magenta." },
                new ButtonInfo { buttonText = "Red Sky", method = () => skyboxes.RedSky(), isTogglable = true, toolTip = "Sets sky to red." },
                new ButtonInfo { buttonText = "Blue Sky", method = () => skyboxes.BlueSky(), isTogglable = true, toolTip = "Sets sky to blue." },
                new ButtonInfo { buttonText = "Green Sky", method = () => skyboxes.GreenSky(), isTogglable = true, toolTip = "Sets sky to green." },
                new ButtonInfo { buttonText = "Yellow Sky", method = () => skyboxes.YellowSky(), isTogglable = true, toolTip = "Sets sky to yellow." },
                new ButtonInfo { buttonText = "Cyan Sky", method = () => skyboxes.CyanSky(), isTogglable = true, toolTip = "Sets sky to cyan." },
                new ButtonInfo { buttonText = "Black Sky", method = () => skyboxes.BlackSky(), isTogglable = true, toolTip = "Sets sky to black." },
                new ButtonInfo { buttonText = "White Sky", method = () => skyboxes.WhiteSky(), isTogglable = true, toolTip = "Sets sky to white." },
                new ButtonInfo { buttonText = "RGB Sky", method = () => skyboxes.RGBSkybox(), isTogglable = false, toolTip = "Sets sky to white." },
                new ButtonInfo { buttonText = "Reset Sky", method = () => skyboxes.RestoreOriginalSky(), isTogglable = false, toolTip = "Sets sky to white." },
                new ButtonInfo { buttonText = "heart(cs)", method =() => Heart.heart(), isTogglable = true, toolTip = "cs Heart Forest"},
                new ButtonInfo { buttonText = "Notrees(cs)", method =() => removetrees.notrees(), isTogglable = true, toolTip = "no trees"},
                new ButtonInfo { buttonText = "No Slide(cs)", method =() => removeslide.disableslide(), isTogglable = true, toolTip = "no slide"},
                new ButtonInfo { buttonText = "No leaves(cs)", method =() => noleaves.Removeallleaves(), isTogglable = true, toolTip = "no leaves"},
                new ButtonInfo { buttonText = "Chams Infected", method = () => box_esp.ESP(), toolTip = "ESP <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Chams Rgb", method = () => rgbchams.Rgbchamsfr(), toolTip = "ESP <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Clean Chams", method = () => disable_chams.DisableAllChams(), toolTip = "Deletes All Chams Shaders <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Tracers", method = () => Tracers.tracers(), toolTip = "Tracers <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Strobe", method = () => strobe.Strobe(), toolTip = "Strobe <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Bone ESP", method = () => boneesp.bone(), toolTip = "Bone Esp <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Launch Rocket", method = () => Launchrockets.LaunchRocket(), toolTip = "Launch Rockets <3 UND", isTogglable = true },
            },

            new ButtonInfo[] { // overpowered
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Unlock All", method =() => ua.UnlockAll(), isTogglable = false, toolTip = "Opens the home for the menu."},
                new ButtonInfo { buttonText = "Tag Aura", method = () => Nebulas_tagaura.TagAura(), toolTip = "Tag Aura <3 Und", isTogglable = true },
                new ButtonInfo { buttonText = "Tag Self", method = () => tagself.TagSelf(), toolTip = "Tag Rig <3 Und", isTogglable = true },
                new ButtonInfo { buttonText = "Tag gun", method = () => ghostmonke.Ghost(), toolTip = "Ghost <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Disable Network Triggers", method = () => disable_network_triggers.DisableNetworkTriggers(), toolTip = "Bypass trigger disconnects <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "No Tag On Join", method = () => notagonjoin.NoTagOnJoin(), toolTip = "No Tag On Join <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Ghost Monke", method = () => ghostmonke.Ghost(), toolTip = "Ghost <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Grab Doug", method = () => grabdug.GrabBug(), toolTip = "Grab Bug <3 UND", isTogglable = true },
            },

            new ButtonInfo[] { // safety
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "USW Servers", method = () => use_server.USWServers(), toolTip = "Connected To USW <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "EU Servers", method = () => us_e_servers.EUServers(), toolTip = "Connected To EU <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Flush Rpcs", method = () => rpcgetindexshit.flush(), toolTip = "Connected To USW <3 UND", isTogglable = false },
                new ButtonInfo { buttonText = "Anti Rpc Ban", method = () => RPCBypass.EnableNoLimitRPCs(),disableMethod = () => RPCBypass.Resetrpcbypasser(), isTogglable = true },
                new ButtonInfo { buttonText = "Anti Report", method = () => Antireportvisualizer.AntiReport(), toolTip = "Connected To USW <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Name Prefix [Mint]", method = () => NameTagUtils.MenuNameTags(), toolTip = "Connected To USW <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Grab All Player Info", method = () => GRABINFO.GrabPlayerInfo(), toolTip = "Grabbed by Nebula <3 UND", isTogglable = false },
            },

            new ButtonInfo[] { // Visual settings
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = $"Detection Distance ({Antireportvisualizer.distanceNames[Antireportvisualizer.currentDistanceIndex]})", method = () => { Antireportvisualizer.currentDistanceIndex = (Antireportvisualizer.currentDistanceIndex + 1) % Antireportvisualizer.distanceNames.Count; string newSize = Antireportvisualizer.distanceNames[Antireportvisualizer.currentDistanceIndex]; Antireportvisualizer.DistanceChanger(newSize); foreach (var category in Buttons.Players) foreach (var button in category) if (button.buttonText.StartsWith("Detection Distance")) button.buttonText = $"Detection Distance ({newSize})"; }, isTogglable = false, toolTip = "Cycle the detection distance for anti-report sphere." },
            },

            new ButtonInfo[] { // Teleport mods
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "TP to Stump", method = () => TeleportMods.tptostumps(), isTogglable = true, toolTip = "Teleports you to the Stump." },
                new ButtonInfo { buttonText = "TP to City", method = () => TeleportMods.TpToCity(), isTogglable = true, toolTip = "Teleports you to the City." },
                new ButtonInfo { buttonText = "TP to Mountains", method = () => TeleportMods.tptomountains(), isTogglable = true, toolTip = "Teleports you to the Mountains." },
                new ButtonInfo { buttonText = "TP to Tutorial", method = () => TeleportMods.TpToTut(), isTogglable = true, toolTip = "Teleports you to the Tutorial." },
                new ButtonInfo { buttonText = "TP to Clouds", method = () => TeleportMods.Tptolouds(), isTogglable = true, toolTip = "Teleports you to the Clouds." },
            },

            new ButtonInfo[] { // fun
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Mute Gun", method = () => mutegun.Mutegun(), toolTip = "ESP <3 UND", isTogglable = true },
                new ButtonInfo { buttonText = "Projectiles", method =() => SettingsMods.Projectiles(), isTogglable = false, toolTip = "placeholder."},
                new ButtonInfo { buttonText = "Particles", method =() => SettingsMods.Particles(), isTogglable = false, toolTip = "placeholder."},
            },

            new ButtonInfo[] { // guardian
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},
            },

            new ButtonInfo[] { // GunLib
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = $"Smoothness: {(Mutegun.num == 5f ? "Very Fast" : Mutegun.num == 10f ? "Normal" : "Super Smooth")}", method = () => { Mutegun.GunSmoothNess(); foreach (var category in Buttons.Players) foreach (var button in category) if (button.buttonText.StartsWith("Smoothness")) button.buttonText = $"Smoothness: {(Mutegun.num == 5f ? "Super Smooth" : Mutegun.num == 10f ? "Normal" : "No Smooth")}"; }, isTogglable = false, toolTip = "Changes gun smoothness." },
                new ButtonInfo { buttonText = $"Gun Color: {Mutegun.currentGunColor.name}", method = () => { Mutegun.CycleGunColor(); Buttons.Players.ForEach(category => category.ForEach(button => { if (button.buttonText.StartsWith("Gun Color")) button.buttonText = $"Gun Color: {Mutegun.currentGunColor.name}"; })); }, isTogglable = false, toolTip = "Cycles through gun colors." },
                new ButtonInfo { buttonText = $"Toggle Sphere Size: {(Mutegun.isSphereEnabled ? "Enabled" : "Disabled")}", method = () => { Mutegun.isSphereEnabled = !Mutegun.isSphereEnabled; if (Mutegun.GunSphere != null) Mutegun.GunSphere.transform.localScale = Mutegun.isSphereEnabled ? new Vector3(0.1f, 0.1f, 0.1f) : new Vector3(0f, 0f, 0f); foreach (var category in Buttons.Players) foreach (var button in category) if (button.buttonText.StartsWith("Toggle Sphere Size")) button.buttonText = $"Toggle Sphere Size: {(Mutegun.isSphereEnabled ? "Enabled" : "Disabled")}"; }, isTogglable = false, toolTip = "Toggles the size of the gun sphere." }
            },

            new ButtonInfo[] { // MenuSettings
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Menu Trail <color=green><b>(UND)</b></color>", method = () => MenuPhysicsMods.InitMenuTrail(), isTogglable = true, toolTip = "Adds a smooth cyan trail behind your menu." },
                new ButtonInfo { buttonText = "Spin Menu X<color=green><b>(UND)</b></color>", enableMethod = () => { StupidTemplate.Menu.Main.spinmenux = true; AetherTemp.Menu.MenuPhysicsMods.SpinMenuz(); }, disableMethod = () => StupidTemplate.Menu.Main.spinmenux = false, toolTip = "Make the menu spin slowly." },
                new ButtonInfo { buttonText = "Spin Menu Y <color=green><b>(UND)</b></color>", enableMethod = () => { StupidTemplate.Menu.Main.spinmenuy = true; AetherTemp.Menu.MenuPhysicsMods.SpinMenuz(); }, disableMethod = () => StupidTemplate.Menu.Main.spinmenuy = false, toolTip = "Make the menu spin slowly." },
                new ButtonInfo { buttonText = "Spin Menu Z <color=green><b>(UND)</b></color>", enableMethod = () => { StupidTemplate.Menu.Main.spinmenuz = true; AetherTemp.Menu.MenuPhysicsMods.SpinMenuz(); }, disableMethod = () => StupidTemplate.Menu.Main.spinmenuz = false, toolTip = "Make the menu spin slowly." },
                new ButtonInfo { buttonText = "Orbit Menu <color=green><b>(UND)</b></color>", enableMethod = () => StupidTemplate.Menu.Main.orbitEnabled = true, disableMethod = () => StupidTemplate.Menu.Main.orbitEnabled = false, toolTip = "Menu orbits around the player." },
                new ButtonInfo { buttonText = " Menu Trail", enableMethod = () => StupidTemplate.Menu.Main.Trailmenu = true, disableMethod = () => StupidTemplate.Menu.Main.Trailmenu = false, toolTip = "Smoothly fade out and despawn the menu." },
                new ButtonInfo { buttonText = $"Orbit Speed ({MenuPhysicsMods.orbitSpeed:0.##})", method = () => { if (MenuPhysicsMods.orbitSpeed < 30f) MenuPhysicsMods.UpdateOrbit("normal"); else if (MenuPhysicsMods.orbitSpeed == 30f) MenuPhysicsMods.UpdateOrbit("faster"); else if (MenuPhysicsMods.orbitSpeed > 30f && MenuPhysicsMods.orbitSpeed < 90f) MenuPhysicsMods.UpdateOrbit("superfast"); else if (MenuPhysicsMods.orbitSpeed >= 90f) MenuPhysicsMods.UpdateOrbit("ultrafast"); foreach (var cat in Buttons.Players) foreach (var btn in cat) if (btn.buttonText.StartsWith("Orbit Speed")) btn.buttonText = $"Orbit Speed ({MenuPhysicsMods.orbitSpeed:0.##})"; }, isTogglable = false, toolTip = "Cycles orbit speeds: normal, faster, superfast, ultrafast." },
                new ButtonInfo { buttonText = $"Change Tap Sound ({ButtonTapChanger.CurrentSoundID} {ButtonTapChanger.CurrentSoundName})", method = () => { ButtonTapChanger.NextSound(); foreach (var category in Buttons.Players) foreach (var button in category) if (button.buttonText.StartsWith("Change Tap Sound")) button.buttonText = $"Change Tap Sound ({ButtonTapChanger.CurrentSoundID} {ButtonTapChanger.CurrentSoundName})"; }, isTogglable = false, toolTip = "Cycles through available Gorilla Tag tap sounds." },
                new ButtonInfo { buttonText = $"Back Theme ({ThemeSettings.GetCurrentThemeName()})", method = () => { ThemeSettings.currentThemeIndex = (ThemeSettings.currentThemeIndex - 1 + ThemeSettings.GetThemeCount()) % ThemeSettings.GetThemeCount(); ThemeSettings.ApplyTheme(ThemeSettings.currentThemeIndex); ThemeChecker.CheckAndUpdateTheme(); foreach (var category in Buttons.Players) foreach (var button in category) { if (button.buttonText.StartsWith("Back Theme")) button.buttonText = $"Back Theme ({ThemeSettings.GetCurrentThemeName()})"; if (button.buttonText.StartsWith("Forward Theme")) button.buttonText = $"Forward Theme ({ThemeSettings.GetCurrentThemeName()})"; } }, isTogglable = false, toolTip = "Cycles to the previous theme." },
                new ButtonInfo { buttonText = $"Forward Theme ({ThemeSettings.GetCurrentThemeName()})", method = () => { ThemeSettings.NextTheme(); ThemeChecker.CheckAndUpdateTheme(); foreach (var category in Buttons.Players) foreach (var button in category) { if (button.buttonText.StartsWith("Forward Theme")) button.buttonText = $"Forward Theme ({ThemeSettings.GetCurrentThemeName()})"; if (button.buttonText.StartsWith("Back Theme")) button.buttonText = $"Back Theme ({ThemeSettings.GetCurrentThemeName()})"; } }, isTogglable = false, toolTip = "Cycles through available themes." },
                new ButtonInfo { buttonText = "Toggle Hue Shift", method = () => { Settings.animateTitle = !Settings.animateTitle; if (!Settings.animateTitle) ThemeSettings.ApplyTheme(ThemeSettings.GetCurrentThemeIndex()); }, isTogglable = true, toolTip = "Enable or disable smooth hue shifting of theme colors" },
                new ButtonInfo { buttonText = "Right/Left Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = Settings.fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Ping Counter", enableMethod =() => SettingsMods.EnablePingCounter(), disableMethod =() => SettingsMods.DisablePingCounter(), enabled = Settings.pingcounter, toolTip = "Toggles the Ping counter."},
                new ButtonInfo { buttonText = "Animated Text", enableMethod =() => SettingsMods.EnableAnimText(), disableMethod =() => SettingsMods.DisableAnimText(), enabled =      Settings.animateTitle, toolTip = "Toggles the Animated Text."},
                new ButtonInfo { buttonText = "Display Version", enableMethod =() => SettingsMods.EnableversionCounter(), disableMethod =() => SettingsMods.DisableversionCounter(), enabled = true, toolTip = "Displays Version."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = Settings.disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Notifications
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !Settings.disableNotifications, toolTip = "Toggles the notifications."},
            },

            new ButtonInfo[] { // proj settings
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "placeholder", method =() => Mutegun.placeholder(), isTogglable = true, toolTip = "placeholder."},


            },

            new ButtonInfo[] { // projectiles

                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "placeholder", method =() => Mutegun.placeholder(), isTogglable = true, toolTip = "placeholder."},

            },

            new ButtonInfo[] { // projectiles
                new ButtonInfo { buttonText = "Home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},

                new ButtonInfo { buttonText = "Explosion", method =() => Particles.CreateDomain(), isTogglable = true, toolTip = "makes a Explosion."},
                new ButtonInfo { buttonText = "Sukuna's domain", method =() => Particles.CreateDomain2(), isTogglable = true, toolTip = "Sukuna's domain."},
                new ButtonInfo { buttonText = "Fire Fists", method =() => Particles.CreateFireEffect(), isTogglable = true, toolTip = "gives you Fire Fists."},
                new ButtonInfo { buttonText = "Black Hole", method =() => Particles.CreateBlackHole(), isTogglable = true, toolTip = "makes a Black Hole."},
                new ButtonInfo { buttonText = "White Hole", method =() => Particles.CreateWhiteHole(), isTogglable = true, toolTip = "makes a White Hole."},
                new ButtonInfo { buttonText = "Lighting", method =() => Particles.CreateLightningEffect(), isTogglable = true, toolTip = "Lighting."},
                new ButtonInfo { buttonText = "Magic Spell", method =() => Particles.CastMagicSpell(), isTogglable = true, toolTip = "cast a Magic Spell."},
                new ButtonInfo { buttonText = "Spark Magic Spell", method =() => Particles.CastSparkMagic(), isTogglable = true, toolTip = "cast a Spark Magic Spell."},
                new ButtonInfo { buttonText = "Light Magic Spell", method =() => Particles.CastLightMagic(), isTogglable = true, toolTip = "cast a Light Magic Spell."},
                new ButtonInfo { buttonText = "FireBall Magic Spell", method =() => Particles.CastFireballMagic(), isTogglable = true, toolTip = "cast a FireBall."},
                new ButtonInfo { buttonText = "Sword Slash", method =() => Particles.SwordSlash(), isTogglable = true, toolTip = "make a Sword Slash."},
                new ButtonInfo { buttonText = "Lighting Bolt Magic", method =() => Particles.CastLightningBolt(), isTogglable = true, toolTip = "Lighting Bolt Magic."},
                new ButtonInfo { buttonText = "Rift Magic", method =() => Particles.CastVoidRift(), isTogglable = true, toolTip = "Rift Magic."},
                new ButtonInfo { buttonText = "Frost Orb Magic", method =() => Particles.CastFrostOrb(), isTogglable = true, toolTip = "Frost Orb Magic."},
                new ButtonInfo { buttonText = "Nebula Storm", method =() => Particles.CreateNebulaStorm(), isTogglable = true, toolTip = "Nebula Storm."},
                new ButtonInfo { buttonText = "Draw", method =() => Particles.Draw(), isTogglable = true, toolTip = "Draw."},
            },



            //always keep this at the bottom if you add another tab (by going to categories) make sure you put that section above this one:
            new ButtonInfo[] {
                new ButtonInfo { buttonText = "Disconnect", method =() => Mutegun.Disconnect(), isTogglable = false, toolTip = "Disconnected from lobby"},
            },
            new ButtonInfo[] {
                new ButtonInfo { buttonText = "home", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the home for the menu."},
            },

        };
    
    }
}
