using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    public class RequestStatusRepository
    {

        public static void CriarStatus()
        {
            var estado01 = new RequestStatus
            {
                Status = "Agendado"
            };

            var estado02 = new RequestStatus
            {
                Status = "Concluído"
            };

            var estado03 = new RequestStatus
            {
                Status = "Cancelado"
            };

            using (var context = new RSGymDBContext())
            {
                context.RequestStatus.Add(estado01);
                context.RequestStatus.Add(estado02);
                context.RequestStatus.Add(estado03);
                context.SaveChanges();
            }
        }

    }
}
