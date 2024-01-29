using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    public class RequestRepository
    {

        internal static void RegistarPedido(string username)
        {
            using (var db = new RSGymDBContext())
            {

                var request = new Request();

                int ptID;
                string codigoPT;
                bool codigoValido;

                do
                {
                    Console.Write("\nCódigo do PT: ");
                    codigoPT = Console.ReadLine();

                    codigoValido = Validacoes.ValidarExistenciaPT(codigoPT, out ptID);
                } while (!codigoValido);

                request.PersonalTrainerID = ptID;

                bool dataEHoraValido;
                string dataAula;
                string horaAula;
                (DateTime, DateTime) dataEHora;

                do
                {
                    Console.Write("Data da sessão (dd/MM/yyyy): ");
                    dataAula = Console.ReadLine();

                    Console.Write("Hora da sessão (HH:mm): ");
                    horaAula = Console.ReadLine();

                    dataEHoraValido = Validacoes.ValidarDataEHora(dataAula, horaAula, out dataEHora);

                } while (dataEHoraValido == false);

                request.SessionDate = dataEHora.Item1;

                request.SessionHour = dataEHora.Item2;

                Console.Write("Mensagem: ");
                string mensagem = Console.ReadLine();

                int userID = db.User.FirstOrDefault(u => u.Username == username).UserID;

                request.UserID = (int)userID;

                request.RequestStatusID = 1;

                request.Message = mensagem;

                string nomePT = db.PersonalTrainer.FirstOrDefault(p => p.PersonalTrainerID == ptID).Name;

                string status = db.RequestStatus.FirstOrDefault(s => s.RequestStatusID == request.RequestStatusID).Status;

                db.Request.Add(request);

                db.SaveChanges();


                Console.WriteLine($"\nPedido realizado com sucesso!" +
                  $"\nCódigo do PT: {codigoPT}" +
                  $"\nNome do PT: {nomePT}" +
                  String.Format("\nData da sessão: {0:dd/mm/yyyy}", dataEHora.Item1) +
                  String.Format("\nHora da sessão: {0:HH:mm}", dataEHora.Item2) +
                  $"\nStatus do pedido: {status}" +
                  $"\nMensagem: {request.Message}");
                Console.ReadLine();

            }
        }

        internal static void ConsultarPedidos(string username)
        {
            using (var db = new RSGymDBContext())
            {
                int userID = db.User.FirstOrDefault(u => u.Username == username).UserID;

                var query = db.Request.Select(r => r).Where(r => r.UserID == userID).OrderByDescending(r => r.RequestStatusID).ThenByDescending(d => d.SessionDate);

                Console.WriteLine("\n------------------------\nOS SEUS PEDIDOS\n------------------------");

                foreach (var item in query)
                {

                        Console.WriteLine($"\nNúmero do pedido: {item.RequestID}" +
                                        $"\nID do PT: {item.PersonalTrainerID}" +
                                        String.Format("\nData da sessão: {0:dd/mm/yyyy}", item.SessionDate) +
                                        String.Format("\nHora da sessão: {0:HH:mm}", item.SessionHour) +
                                        $"\nID do status: {item.RequestStatusID}." +
                                        $"\nMensagem: {item.Message}." +
                                        $"\n------------------------------------------");                    
                }
                Console.ReadLine();
            }

        }

        internal static void AtualizarPedidos(string username)
        {

            using (var db = new RSGymDBContext())
            {
                Console.Write("\nNúmero do pedido que quer alterar: ");
                int idProcurado = int.Parse(Console.ReadLine());

                var result = db.Request.FirstOrDefault(r => r.RequestID == idProcurado);

                bool dataEHoraValido;
                string dataAula;
                string horaAula;
                (DateTime, DateTime) dataEHora;

                do
                {
                    Console.Write("Nova data da sessão (dd/MM/yyyy): ");
                    dataAula = Console.ReadLine();

                    Console.Write("Nova hora da sessão (HH:mm): ");
                    horaAula = Console.ReadLine();

                    dataEHoraValido = Validacoes.ValidarDataEHora(dataAula, horaAula, out dataEHora);

                } while (dataEHoraValido == false);

                var query = db.User.Join(db.Request, user => user.UserID, request => request.UserID, (user, request) => request)
                                   .Where(u => u.User.Username == username)
                                   .Select(r => r.RequestID);

                if (result != null && query.Contains(idProcurado))
                {

                    result.SessionDate = dataEHora.Item1;
                    result.SessionHour = dataEHora.Item2;
                    result.RequestStatusID = 1;

                    db.SaveChanges();

                    Console.WriteLine($"\nMaração da aula nº {result.RequestID} alterada com sucesso" +
                        $" com o PT {result.PersonalTrainer.Name}" +
                        $" para dia {dataEHora.Item1} às {dataEHora.Item2}");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Essa marcação não existe");
                    Console.ReadLine();
                }

            }

        }

        internal static void ConcluirPedido(string username)
        {
            using (var db = new RSGymDBContext())
            {

                Console.Write("\nNúmero do pedido que quer concluir: ");
                int idProcurado = int.Parse(Console.ReadLine());

                var result = db.Request.FirstOrDefault(r => r.RequestID == idProcurado);

                var query = db.User.Join(db.Request, user => user.UserID, request => request.UserID, (user, request) => request)
                                   .Where(u => u.User.Username == username)
                                   .Select(r => r.RequestID);

                if (result != null && query.Contains(idProcurado))
                {

                    result.StatusUpdatedDate = DateTime.Now;
                    result.RequestStatusID = 2;

                    db.SaveChanges();

                    Console.WriteLine($"\nAula nº {result.RequestID} concluída com sucesso" +
                        $" às {result.StatusUpdatedDate}");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Essa marcação não existe");
                    Console.ReadLine();
                }
            }
        }

        internal static void EliminarPedido(string username)
        {
            using (var db = new RSGymDBContext())
            {
                Console.Write("\nNúmero do pedido que quer eliminar: ");
                int idProcurado = int.Parse(Console.ReadLine());

                var result = db.Request.FirstOrDefault(r => r.RequestID == idProcurado);

                var query = db.User.Join(db.Request, user => user.UserID, request => request.UserID, (user, request) => request)
                                   .Where(u => u.User.Username == username)
                                   .Select(r => r.RequestID);

                if (result != null && query.Contains(idProcurado) && result.RequestStatusID == 1)
                {

                    db.Request.Remove(result);
                    db.SaveChanges();

                    Console.WriteLine($"\nPedido eliminado com sucesso!! ");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Essa marcação não existe ou já foi concluída/cancelada");
                    Console.ReadLine();
                }
            }

        }

    }
}
