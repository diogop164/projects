using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    internal static class Validacoes
    {

        internal static bool ValidarExistenciaPT(string codigoPT, out int IDPt)
        {
            using (var db = new RSGymDBContext())
            {
                var query = db.PersonalTrainer.FirstOrDefault(p => p.PTCode == codigoPT);

                if (query != null)
                {
                    IDPt = query.PersonalTrainerID;
                    return true;
                }
                else
                {
                    IDPt = 0;
                    Console.WriteLine("Personal Trainer inexistente.");
                    return false;
                }
            }
        }

        internal static bool ValidarDataEHora(string dataInserida, string horaInserida, out (DateTime, DateTime) dataEHora)
        {
            DateTime data;
            DateTime hora;

            bool validacao;

            if (DateTime.TryParseExact(dataInserida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data) && data >= DateTime.Today)
            {
                validacao = true;
            }
            else
            {
                Console.WriteLine("Formato da data inválido.");
                validacao = false;
            }

            if (DateTime.TryParseExact(horaInserida, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora) && validacao == true)
            {
                validacao = true;
            }
            else
            {
                Console.WriteLine("Formato da hora inválido.");
                validacao = false;
            }

            dataEHora = (data, hora);

            return validacao;
        }
      
    }
}
