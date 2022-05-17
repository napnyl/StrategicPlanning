using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPlanning.BL
{
    public class Utils
    {
        public static class FodaEnum
        {
            public const int FMatrix = 0;
            public const int OMatrix = 1;
            public const int DMatrix = 2;
            public const int AMatrix = 3;
        }

        public static class MatrixCalif
        {
            public static readonly string[] general = { "1", "5", "9" };
        }

        public enum DiagramType
        {
            Private=0,
            Public=1
        };
    }
}
