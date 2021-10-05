using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;

namespace CRUD_DAL.Repository
{
    public class RepositoryPerson: IRepository<Person>  
    {
        ApplicationDbContext _dbContext;  
        public RepositoryPerson(ApplicationDbContext applicationDbContext)  
        {  
            _dbContext = applicationDbContext;  
        }  
        public async Task<Person> Create(Person _object)  
        {  
            var obj = await _dbContext.Persons.AddAsync(_object);  
            _dbContext.SaveChanges();  
            return obj.Entity;  
        }  
  
        public void Delete(Person _object)  
        {  
            _dbContext.Remove(_object);  
            _dbContext.SaveChanges();  
        }  
  
        public IEnumerable<Person> GetAll()  
        {  
            try  
            {  
                return _dbContext.Persons.Where(x => x.IsDeleted == false).ToList();  
            }  
            catch (Exception ee)  
            {  
                throw;  
            }  
        }  
  
        public Person GetById(int Id)  
        {  
            return _dbContext.Persons.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();  
        }  
  
        public void Update(Person _object)  
        {  
            _dbContext.Persons.Update(_object);  
            _dbContext.SaveChanges();  
        } 
    }
}