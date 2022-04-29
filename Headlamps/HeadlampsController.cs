using Comfort.Common;
using EFT;
using EFT.UI;
using UnityEngine;

namespace r1ft.Headlamps
{
    public class HeadlampsController : MonoBehaviour
    {
        private static GameWorld gameWorld;
        private static bool _toggle = false;
        private static int _mode = 0;

        public void Update()
        {
            if (PreloaderUI.Instance == null)
                return;

            gameWorld = Singleton<GameWorld>.Instance;
            if (gameWorld == null)
                return;

            if (gameWorld.AllPlayers == null)
                return;

            if (gameWorld.AllPlayers.Count == 0)
                return;

            if (gameWorld.AllPlayers[0] is HideoutPlayer)
                return;

            var localPlayer = gameWorld.AllPlayers[0];
            if (localPlayer == null)
                return;


            if (Headlamps.HeadlightToggleKey.Value.IsUp())
            {
                _toggle = !_toggle;

                foreach (var light in HeadLamps.Objects)
                {
                    var flashlight = GameObject.Find(light);
                    if (flashlight == null)
                        continue;

                    flashlight.SetActive(_toggle);
                }
            }

            if (Headlamps.HeadlightModeKey.Value.IsUp())
            {
                foreach (var light in HeadLamps.Objects)
                {
                    var flashlight = GameObject.Find(light);
                    if (flashlight == null)
                        continue;

                    if (flashlight.activeSelf)
                    {
                        HeadLamps.AltMode.TryGetValue(light, out var altlight);
                        var altflashlight = GameObject.Find(altlight);
                        if (altflashlight == null)
                            break;

                        _mode += 1;
                        switch(_mode)
                        {
                            case 1:
                                altflashlight.SetActive(true);
                                flashlight.SetActive(true);
                                break;
                            case 2:
                                altflashlight.SetActive(true);
                                flashlight.SetActive(false);
                                break;
                            default:
                                altflashlight.SetActive(false);
                                flashlight.SetActive(true);
                                _mode = 0;
                                break;
                        }
                    }
                }
            }
        }
    }
}
