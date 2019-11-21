using Data.DataService;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private IGenericRepository<Contact> _repository;

        public ContactService()
        {
            _repository = new GenericRepository<Contact>();
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        public Contact GetById(object id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Contact obj)
        {
            _repository.Insert(obj);
        }

        public void Update(Contact obj)
        {
            _repository.Update(obj);
        }
    }
}
