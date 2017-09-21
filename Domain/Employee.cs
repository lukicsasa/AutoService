using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class Employee : IGenericObject
    {
        [Browsable(false)]
        public bool IsComplex => false;
        [Browsable(false)]
        public List<IGenericObject> ChildObjects => null;
        [Browsable(false)]
        public string ChildObjectTableName => null;

        private string _firstName;
        private string _password;
        private string _username;
        private string _lastName;
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            private set => _lastName = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            set => _password = value;
        }

        public string GetTableName()
        {
            return "Employee";
        }

        public string GetPrimaryKeyName()
        {
            return "Id";
        }

        public string GetUpdateValues()
        {
            throw new NotImplementedException();
        }

        public string GetPrimaryKeyValue()
        {
            return "Id='" + _id + "'";
        }


        public string GetInsertValues()
        {
            return null;
        }

        public string GetCondition()
        {
            if (_id != 0) return "Id = '" + _id + "'";
            return "Username ='" + _username + "' AND Password ='" + _password + "'";
        }

        public string GetInsertColumns()
        {
            throw new NotImplementedException();
        }

        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var employees = new List<IGenericObject>();
            while (reader.Read())
            {
                var employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    _username = reader.GetString(3),
                    _password = reader.GetString(4)
                };

                employees.Add(employee);
            }
            return employees;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            Employee employee = null;
            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    _username = reader.GetString(3),
                    _password = reader.GetString(4)
                };
            }
            return employee;
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
}