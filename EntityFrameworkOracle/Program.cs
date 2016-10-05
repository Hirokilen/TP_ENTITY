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

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("-------------------TOUS LES EMPLOYES---------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                var requeteEmployes = from EMPLOYE in oracleContexte.EMPLOYEs
                                      select EMPLOYE;
                var lesEmployes = requeteEmployes.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.ToString());
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------TOUS LES COURS----------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                var requeteCours = from COURS in oracleContexte.COURS
                                      select COURS;
                var lesCours = requeteCours.ToList();

                foreach (var unCours in lesCours)
                {
                    Console.WriteLine(unCours.ToString());
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("------------EMPLOYE PARTICIPANT AU PROJET PR1------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                var unCodeProjet = "PR1";
                var requeteEmployesProjet = from EMPLOYE in oracleContexte.EMPLOYEs
                                            where EMPLOYE.CODEPROJET.TrimEnd() == unCodeProjet
                                            select EMPLOYE;
                lesEmployes = requeteEmployesProjet.ToList();

                foreach (var unEmploye in lesEmployes)
                {
                    Console.WriteLine(unEmploye.NUMEMP + " - " + unEmploye.NOMEMP);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("----------EMPLOYE CORRESPONDANT AU NUM EMP 28------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("----------EMPLOYE CORRESPONDANT AU NUM EMP 5------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                idEmploye = 5;
                var employeId2 = requeteEmployesById.FirstOrDefault();

                if (employeId2 != null)
                {
                    Console.WriteLine(employeId2.NOMEMP + " - " + employeId2.PRENOMEMP + " - " + employeId2.SALAIRE);
                }
                else
                {
                    Console.WriteLine("L'employé numéro " + idEmploye + " n'existe pas.");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("------ Cours et séminaires ------");
                Console.WriteLine("---------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                var requete = from s in oracleContexte.SEMINAIREs
                              join COUR in oracleContexte.COURS on s.CODECOURS equals COUR.CODECOURS
                              group s by new { s.CODECOURS, s.COUR.LIBELLECOURS } into groupeEmployes
                              select new
                              {
                                  LibelleCours = groupeEmployes.Key.LIBELLECOURS,
                                  Cours = groupeEmployes.Key.CODECOURS,
                                  Nombre = groupeEmployes.Count()
                              };
                
                var lesSeminaires = requete.ToList();
                

                foreach (var unSeminaire in lesSeminaires)
                {
                    Console.WriteLine(unSeminaire.LibelleCours+ " - " + unSeminaire.Cours + " - " + unSeminaire.Nombre);
                    var requeteDate = from s in oracleContexte.SEMINAIREs
                                      where s.CODECOURS == unSeminaire.Cours
                                      select s;
                    var lesDates = requeteDate.ToList();
                    foreach (var uneDate in lesDates)
                    {
                        Console.WriteLine("                 "+uneDate.DATEDEBUTSEM);
                    }
                }

                // Mise à jour des données
                /*
                var emp = oracleContexte.EMPLOYEs.Find(200);
                
                

                if (emp != null)
                {
                    emp.SALAIRE = emp.SALAIRE * (decimal)1.1;
                    Console.WriteLine("Le nouveau salaire = " + emp.SALAIRE);
                    oracleContexte.SaveChanges();
                }
                else
                {
                    Console.WriteLine("L'employé n'existe pas.");
                }
                */
                // CREATION D'UN COUR
                /*
                COUR unCours = new COUR();
                unCours.CODECOURS = "BR099";
                unCours.LIBELLECOURS = "Entity Framework 6 avec Oracle";
                unCours.NBJOURS = 4;
                oracleContexte.COURS.Add(unCours);
                oracleContexte.SaveChanges();
                Console.WriteLine("Le cours a été créé");
                */
            }
            Console.ReadLine();
        }
    }
}
