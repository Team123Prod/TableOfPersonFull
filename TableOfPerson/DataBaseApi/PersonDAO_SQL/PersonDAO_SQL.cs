﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi.PersonDAO_SQL
{
    public abstract class PersonDAO_SQL: IPerson_DAO, IPhone_DAO
    {
        protected string tablePerson = "";
        protected string tablePhone = "";

        public PersonDAO_SQL()
        {
            tablePerson = "person";
            tablePhone = "phones";
        }

        public void Create(Person person)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {tablePerson} (Id, FirstName, LastName, Age) " +
                $"VALUES ({person.id}, '{person.fn}', '{person.ln}', {person.age})";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public void Delete(Person person)
        {
            OpenConnection();
            string cmd =
                $"Delete FROM {tablePerson} " +
                $"WHERE Id = {person.id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public List<Person> Read()
        {
            OpenConnection();
            string cmd = $"SELECT * FROM {tablePerson} LEFT JOIN {tablePhone} ON {tablePerson}.Id = {tablePhone}.IdPerson;";
            List<Person> listPerson = ReadData(cmd);
            CloseConnection();
            return listPerson;
        }

        public void Update(Person person)
        {
            OpenConnection();
            string cmd =
                $"UPDATE {tablePerson} " +
                $"SET FirstName = '{person.fn}', LastName='{person.ln}', Age={person.age} " +
                $"WHERE Id = {person.id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        abstract protected void CloseConnection();
        abstract protected void OpenConnection();
        abstract protected void ExecuteCommand(string cmd);
        abstract protected List<Person> ReadData(string cmd);

        public void AddPhone(int id, string phone)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {tablePhone} (IdPerson, Phone) " +
                $"VALUES ('{id}', '{phone}')";
            ExecuteCommand(cmd);
            CloseConnection();
        }
        public void DeletePhone(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> Search(string searchLine)
        {
            throw new NotImplementedException();
        }

        
    }
}
