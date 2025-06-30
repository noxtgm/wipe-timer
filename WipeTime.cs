using System;
using Oxide.Core;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("Wipe Time", "NoxTGM", "1.0.0")]
    [Description("Displays next wipe date as a status in the bottom right above food, hydration, etc.")]
    internal class WipeTime : CovalencePlugin
    {
        #region Variables

        [PluginReference]
        private Plugin StatusFramework;

        [PluginReference]
        private Plugin ImageLibrary;

        #endregion

        #region Hooks

        private void OnServerInitialized() {
            ImageLibrary.Call<bool>("AddImage", "https://i.imgur.com/MLRiCM0.png", "wave", 0UL);

            Func<BasePlayer, bool> condition = (player) => { return true; };

            StatusFramework?.Call("CreateStatus",
                "wipe.timer",
                "0.972 0.922 0.890 0.04",
                "NEXT WIPE", // Text that will be displayed before the date
                "1 1 1 0.8",
                "01/01/2024", // Edit with the following wipe's date
                "1 1 1 1",
                "wave",
                "1 1 1 0.5",
                condition
            );
        }

        private void Unload() {
            StatusFramework?.Call("DeleteStatus", "wipe.timer");
        }

        #endregion
    }
}
