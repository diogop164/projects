using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymRS_DB_DAL
{
    public class Request
    {
        public int RequestID { get; set; }

        public int UserID { get; set; }

        public int PersonalTrainerID { get; set; }

        public DateTime ClassDate { get; set; }

        public DateTime ClassHour { get; set; }

        // Navigation Properties
        public User User { get; set; }
        
        public PersonalTrainer PersonalTrainer { get; set; }

    }
}
