using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;

namespace Domain
{
    [Serializable]
    public class Invoice : IGenericObject
    {
        private Auto _auto;
        private int _invoiceNo;
        private DateTime _date;
        private Employee _employee;

        public Invoice(BindingList<InvoiceItem> invoiceItems)
        {
            InvoiceItems = invoiceItems;
        }

        public Invoice() { }

        public int InvoiceNumber
        {
            get => _invoiceNo;
            set => _invoiceNo = value;
        }
        public int Total { get; set; }
        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        [Browsable(false)]
        public Auto Auto
        {
            get => _auto;
            set => _auto = value;
        }

        [Browsable(false)]
        public Employee Employee
        {
            private get => _employee;
            set => _employee = value;
        }

        public BindingList<InvoiceItem> InvoiceItems { get; set; }

        public string GetTableName()
        {
            return "Invoice";
        }

        public string GetPrimaryKeyName()
        {
            return "InvoiceNumber";
        }

        public string GetPrimaryKeyValue()
        {
            return "InvoiceNumber=" + InvoiceNumber + "";
        }

        public string GetInsertValues()
        {
            return "('" + _date.ToShortDateString() + "'," + Total + "," +
                   Auto.AutoId + "," + Employee.Id + ")";
        }

        public string GetInsertColumns()
        {
            return "(DateCreated, Total, AutoID, EmployeeId)";
        }

        public string GetUpdateValues()
        {
            return null;
        }

        public string GetCondition()
        {
            return "AutoID=" + Auto.AutoId + "";
        }

        public List<IGenericObject> GetList(OleDbDataReader reader)
        {
            var invoices = new List<IGenericObject>();
            while (reader.Read())
            {
                var racun = new Invoice
                {
                    _invoiceNo = reader.GetInt32(0),
                    _date = reader.GetDateTime(1),
                    Total = reader.GetInt32(2),
                    _auto = new Auto
                    {
                        AutoId = reader.GetInt32(3)
                    },
                    _employee = new Employee
                    {
                        Id = reader.GetInt32(4)
                    }
                };
                invoices.Add(racun);
            }
            return invoices;
        }

        public IGenericObject GetObject(OleDbDataReader reader)
        {
            Invoice invoice = null;
            if (reader.Read())
            {
                invoice = new Invoice
                {
                    _invoiceNo = reader.GetInt32(0),
                    _date = reader.GetDateTime(1),
                    Total = reader.GetInt32(2),
                    _auto = new Auto
                    {
                        AutoId = reader.GetInt32(3)
                    },
                    _employee = new Employee
                    {
                        Id = reader.GetInt32(4)
                    }
                };
            }
            return invoice;
        }

        public override string ToString()
        {
            return _invoiceNo.ToString();
        }
    }
}