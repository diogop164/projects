using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRS_DB_Client
{
    internal class Utilities
    {

        internal static Dictionary<string, string> mainMenu = new Dictionary<string, string>
        {
            {"help" ,       "| Listar o menu."},
            {"exit" ,       "| Sair da app."},
            {"clear",       "| Limpar a consola."},
            {"login",       "| Efetuar login na aplicação.\n"+
                            "\t\t| Terá acesso ao menu do utilizador."},
        };

        internal static Dictionary<string, string> userMenu = new Dictionary<string, string>
        {
            {"help" ,       "| Listar o menu."},
            {"exit" ,       "| Sair da app."},
            {"clear",       "| Limpar a consola."},
            {"logout",      "| Efetuar logout na aplicação."},

        };

    }
}
