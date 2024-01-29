using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    class StatisticsRepository
    {

        internal static void MostrarPedidosPorUtilizador(string username)
        {
            using (var db = new RSGymDBContext())
            {
                int userID = db.User.FirstOrDefault(u => u.Username == username).UserID;

                var query = db.Request.Where(p => p.UserID == userID).Count();

                Console.WriteLine($"Pedidos feitos pelo utilizador {username}: {query}");

                Console.ReadLine();
            }

        }

        internal static void MostrarPedidosPorEstado()
        {
            using (var db = new RSGymDBContext())
            {
                var contagemAgendados = db.Request
                            .Where(s => s.RequestStatusID == 1)
                            .Count();

                var contagemConcluidos = db.Request
                            .Where(s => s.RequestStatusID == 2)
                            .Count();

                var contagemCancelados = db.Request
                            .Where(s => s.RequestStatusID == 3)
                            .Count();



                Console.WriteLine($"\nPedidos Agendados: {contagemAgendados}");
                Console.WriteLine($"\nPedidos Concluídos: {contagemConcluidos}");
                Console.WriteLine($"\nPedidos Cancelados: {contagemCancelados}");

                Console.ReadLine();
            }
        }

        internal static void MostrarPedidosPorPT()
        {
            using (var db = new RSGymDBContext())
            {

                var quantidadePTs = db.PersonalTrainer.Select(p => p.PersonalTrainerID).Count();

                for (int i = 1; i <= quantidadePTs; i++)
                {
                    var requestsPorPT = db.Request.Where(r => r.PersonalTrainerID == i).Count();
                    var personalTrainer = db.PersonalTrainer.FirstOrDefault(p => p.PersonalTrainerID == i);

                    Console.WriteLine($"Nome do Personal Trainer: {personalTrainer.Name}" +
                        $"\nQuantidade de Pedidos: {requestsPorPT} " +
                        $"\n----------------------------------------------------------------");
                }

                Console.ReadLine();
            }
        }

        internal static void MostrarPTTop()
        {
            using (var db = new RSGymDBContext())
            {
                
                var ptTop = db.Request.GroupBy(i => i.PersonalTrainerID).Select(group => new
                {
                    PersonalTrainer = group.Key,
                    Count = group.Count()
                }).OrderByDescending(i => i.Count).FirstOrDefault();
                
           
                string nomePTTop = db.PersonalTrainer.Where(p => p.PersonalTrainerID == ptTop.PersonalTrainer).Select(p => p.Name).FirstOrDefault();
                
                Console.WriteLine("----------------------------------\n" +
                                  "--------------PT TOP--------------\n" +
                                  "----------------------------------\n" +
                                  $"\nO Personal Trainer mais solicitado é o {nomePTTop}");
            }

            Console.ReadLine();
        }
    }
}
