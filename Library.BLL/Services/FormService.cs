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
    /// Servise for forms
    /// </summary>
    public class FormService : IFormService
    {
        /// <summary>
        /// Form repository
        /// </summary>
        UnitOfWork DB { get; set; }
        /// <summary>
        /// Construcor
        /// </summary>
        public FormService(UnitOfWork db)
        {
            DB = db;
        }
        /// <summary>
        /// Get all forms
        /// </summary>
        /// <returns>a list of forms</returns>
        public IEnumerable<BLLForm> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Form, BLLForm>()).CreateMapper();
            return mapper.Map<IEnumerable<Form>, List<BLLForm>>(DB.Forms.GetAll());
        }
        /// <summary>
        /// Get a form by id
        /// </summary>
        /// <param name="id"> the id of item</param>
        /// <returns>Form</returns>
        public BLLForm Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id формы", "");
            var form = DB.Forms.Get(id.Value);
            if (form == null)
                throw new ValidationException("Форма не найден", "");

            return new BLLForm()
            {
                Name = form.Name,
                Surname = form.Surname,
                Country = form.Country,
                smths = form.smths
            };
        }
        /// <summary>
        /// Create a form 
        /// </summary>
        /// <param name="item">the form</param>
        public void Create(BLLForm item)
        {
            if (item is null)
            {
                throw new ValidationException("Не установлена форма", "");
            }
            Form form = new Form
            {
                FormID = item.Id,
                Name = item.Name,
                Surname = item.Surname,
                Country = item.Country,
                smths = item.smths
            };

            DB.Forms.Create(form);
            DB.Save();
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            DB.Forms.Dispose();
        }
    }
}
