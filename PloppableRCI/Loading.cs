using System.Linq;
using ICities;
using ColossalFramework.Plugins;
using UnityEngine;

namespace PloppableRICO
{
    public class Loading : LoadingExtensionBase
	{
        private XMLManager xmlManager;
        private ConvertPrefabs convertPrefabs;

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame)
            return;
           
            //Load xml
            xmlManager = new XMLManager();
            xmlManager.Run();

            //Assign xml settings to prefabs.
            convertPrefabs = new ConvertPrefabs();
            convertPrefabs.run();

            //Init GUI
            PloppableTool.Initialize();
            RICOSettingsPanel.Initialize();

            //Deploy Detour
            Detour.BuildingToolDetour.Deploy();

        }

        public override void OnLevelUnloading ()
		{
			base.OnLevelUnloading ();

            //RICO ploppables need a non private item class assigned to pass though the game reload. 
            Util.AssignServiceClass();
		}

		public override void OnReleased ()
		{
			base.OnReleased ();

            Detour.BuildingToolDetour.Revert ();

		}
	}
}
