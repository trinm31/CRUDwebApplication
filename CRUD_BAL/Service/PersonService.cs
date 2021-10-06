using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;

namespace CRUD_BAL.Service
{
    public class PersonService
    {
        private readonly IRepository<Person> _person;  
  
        public PersonService(IRepository<Person> perosn)  
        {  
            _person = perosn;  
        }  
        //Get Person Details By Person Id  
        public IEnumerable<Person> GetPersonByUserId(string UserId)  
        {  
            return _person.GetAll().Where(x => x.Useremail == UserId).ToList();  
        }  
        //GET All Perso Details   
        public IEnumerable<Person> GetAllPersons()  
        {  
            try  
            {  
                return _person.GetAll().ToList();  
            }  
            catch (Exception)  
            {  
                throw;  
            }  
        }  
        //Get Person by Person Name  
        public Person GetPersonByUserName(string UserName)  
        {  
            return _person.GetAll().Where(x => x.Useremail == UserName).FirstOrDefault();  
        }  
        //Add Person  
        public async Task<Person> AddPerson(Person Person)  
        {  
            return await _person.Create(Person);  
        }  
        //Delete Person   
        public bool DeletePerson(string UserEmail)  
        {  
  
            try  
            {  
                var DataList = _person.GetAll().Where(x => x.Useremail == UserEmail).ToList();  
                foreach (var item in DataList)  
                {  
                    _person.Delete(item);  
                }  
                return true;  
            }  
            catch (Exception)  
            {  
                return true;  
            }  
  
        }  
        //Update Person Details  
        public bool UpdatePerson(Person person)  
        {  
            try  
            {
                _person.Update(person);
                return true;  
            }  
            catch (Exception)  
            {  
                return true;  
            }  
        }
    }
}