using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymRS_DB_DAL
{
    public class RequestStatus
    {

        public int RequestStatusID { get; set; }

        [Required]
        public string Status { get; set; }

        //Navigation properties
        public ICollection<Request> Request { get; set; }
    }
}
