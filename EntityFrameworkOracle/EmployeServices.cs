using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    public partial class EMPLOYE
    {
        public override string ToString()
        {
            return NUMEMP + " | " + NOMEMP + " | " + PRENOMEMP + " | " + POSTE + " | " + SALAIRE + " | " + ((PRIME == null) ? 0 : PRIME) + " | " + ((CODEPROJET == null) ? "///" : CODEPROJET) + " | " + ((SUPERIEUR == null) ? 0 : SUPERIEUR);
        }
    }
}
