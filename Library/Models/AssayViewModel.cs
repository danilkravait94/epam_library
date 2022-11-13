using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    /// <summary>
    /// Bll Assay on a home page
    /// </summary>
    public class AssayViewModel : EntityView
    {
        /// <summary>
        /// Author of an assay
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// title of an assay
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The main part
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// list of assay tags
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();
        /// <summary>
        /// no parameter constructor
        /// </summary>
        public AssayViewModel()
        {

        }
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="author">autor of the assay</param>
        /// <param name="title">assay`s title</param>
        /// <param name="text">a main part</param>
        public AssayViewModel(string author, string title, string text)
        {
            Author = author;
            Title = title;
            Text = text;
        }
    }
}