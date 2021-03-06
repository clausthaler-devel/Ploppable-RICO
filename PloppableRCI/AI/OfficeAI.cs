﻿using System;
using ColossalFramework.Math;

namespace PloppableRICO
{

    public class PloppableOffice : OfficeBuildingAI, IWorkplaceLevelCalculator
   	{
		public int m_workplaceCount = 1;
		public int m_constructionCost = 1;
        public PloppableRICODefinition.Building m_ricoData;
        public int[] workplaceCount;

        // Here plays the music
 		public override int GetConstructionCost()
		{
            return WorkplaceAIHelper.GetConstructionCost(m_constructionCost, this.m_info.m_class.m_service, this.m_info.m_class.m_subService, this.m_info.m_class.m_level);
        }

        public override void CalculateWorkplaceCount(Randomizer r, int width, int length, out int level0, out int level1, out int level2, out int level3)
        {
            // See IndustrialAI.cs
            if (workplaceCount != null)
                WorkplaceAIHelper.SetWorkplaceLevels(out level0, out level1, out level2, out level3, workplaceCount);
            else
            {
                WorkplaceAIHelper.CalculateWorkplaceCount(m_ricoData, this, r, width, length, out level0, out level1, out level2, out level3);
                workplaceCount = new int[] { level0, level1, level2, level3 };
            }
        }

        public void CalculateBaseLevels(Randomizer r, int width, int length, out int level0, out int level1, out int level2, out int level3)
        {
            base.CalculateWorkplaceCount(r, width, length, out level0, out level1, out level2, out level3);;
        }

        public void CalculateLevels(Randomizer r, int width, int length, out int level0, out int level1, out int level2, out int level3)
        {
            ItemClass itemClass = this.m_info.m_class;
            ItemClass.SubService subService = itemClass.m_subService;
            int[] workplaceDistribution = { 0, 0, 0, 0, 0 };
            
            if (m_ricoData.workplaceDistribution != null)
                workplaceDistribution = m_ricoData.workplaceDistribution;
            else
                if (itemClass.m_level == ItemClass.Level.Level1)
                    workplaceDistribution = new int[] { 100, 0, 40, 50, 10 };
                else if (itemClass.m_level == ItemClass.Level.Level2)
                    workplaceDistribution = new int[] { 100, 0, 20, 50, 30 };
                else
                    workplaceDistribution = new int[] { 100, 0, 0, 40, 60 };

            WorkplaceAIHelper.distributeWorkplaceLevels(r, workplaceDistribution, m_workplaceCount, out level0, out level1, out level2, out level3);
		}

        // and from here on is silence
        public override void SimulationStep(ushort buildingID, ref Building buildingData, ref Building.Frame frameData)
        {
            Util.buildingFlags(ref buildingData);

            base.SimulationStep(buildingID, ref buildingData, ref frameData);

            Util.buildingFlags(ref buildingData);
        }

        protected override void SimulationStepActive(ushort buildingID, ref Building buildingData, ref Building.Frame frameData)
        {
            Util.buildingFlags(ref buildingData);

            base.SimulationStepActive(buildingID, ref buildingData, ref frameData);

            Util.buildingFlags(ref buildingData);
        }
        
        public override bool ClearOccupiedZoning()
        {
            return true;
        }

        public override void GetWidthRange(out int minWidth, out int maxWidth)
        {
            minWidth = 1;
            maxWidth = 16;
        }

        public override void GetLengthRange(out int minLength, out int maxLength)
        {
            minLength = 1;
            maxLength = 16;
        }
        
        public override string GenerateName(ushort buildingID, InstanceID caller)
        {
            return base.m_info.GetUncheckedLocalizedTitle();
        }

        public override BuildingInfo GetUpgradeInfo(ushort buildingID, ref Building data)
        {

            return null; //this will cause a check to fail in CheckBuildingLevel, and prevent the building form leveling. 
        }
	}
}