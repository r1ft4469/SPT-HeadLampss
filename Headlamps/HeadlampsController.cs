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
        private static int _mode = 1;

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
            foreach (var mount in HeadLamps.Helmets)
            {
                var mod_mount = GameObject.Find(HeadLamps.Head + mount);
                if (mod_mount == null)
                    continue;

                foreach (var light in HeadLamps.Lights)
                {
                    var lightSource = GameObject.Find(HeadLamps.Head + mount + light + HeadLamps.Mode + _mode.ToString());
                    if (lightSource == null)
                        continue;

                    switch (_mode)
                    {
                        case 2:
                            lightSource.SetActive(_toggle);
                            break;
                        case 3:
                            var altlightSource = GameObject.Find(HeadLamps.Head + mount + light + HeadLamps.Mode + "1");
                            if (altlightSource == null)
                                break;

                            lightSource.SetActive(_toggle);
                            altlightSource.SetActive(_toggle);
                            break;
                        default:
                            lightSource.SetActive(_toggle);
                            break;
                    }
                }
            }
            return;
        }

        private static void ToggleMode()
        {
            if (_toggle)
            {
                foreach (var mount in HeadLamps.Helmets)
                {
                    var mod_mount = GameObject.Find(HeadLamps.Head + mount);
                    if (mod_mount == null)
                        continue;

                    foreach (var light in HeadLamps.Lights)
                    {
                        var lastlightSource = GameObject.Find(HeadLamps.Head + mount + light + HeadLamps.Mode + _mode.ToString());
                        if (lastlightSource == null)
                            return;

                        _mode++;
                        if (_mode > 3)
                            _mode = 1;

                        var lightSource = GameObject.Find(HeadLamps.Head + mount + light + HeadLamps.Mode + _mode.ToString());
                        if (lightSource == null)
                            return;

                        if (_mode == 3)
                        {
                            var combilightSource = GameObject.Find(HeadLamps.Head + mount + light + HeadLamps.Mode + "1");
                            if (lightSource == null)
                                return;

                            combilightSource.SetActive(true);
                            lastlightSource.SetActive(false);
                            lightSource.SetActive(true);
                        }
                        else
                        {
                            lastlightSource.SetActive(false);
                            lightSource.SetActive(true);
                        }
                    }
                }
            }
            return;
        }
    }
}
