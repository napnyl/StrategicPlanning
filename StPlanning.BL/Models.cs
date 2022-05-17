using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPlanning.BL
{
    public partial class tblDiagramVirtual
    {
        public long Id { get; set; }
        public long IdProject { get; set; }
        public string Key { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<double> FromX { get; set; }
        public Nullable<double> FromY { get; set; }
        public Nullable<double> ToX { get; set; }
        public Nullable<double> ToY { get; set; }
        public Nullable<int> Color { get; set; }
    }
}
