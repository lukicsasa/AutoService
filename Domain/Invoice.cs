using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;

namespace Domain
{
    [Serializable]
    public class Invoice : IGenericObject
    {
        [Browsable(false)]
        public bool IsComplex => true;
        [Browsable(false)]
        public List<IGenericObject> ChildObjects => GenericInvoiceItems;
        [Browsable(false)]
        public string ChildObjectTableName => "InvoiceItem";

        private Auto _auto;
        private int _invoiceNo;
        private DateTime _date;
        private Employee _employee;

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
            get => _employee;
            set => _employee = value;
        }

        [Browsable(false)]
        private List<IGenericObject> GenericInvoiceItems => new List<IGenericObject>(InvoiceItems);

        public List<InvoiceItem> InvoiceItems { get; set; }

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
            return "DateCreated='" + Date.ToShortDateString() + "', Total='" + Total + "', AutoID=" + Auto.AutoId + ", EmployeeId=" + Employee.Id;
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