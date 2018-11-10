using Datalayer.Context;
using Datalayer.Models;
using Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Services
{
  public  class PersonRepository : IPersonRepository
    {
        private MyContext db;


        public PersonRepository(MyContext context)
        {
            db = context;
        }

     
       
        public void DeletePerson(Person person)
        {
            
            db.Entry(person).State = System.Data.Entity.EntityState.Deleted;
        }

        public void DeletePerson(int personId)
        {
            var person = GetPersonById(personId);
            DeletePerson(person);
        }

        public List<Person> GetAllPerson()
        {
            return db.Persons.ToList();
        }

        public Person GetPersonById(int personId)
        {
            return db.Persons.Find(personId);
        }

        public void InsertPerson(Person person)
        {
            db.Persons.Add(person);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
