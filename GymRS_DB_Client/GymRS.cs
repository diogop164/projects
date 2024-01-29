using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    class GymRS
    {
        #region Variáveis
        internal static string username;
        private static string password;
        private static string opcao;
        #endregion

        #region Métodos Gerais
        internal static void IniciarApp()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----BEM VINDO AO RS GYM-----");
            Console.WriteLine("-----------------------------\n");
            ApresentarLogin();
        }

        private static void ApresentarLogin()
        {
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
        }

        internal static void EfetuarLogin()
        {

            while (ValidarLogin() == false)
            {
                Console.Clear();
                Console.WriteLine("Login inválido.\n\n");
                ApresentarLogin();
            }

            Console.Clear();
            Console.WriteLine($"Login efetuado com sucesso\n\nBem-Vindo {username}!\n\n");
            Utilities.ListarMenuUser();
            Console.Write("\n\nInsira uma opção do menu (numérica): ");
            opcao = Console.ReadLine();
            ExecutarOpcaoMenuUser();

        }

        internal static void ExecutarOpcaoMenuUser()
        {

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Utilities.ListarMenuPersonalTrainer();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPT();
                    break;
                case "2":
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "3":
                    Console.Clear();
                    Utilities.ListarMenuEstatisticas();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
                case "4":
                    username = null;
                    Console.Clear();
                    ApresentarLogin();
                    EfetuarLogin();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Digite uma opção válida!");
                    Utilities.ListarMenuUser();
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuUser();
                    break;
            }
        }

        internal static void ExecutarOpcaoMenuPT()
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    PersonalTrainerRepository.CriarNovoPersonalTrainer();
                    Console.Clear();
                    Utilities.ListarMenuPersonalTrainer();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPT();
                    break;
                case "2":
                    Console.Clear();
                    PersonalTrainerRepository.ListarPT();
                    Console.Clear();
                    Utilities.ListarMenuPersonalTrainer();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPT();
                    break;
                case "3":
                    Console.Clear();
                    PersonalTrainerRepository.AtualizarPT();
                    Console.Clear();
                    Utilities.ListarMenuPersonalTrainer();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPT();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine($"USER LOGADO: {username}.\n\n");
                    Utilities.ListarMenuUser();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Digite uma opção válida!");
                    Utilities.ListarMenuPersonalTrainer();
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPT();
                    break;
            }
        }

        internal static void ExecutarOpcaoMenuPedido()
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    RequestRepository.RegistarPedido(username);
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "2":
                    Console.Clear();
                    RequestRepository.ConsultarPedidos(username);
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "3":
                    Console.Clear();
                    RequestRepository.AtualizarPedidos(username);
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "4":
                    Console.Clear();
                    RequestRepository.ConcluirPedido(username);
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "5":
                    Console.Clear();
                    RequestRepository.EliminarPedido(username);
                    Console.Clear();
                    Utilities.ListarMenuPedido();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine($"USER LOGADO: {username}.\n\n");
                    Utilities.ListarMenuUser();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Digite uma opção válida!");
                    Utilities.ListarMenuPedido();
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuPedido();
                    break;
            }
        }

        internal static void ExecutarOpcaoMenuEstatisticas()
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    StatisticsRepository.MostrarPedidosPorUtilizador(username);
                    Console.Clear();
                    Utilities.ListarMenuEstatisticas();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
                case "2":
                    Console.Clear();
                    StatisticsRepository.MostrarPedidosPorEstado();
                    Console.Clear();
                    Utilities.ListarMenuEstatisticas();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
                case "3":
                    Console.Clear();
                    StatisticsRepository.MostrarPedidosPorPT();
                    Console.Clear();
                    Utilities.ListarMenuEstatisticas();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
                case "4":
                    Console.Clear();
                    StatisticsRepository.MostrarPTTop();
                    Console.Clear();
                    Utilities.ListarMenuEstatisticas();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine($"USER LOGADO: {username}.\n\n");
                    Utilities.ListarMenuUser();
                    Console.Write("\n\nInsira uma opção do menu (numérica): ");
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Digite uma opção válida!");
                    Utilities.ListarMenuPedido();
                    opcao = Console.ReadLine();
                    ExecutarOpcaoMenuEstatisticas();
                    break;
            }
        }

        #endregion


        #region Métodos de validação
        private static bool ValidarLogin()
        {
            using (var db = new RSGymDBContext())
            {
                var myUser = db.User
                    .FirstOrDefault(u => u.Username == username
                                    && u.Password == password);
                if (myUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
