﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HMS
{
    public class Responsive
    {
        float WIDTH_AT_DESIGN_TIME = (float)Convert.ToDouble(ConfigurationManager.AppSettings["DESIGN_TIME_SCREEN_WIDTH"]);
        float HEIGHT_AT_DESIGN_TIME = (float)Convert.ToDouble(ConfigurationManager.AppSettings["DESIGN_TIME_SCREEN_HEIGHT"]);
        Rectangle Resolution;
        float WidthMultiplicationFactor;
        float HeightMultiplicationFactor;

        public Responsive(Rectangle ResolutionParam)
        {
            Resolution = ResolutionParam;
        }

        public void SetMultiplicationFactor()
        {
            WidthMultiplicationFactor = Resolution.Width / WIDTH_AT_DESIGN_TIME;
            HeightMultiplicationFactor = Resolution.Height / HEIGHT_AT_DESIGN_TIME;
        }

        public int GetMetrics(int ComponentValue)
        {
            return (int)(Math.Floor(ComponentValue * WidthMultiplicationFactor));
        }

        public int GetMetrics(int ComponentValue, string Direction)
        {
            if (Direction.Equals("Width") || Direction.Equals("Left"))
                return (int)(Math.Floor(ComponentValue * WidthMultiplicationFactor));
            else if (Direction.Equals("Height") || Direction.Equals("Top"))
                return (int)(Math.Floor(ComponentValue * HeightMultiplicationFactor));
            return 1;
        }
    }
}
