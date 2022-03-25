using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using FumoTagsBepinex.Modules;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using FumoCoroutine = FumoTagsBepinex.Modules.Coroutine;

namespace FumoTagsBepinex
{
    [BepInPlugin("com.FumoTags.Mezque", "Fumo Tags", "1.0.0.0"), BepInProcess("VRChat.exe")]
    public class Plugin : BasePlugin
    {
        internal static ManualLogSource FLog;
        public static string PLUGIN_GUID = "com.FumoTags.Mezque";
        public static string PLUGIN_NAME = "Fumo Tags";
        public static string PLUGIN_VERSION = "1.0.0.0";
        public static ConfigEntry<bool> NameplateTag;
        public static ConfigEntry<bool> DebugToggles;
        public static BepInEx.Configuration.ConfigFile Prefs;

        public override void Load()
        {
            FLog = Log;
            FLog.LogMessage($"Plugin {PLUGIN_NAME} V{PLUGIN_VERSION} loaded!");
            FLog.LogMessage($"If you would like a tag, please request one on our Discord. https://discord.gg/g7AyvCme3t ");
            FLog.LogMessage($"Otherwise, I hope you enjoy :)");

            NameplateTag = Config.Bind("General.Toggles", "Display Nameplate Tag", false, "Whether or not to show the tags on their own image 3slice or on the trust rank text.");

            DebugToggles = Config.Bind("General.Toggles", "Display Debug Logs", false, "Whether or not to show debug info in console.");

            FLog.LogInfo("Prefs Loaded");

            IL2CPPChainloader.AddUnityComponent<FumoLoader>();

            FumoLoader.loader();

            FLog.LogInfo("Plugin Loaded");
        }
    }

    public class FumoLoader : MonoBehaviour
    {
        public static ManualLogSource FLog;

        public FumoLoader() : base(ClassInjector.DerivedConstructorPointer<FumoLoader>()) => ClassInjector.DerivedConstructorBody(this);

        public FumoLoader(IntPtr ptr) : base(ptr)
        {
        }

        public static void loader()
        {
            FumoCoroutine.Start(CustomTags.TagListNetworkManager());
        }
    }
}