using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class InvoiceItem : IGenericObject
    {
        [Browsable(false)]
        public bool IsComplex => false;
        [Browsable(false)]
        public List<IGenericObject> ChildObjects => null;
        [Browsable(false)]
        public string ChildObjectTableName => null;

        private int _invoiceNo;

        private int _sortNumber;

        private Service _service;

        private int _value;

        [Browsable(false)]
        public int InvoiceNumber
        {
            get => _invoiceNo;
            set => _invoiceNo = value;
        }

        [Browsable(false)]
        public int SortNumber
        {
            get => _sortNumber;
            private set => _sortNumber = value;
        }

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public Service Service
        {
            get => _service;
            set => _service = value;
        }

        public string GetTableName()
        {
            return "InvoiceItem";
        }

        public string GetPrimaryKeyName()
        {
            return "SortNumber";
        }

        public string GetPrimaryKeyValue()
        {
            return "InvoiceNumber=" + InvoiceNumber + " AND SortNumber=" + SortNumber + "";
        }

        public string GetCondition()
        {
            return "InvoiceNumber= " + InvoiceNumber + "";
        }

        public string GetInsertValues()
        {
            return "(" + InvoiceNumber + "," + Service.Id + "," + Value + ")";
        }

        public string GetInsertColumns()
        {
            return "(InvoiceNumber, ServiceId, ItemValue)";
        }

        public string GetUpdateValues()
        {
            return null;
        }


        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var invoiceItems = new List<IGenericObject>();
            while (reader.Read())
            {
                var st = new InvoiceItem
                {
                    SortNumber = reader.GetInt32(0),
                    InvoiceNumber = reader.GetInt32(1),
                    Service = new Service
                    {
                        Id = reader.GetInt32(2),
                    },
                    _value = reader.GetInt32(3)
                };
                invoiceItems.Add(st);
            }
            return invoiceItems;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            InvoiceItem invoiceItem = null;
            if (reader.Read())
            {
                invoiceItem = new InvoiceItem
                {
                    SortNumber = reader.GetInt32(0),
                    InvoiceNumber = reader.GetInt32(1),
                    Service = new Service
                    {
                        Id = reader.GetInt32(2),
                        Name = ""
                    },
                    _value = reader.GetInt32(3)
                };

            }
            return invoiceItem;
        }

        public override string ToString()
        {
            return "InvoiceNumber" + _invoiceNo + "SortNumber" + _sortNumber + "Service" + Service.Name;
        }
    }
}