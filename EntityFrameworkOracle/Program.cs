using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkOracle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (OracleEntities oracleContexte = new OracleEntities())
            {
                var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYEs
                                      select EMPLOYE;
                var lesEmployes = requeteEmployes.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

                Console.WriteLine("---------------------------------------------------------");
                var unCodeProjet = "PR1";
                var requeteEmployesProjet = from EMPLOYE in oracleContexte.EMPLOYEs
                                            where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                            select EMPLOYE;
                lesEmployes = requeteEmployesProjet.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }

            }
            Console.ReadLine();
        }
    }
}
