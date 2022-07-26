using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymRS_DB_DAL
{
    public class User
    {

        #region Properties
        public int UserID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [MaxLength(50)]
        public string Password { get; set; }

        //Navigation properties
        public ICollection <Request> Request { get; set; }
        #endregion



    }
}
