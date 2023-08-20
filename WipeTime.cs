using System;
using Oxide.Core;
using Oxide.Core.Plugins;

namespace Oxide.Plugins
{
    [Info("Wipe Time", "NoxTGM", "1.0.0")]
    [Description("Affiche la date du prochain wipe au dessus des autres status en bas à droite.")]
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
                "PROCHAIN WIPE",
                "1 1 1 0.8",
                "22/08/2023",
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
