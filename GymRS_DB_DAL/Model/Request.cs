using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymRS_DB_DAL
{
    public class Request
    {
        public int RequestID { get; set; }

        public int UserID { get; set; }

        public int PersonalTrainerID { get; set; }

        public int RequestStatusID { get; set; }

        [Required]
        public DateTime? SessionDate { get; set; }

        [Required]
        public DateTime? SessionHour { get; set; }

        public DateTime? StatusUpdatedDate { get; set; }

        public string Message { get; set; }

        // Navigation Properties
        public User User { get; set; }
        
        public PersonalTrainer PersonalTrainer { get; set; }

        public RequestStatus RequestStatus { get; set; }
    }
}
