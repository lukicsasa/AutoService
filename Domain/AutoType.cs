using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class AutoType : IGenericObject
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private string Name { get; set; }

        public string GetTableName()
        {
            return "AutoType";
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
            return "('" + Name + "')";
        }

        public string GetUpdateValues()
        {
            throw new NotImplementedException();
        }

        public string GetCondition()
        {
            throw new NotImplementedException();
        }

        public string GetInsertColumns()
        {
            return "(name)";
        }


        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var autoTypes = new List<IGenericObject>();
            while (reader.Read())
            {
                var tipAuto = new AutoType
                {
                    _id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };


                autoTypes.Add(tipAuto);
            }
            return autoTypes;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            AutoType autoType = null;
            if (reader.Read())
                autoType = new AutoType
                {
                    _id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
            return autoType;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}