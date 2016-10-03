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
                Console.WriteLine("---------------------------------------------------------");

                var idEmploye = 28;
                var requeteEmployesById = from EMPLOYE in oracleContexte.EMPLOYEs
                                          where EMPLOYE.NUMEMP == idEmploye
                                          select EMPLOYE;
                var employeId = requeteEmployesById.FirstOrDefault();

                if(employeId != null)
                {
                    Console.WriteLine(employeId.NOMEMP + " - " + employeId.PRENOMEMP + " - " + employeId.SALAIRE);
                }
                else
                {
                    Console.WriteLine("L'employé numéro " + idEmploye + " n'existe pas.");
                }
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("------ Cours et séminaires ------");
                Console.WriteLine("---------------------------------------------------------");
                var requete = from s in oracleContexte.SEMINAIREs
                              join COUR in oracleContexte.COURS on s.CODECOURS equals COUR.CODECOURS
                              select s;
                var requeteNb = requete.Count();

                var lesSeminaires = requete.ToList();

                foreach (var unSeminaire in lesSeminaires)
                {
                    Console.WriteLine(unSeminaire.CODESEMI + " - " + unSeminaire.CODECOURS + " - " + unSeminaire.COUR.LIBELLECOURS + " - ");
                }



            }
            Console.ReadLine();
        }
    }
}
