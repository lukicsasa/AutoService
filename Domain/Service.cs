using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class Service : IGenericObject
    {
        [Browsable(false)]
        public bool IsComplex => false;
        [Browsable(false)]
        public List<IGenericObject> ChildObjects => null;
        [Browsable(false)]
        public string ChildObjectTableName => null;

        private int _price;
        private string _name;

        private string _description;
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string GetTableName()
        {
            return "Service";
        }

        public string GetPrimaryKeyName()
        {
            return "Id";
        }

        public string GetPrimaryKeyValue()
        {
            return "Id=" + _id + "";
        }

        public string GetInsertValues()
        {
            return "('" + Name + "'," + Price + ",'" + Description + "')";
        }

        public string GetUpdateValues()
        {
            return "Name='" + _name + "', Price=" + _price + ", Description='" + _description + "'";
        }

        public string GetCondition()
        {
            return "((Service.Id)=" + Id + ")";
        }

        public string GetInsertColumns()
        {
            return "(Name, Price, Description)";
        }

        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var services = new List<IGenericObject>();
            while (reader.Read())
            {
                var service = new Service
                {
                    _id = reader.GetInt32(0),
                    _name = reader.GetString(1),
                    _price = reader.GetInt32(2),
                    _description = reader.GetString(3)
                };

                services.Add(service);
            }
            return services;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            Service service = null;
            if (reader.Read())
            {
                service = new Service
                {
                    _id = reader.GetInt32(0),
                    _name = reader.GetString(1),
                    _price = reader.GetInt32(2),
                    _description = reader.GetString(3)
                };
            }
            return service;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}