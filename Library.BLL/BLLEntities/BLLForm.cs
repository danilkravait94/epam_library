using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.BLLEntities
{
    /// <summary>
    /// BLL form request
    /// </summary>
    public class BLLForm : BLLEntity
    {
        /// <summary>
        /// A name of person
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели имя")]
        [StringLength(15, ErrorMessage = "Имя не может привышать 15 символов")]
        public string Name { get; set; }
        /// <summary>
        /// A surname of person
        /// </summary>
        [Required(ErrorMessage = "Вы не ввели фамилию")]
        [StringLength(20, ErrorMessage = "Фамилия не может привышать 20 символов")]
        public string Surname { get; set; }
        /// <summary>
        /// Country that person is from
        /// </summary>
        [Required(ErrorMessage = "Вы не выбрали страну")]
        public string Country { get; set; }
        /// <summary>
        /// list of some values
        /// </summary>
        [Required(ErrorMessage = "Вы не выбрали значение")]
        public List<string> smths { get; set; }

    }
}
