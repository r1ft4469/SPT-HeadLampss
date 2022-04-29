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
                ToggleLight();

            if (Headlamps.HeadlightModeKey.Value.IsUp())
                ToggleMode();

        }

        private static void ToggleLight()
        {
            _toggle = !_toggle;

            foreach (var mount in HeadLamps.Mounts)
            {
                var mod_mount = GameObject.Find(HeadLamps.Head + mount);
                if (mod_mount == null)
                    continue;

                foreach (var light in HeadLamps.Lights)
                {
                    var lightSource = GameObject.Find(HeadLamps.Head + mount + light);
                    if (lightSource == null)
                        continue;

                    lightSource.SetActive(_toggle);
                }

                if (!_toggle)
                {
                    foreach (var altlight in HeadLamps.AltMode)
                    {
                        var altlightSource = GameObject.Find(HeadLamps.Head + mount + altlight);
                        if (altlightSource == null)
                            continue;

                        altlightSource.SetActive(false);
                    }
                }
            }
            return;
        }

        private static void ToggleMode()
        {
            if (_toggle)
            {
                foreach (var mount in HeadLamps.Mounts)
                {
                    var mod_mount = GameObject.Find(HeadLamps.Head + mount);
                    if (mod_mount == null)
                        continue;

                    foreach (var light in HeadLamps.Lights)
                    {
                        var lightSource = GameObject.Find(HeadLamps.Head + mount + light);
                        if (lightSource == null)
                            continue;

                        foreach (var altlight in HeadLamps.AltMode)
                        {
                            var altlightSource = GameObject.Find(HeadLamps.Head + mount + altlight);
                            if (altlightSource == null)
                                continue;

                            _mode += 1;
                            switch (_mode)
                            {
                                case 1:
                                    altlightSource.SetActive(true);
                                    lightSource.SetActive(true);
                                    break;
                                case 2:
                                    altlightSource.SetActive(true);
                                    lightSource.SetActive(false);
                                    break;
                                default:
                                    altlightSource.SetActive(false);
                                    lightSource.SetActive(true);
                                    _mode = 0;
                                    break;
                            }
                        }
                    }
                }
            }
            return;
        }
    }
}
