using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class Owner : IGenericObject
    {
        private string _email;
        private string _firstName;
        private string _phone;
        private string _lastName;
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string FirstName
        {
            private get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            private get => _lastName;
            set => _lastName = value;
        }

        public string Phone
        {
            private get => _phone;
            set => _phone = value;
        }

        public string Email
        {
            private get => _email;
            set => _email = value;
        }


        public string GetTableName()
        {
            return "Owner";
        }

        public string GetPrimaryKeyName()
        {
            return "Id";
        }

        public string GetPrimaryKeyValue()
        {
            return "Id='" + _id + "'";
        }

        public string GetInsertValues()
        {
            return "('" + FirstName + "','" + LastName + "','" + Phone + "','" + Email + "')";
        }

        public string GetUpdateValues()
        {
            return null;
        }

        public string GetCondition()
        {
            return null;
        }

        public string GetInsertColumns()
        {
            return "(FirstName, LastName, Phone, Email)";
        }

        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var owners = new List<IGenericObject>();
            while (reader.Read())
            {
                var owner = new Owner
                {
                    _id = reader.GetInt32(0),
                    _firstName = reader.GetString(1),
                    _lastName = reader.GetString(2),
                    _phone = reader.GetString(3),
                    _email = reader.GetString(4)
                };
                owners.Add(owner);
            }
            return owners;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            Owner owner = null;
            if (reader.Read())
            {
                owner = new Owner
                {
                    _id = reader.GetInt32(0),
                    _firstName = reader.GetString(1),
                    _lastName = reader.GetString(2),
                    _phone = reader.GetString(3),
                    _email = reader.GetString(4)
                };
            }
            return owner;
        }

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }
    }
}