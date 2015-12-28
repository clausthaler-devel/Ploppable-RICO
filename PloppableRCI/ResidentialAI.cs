using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.Math;
using ColossalFramework.Plugins;
using System;
using UnityEngine;
using ICities;

namespace PloppableAI
{

	public class PloppableResidential : ResidentialBuildingAI

	{
		[CustomizableProperty("Level Min", "Gameplay common")]
		public int m_levelmin = 1;
		[CustomizableProperty("Level Max", "Gameplay common")]
		public int m_levelmax = 1;
		[CustomizableProperty("Household Multi", "Gameplay common")]
		public int m_housemulti = 0;

	
		public int BID = 2;
		int Tester = 1;
		private int timer = 1;

		string OriginalN;


		public override void GetWidthRange (out int minWidth, out int maxWidth)
		{
			base.GetWidthRange (out minWidth, out maxWidth);
			minWidth = 1;
			maxWidth = 32;
		}
		public override void GetDecorationArea (out int width, out int length, out float offset)
		{
			base.GetDecorationArea (out width, out length, out offset);
			width = this.m_info.m_cellWidth;
			length = this.m_info.m_cellLength;
			offset = 0f;
		}

		public override void GetLengthRange (out int minLength, out int maxLength)
		{
			base.GetLengthRange (out minLength, out maxLength);
			minLength = 1;
			maxLength = 16;
		}


		public override int CalculateHomeCount (Randomizer r, int width, int length)
		{
			//width = width * 2
			//length = length * 2 ;
			return base.CalculateHomeCount (r, width + this.m_housemulti, length + this.m_housemulti);
		}


		public override void SimulationStep (ushort buildingID, ref Building data)

		{
			this.m_info.m_autoRemove = false;
			data.UpdateBuilding ((ushort)data.m_buildIndex);

	
			data.m_flags &= ~Building.Flags.ZonesUpdated;
			data.m_problems = Notification.Problem.None;
			data.m_flags &= ~Building.Flags.Abandoned;


			data.m_levelUpProgress = 240;
	

			base.SimulationStep(buildingID, ref data);


		}
			
		public override bool ClearOccupiedZoning ()
		{
			return false;
		}



	}
}