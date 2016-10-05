using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    public partial class COUR
    {
        public override string ToString()
        {
            return this.CODECOURS + " - " + this.LIBELLECOURS + " - " + this.NBJOURS;
        }
    }
}
