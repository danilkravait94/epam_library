using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Entities
{
    /// <summary>
    /// Assay on a home page
    /// </summary>
    public class Assay
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int AssayID { get; set; }
        /// <summary>
        /// Author of an assay
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// title of an assay
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// list of assay tags
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// The main part
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// no parameter constructor
        /// </summary>
        public Assay()
        {

        }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="author">autor of the assay</param>
        /// <param name="title">assay`s title</param>
        /// <param name="text">a main part</param>
        public Assay(string author, string title, string text)
        {
            Author = author;
            Title = title;
            Text = text;
        }

    }
}
