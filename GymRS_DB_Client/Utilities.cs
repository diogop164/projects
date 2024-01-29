using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRS_DB_Client
{
    internal class Utilities
    {

        #region Métodos criar menus
        internal static Dictionary<string, string> menuUser = new Dictionary<string, string>
        {
            {"1.Personal Trainer" ,"  | Aceder ao menu dos Personal Trainers."},
            {"2.Pedido" ,"            | Aceder ao menu dos pedidos."},
            {"3.Estatísticas","      | Aceder ao menu de estatísticas."},
            {"4.Logout","            | Efetuar logout na aplicação."},
            {"5.Sair","              | Sair da aplicação."}

        };

        internal static Dictionary<string, string> menuPersonalTrainer = new Dictionary<string, string>
        {
            {"1.Registar" ,"       | Criar novos Personal Trainers."},
            {"2.Consultar" ,"      | Listar os PTs existentes."},
            {"3.Atualizar","      | Corrigir o nome do PT."},
            {"4.Voltar","         | Voltar ao menu anterior."}
        };

        internal static Dictionary<string, string> menuPedido = new Dictionary<string, string>
        {
            {"1.Registar" ,"       | Fazer Pedido do PT."},
            {"2.Consultar" ,"      | Consultar os pedidos efetuados."},
            {"3.Atualizar","      | Alterar a marcação da aula."},
            {"4.Concluir" ,"       | Concluir a aula."},
            {"5.Eliminar","       | Eliminar um pedido que não se tenha realizado."},
            {"6.Voltar","         | Voltar ao menu anterior."}
        };

        internal static Dictionary<string, string> menuEstatisticas = new Dictionary<string, string>
        {
            {"1.Pedidos" ,"                 | Quantos pedidos efetuou."},
            {"2.Pedidos por Estado" ,"      | Quantos pedidos estão registados por estado."},
            {"3.Pedidos por PT","          | Quantos pedidos foram feitos por PT."},
            {"4.PT Top","                  | Qual o PT mais solicitado."},
            {"5.Voltar","                  | Voltar ao menu anterior."}
        };
        #endregion

        #region Métodos listar menus
        internal static void ListarMenuUser()
        {
            foreach (KeyValuePair<string, string> item in menuUser)
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }
        }

        internal static void ListarMenuPersonalTrainer()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-----MENU PERSONAL TRAINER-----");
            Console.WriteLine("-------------------------------\n");
            foreach (KeyValuePair<string, string> item in menuPersonalTrainer)
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }
        }

        internal static void ListarMenuPedido()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("----------MENU PEDIDO----------");
            Console.WriteLine("-------------------------------\n");
            foreach (KeyValuePair<string, string> item in menuPedido)
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }
        }

        internal static void ListarMenuEstatisticas()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("-------MENU ESTATÍSTICAS-------");
            Console.WriteLine("-------------------------------\n");
            foreach (KeyValuePair<string, string> item in menuEstatisticas)
            {
                Console.WriteLine($"{item.Key}{item.Value}");
            }
        }

        #endregion




    }
}
