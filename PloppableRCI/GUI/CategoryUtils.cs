﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PloppableRICO
{
 
    public enum Category
    {
        None = -1,
        Monument,
        Beautification,
        Education,
        Power,
        Water,
        Health
    }

    public class CategoryIcons
    {

        public static readonly string[] atlases = {"Ingame", "Ingame" , "Ingame", "Ingame", "Ingame", "Ingame" };

        public static readonly string[] spriteNames = {

            "ToolbarIconMonuments",
            "ToolbarIconBeautification",
            "ToolbarIconEducation",
            "ToolbarIconElectricity",
            "ToolbarIconWater",
            "ToolbarIconHealthcare"
        };

        public static readonly string[] tooltips = {"Monuments","Beautification", "Education", "Power", "Water", "Health" };
    }
}