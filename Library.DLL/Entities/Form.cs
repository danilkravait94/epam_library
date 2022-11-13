using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Entities
{
    /// <summary>
    /// form request
    /// </summary>
    public class Form
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int FormID { get; set; }
        /// <summary>
        /// A name of person
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A surname of person
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Country that person is from
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// list of some values
        /// </summary>
        public List<string> smths { get; set; }

    }
}
