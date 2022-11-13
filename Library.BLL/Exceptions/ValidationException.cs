using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Exceptions
{
    /// <summary>
    /// Castom exception for validation
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Property
        /// </summary>
        public string Property { get; protected set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="prop"></param>
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
