using ColossalFramework.UI;
using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PloppableAI
{
	public class ExtendedLoading : LoadingExtensionBase
	{

		static GameObject buildingWindowGameObject;
		ServiceInfoWindow serviceWindow;
		
		private LoadMode _mode;
	
		public override void OnLevelLoaded(LoadMode mode)
		{
			if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame)
				return;
			_mode = mode;

			buildingWindowGameObject = new GameObject("buildingWindowObject");

			var serviceBuildingInfo = UIView.Find<UIPanel>("(Library) CityServiceWorldInfoPanel");
			serviceWindow = buildingWindowGameObject.AddComponent<ServiceInfoWindow>(); 
			serviceWindow.servicePanel = serviceBuildingInfo.gameObject.transform.GetComponentInChildren<CityServiceWorldInfoPanel>();
	
		serviceBuildingInfo.eventVisibilityChanged += serviceBuildingInfo_eventVisibilityChanged;
	}

	private void serviceBuildingInfo_eventVisibilityChanged(UIComponent component, bool value)
	{
		serviceWindow.Update();
	}
			
		public override void OnLevelUnloading()
		{
			if (_mode != LoadMode.LoadGame && _mode != LoadMode.NewGame)
				return;



			if (buildingWindowGameObject != null)
			{
				GameObject.Destroy(buildingWindowGameObject);
			}
		}
	}
}