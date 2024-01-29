using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymRS_DB_DAL
{
    public class PersonalTrainer
    {

        #region Properties
        public int PersonalTrainerID { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Código tem que ter 5 caracteres", MinimumLength = 5)]
        [MaxLength(5)]
        public string PTCode { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [MaxLength(50)]
        //[RegularExpression(@"[A-ZÀ-ÿ-,a-z. ']+[ ]+", ErrorMessage = "Insira um nome válido.")]
        public string Name { get; set; }

        //Navigation properties
        public ICollection<Request> Request { get; set; }
        #endregion

    }
}
