using AutoMapper;
using Library.BLL.BLLEntities;
using Library.BLL.Exceptions;
using Library.BLL.Interfaces;
using Library.DLL.Entities;
using Library.DLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    /// <summary>
    /// Servise for assays
    /// </summary>
    public class AssayService : IAssayService
    {
        /// <summary>
        /// Assay repository
        /// </summary>
        UnitOfWork DB { get; set; }
        /// <summary>
        /// Construcor
        /// </summary>
        public AssayService(UnitOfWork db)
        {
            DB = db;
        }
        /// <summary>
        /// Get all assays
        /// </summary>
        /// <returns>a list of assays</returns>
        public IEnumerable<BLLAssay> GetAll()
        {
            var Assays = DB.Assays.GetAll();
            List<BLLAssay> assays = new List<BLLAssay>();
            foreach (var assay in Assays)
            {
                assays.Add(new BLLAssay(assay.Author, assay.Title, assay.Text) { Id = assay.AssayID, Tags = assay.Tags.Split('/').ToList() });
            }
            return assays.AsEnumerable();
        }

        /// <summary>
        /// Get an assay by id
        /// </summary>
        /// <param name="id"> the id of item</param>
        /// <returns>Assay</returns>
        public BLLAssay Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ессе", "");
            var assay = DB.Assays.Get(id.Value);
            if (assay == null)
                throw new ValidationException("Ессе не найден", "");

            return new BLLAssay(assay.Author, assay.Title, assay.Text) { Id = assay.AssayID, Tags = assay.Tags.Split('/').ToList() };
        }
        /// <summary>
        /// Create an assay 
        /// </summary>
        /// <param name="item">the assay</param>
        public void Create(BLLAssay item)
        {
            if (item is null)
            {
                throw new ValidationException("Не установлено ессе", "");
            }
            string tags = string.Empty;
            foreach (var str in item.Tags)
            {
                tags += str + "/";
            }
            Assay assay = new Assay
            {
                Text = item.Text,
                Title = item.Title,
                Author = item.Author,
               Tags = tags.Substring(0,tags.Length-1)
            };

            DB.Assays.Create(assay);
            DB.Save();
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            DB.Assays.Dispose();
        }
        /// <summary>
        /// get all tags that we have on assays
        /// </summary>
        /// <returns></returns>
        public string[] GetTags()
        {
            List<string> tags = new List<string>();
            var assays = GetAll().Select(s => s.Tags);
            foreach (var list in assays)
            {
                foreach (var tag in list)
                {
                    if(!tags.Contains(tag))
                    {
                        tags.Add(tag);
                    }
                }
            }
            return tags.ToArray();
        }
        /// <summary>
        /// Update item in database
        /// </summary>
        /// <param name="item"></param>
        public void Update(BLLAssay item)
        {
            if (item is null)
            {
                throw new ValidationException("Не установлено ессе", "");
            }
            string tags = string.Empty;
            foreach (var str in item.Tags)
            {
                tags += str + "/";
            }
            Assay assay = new Assay
            {
                AssayID = item.Id,
                Text = item.Text,
                Title = item.Title,
                Author = item.Author,
                Tags = tags.Substring(0, tags.Length - 1)
            };

            DB.Assays.Update(assay);
            DB.Save();
        }
    }
}
