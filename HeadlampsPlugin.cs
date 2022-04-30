using UnityEngine;
using BepInEx;
using BepInEx.Configuration;

namespace r1ft.Headlamps
{
    [BepInPlugin("com.r1ft.Headlamps", "r1ft.Headlamps", "1.0.0")]
    public class Headlamps : BaseUnityPlugin
    {
        public static GameObject Hook;

        private const string KeybindSectionName = "Keybinds";
        internal static ConfigEntry<KeyboardShortcut> HeadlightToggleKey;
        internal static ConfigEntry<KeyboardShortcut> HeadlightModeKey;

        private void Awake()
        {
            HeadlightToggleKey = Config.Bind(KeybindSectionName, "HeadlampToggleKey", new KeyboardShortcut(KeyCode.Y), "Key Bind for Headlamp Toggle");
            HeadlightModeKey = Config.Bind(KeybindSectionName, "HeadlampModeKey", new KeyboardShortcut(KeyCode.None), "Key Bind for Headlamp Mode");
            Logger.LogInfo("Loading: r1fT-Headlamps");
            Hook = new GameObject("Headlamps");
            Hook.AddComponent<HeadlampsController>();
            DontDestroyOnLoad(Hook);
        }
    }
}
