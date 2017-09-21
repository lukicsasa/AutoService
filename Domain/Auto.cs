using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Runtime.Remoting.Messaging;

namespace Domain
{
    [Serializable]
    public class Auto : IGenericObject
    {
        private int _autoId;
        private string _regNumber;
        private string _color;
        private int _numberOfDoors;
        private int _productionYear;
        private string _gas;
        private AutoType _autoTypeType;
        private Owner _owner;

        public int AutoId
        {
            get => _autoId;
            set => _autoId = value;
        }

        public string RegNumber
        {
            get => _regNumber;
            set => _regNumber = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public int ProductionYear
        {
            get => _productionYear;
            set => _productionYear = value;
        }

        public int NumberOfDoors
        {
            get => _numberOfDoors;
            set => _numberOfDoors = value;
        }

        public string Gas
        {
            get => _gas;
            set => _gas = value;
        }

        public Owner Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public AutoType AutoType
        {
            get => _autoTypeType;
            set => _autoTypeType = value;
        }

        [Browsable(false)]
        public bool IsComplex => false;
        [Browsable(false)]
        public string ChildObjectTableName => null;

        [Browsable(false)]
        public List<IGenericObject> ChildObjects => null;

        public string GetTableName()
        {
            return "Auto";
        }

        public string GetPrimaryKeyName()
        {
            return "Id";
        }

        public string GetPrimaryKeyValue()
        {
            return "Id=" + _autoId + "";
        }

        public string GetCondition()
        {
            return "((Auto.RegNumber) LIKE '%" + _regNumber + "%')";
        }

        public string GetInsertColumns()
        {
            return "(RegNumber, Color, ProductionYear, NumberOfDoors, Gas, AutoTypeId, OwnerId)";
        }

        public string GetInsertValues()
        {
            return "('" + _regNumber + "','" + _color + "'," + _productionYear + "," + _numberOfDoors + ",'" + _gas +
                   "'," + AutoType.Id + "," + Owner.Id + ")";
        }

        public string GetUpdateValues()
        {
            return "RegNumber='" + _regNumber + "', Color='" + _color + "', ProductionYear=" + _productionYear + ", NumberOfDoors=" + _numberOfDoors +
                   ", Gas='" + _gas + "',AutoTypeId=" + AutoType.Id + ", OwnerId=" + Owner.Id + "";
        }

        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var autos = new List<IGenericObject>();
            while (reader.Read())
            {
                var auto = new Auto
                {
                    AutoId = reader.GetInt32(0),
                    RegNumber = reader.GetString(1),
                    Color = reader.GetString(2),
                    ProductionYear = reader.GetInt32(3),
                    NumberOfDoors = reader.GetInt32(4),
                    Gas = reader.GetString(5),
                    AutoType = new AutoType
                    {
                        Id = reader.GetInt32(6)
                    },
                    Owner = new Owner
                    {
                        Id = reader.GetInt32(7)
                    }
                };
                autos.Add(auto);
            }
            return autos;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            if (!reader.Read()) return null;
            var auto = new Auto
            {
                AutoId = reader.GetInt32(0),
                RegNumber = reader.GetString(1),
                Color = reader.GetString(2),
                ProductionYear = reader.GetInt32(3),
                NumberOfDoors = reader.GetInt32(4),
                Gas = reader.GetString(5),
                AutoType = new AutoType
                {
                    Id = reader.GetInt32(6)
                },
                Owner = new Owner
                {
                    Id = reader.GetInt32(7)
                }
            };
            return auto;
        }

        public override string ToString()
        {
            return _regNumber;
        }
    }
}