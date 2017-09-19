using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using SystemOperations;

namespace BLL
{
    public class BLLController
    {
        public static List<string> GetEmployeesNames()
        {
            var getAllEmployees = new GetAllSO();
            var list = getAllEmployees.ExecuteSO(new Employee()) as List<IGenericObject>;
            var employeesNames = new List<string>();
            if (list == null) return employeesNames;
            employeesNames.AddRange(from Employee rad in list select rad.Username);
            return employeesNames;
        }

        public Employee Login(Employee employee)
        {
            var loginSo = new GetSO();
            return loginSo.ExecuteSO(employee) as Employee;
        }

        //public List<Employee> VratiSveZaposlene()
        //{
        //    var vratiZaposlene = new GetAllSO();

        //    var listaPomocna = vratiZaposlene.ExecuteSO(new Employee()) as List<IGenericObject>;
        //    var listaZaposlenih = new List<Employee>();

        //    foreach (Employee radnik in listaPomocna)
        //        listaZaposlenih.Add(radnik);
        //    return listaZaposlenih;
        //}

        public static List<Employee> FindEmployee(string criteria)
        {
            var tmpEmployee = new Employee { Id = Convert.ToInt32(criteria) };
            var findSo = new FindSO();
            var tmpList = findSo.ExecuteSO(tmpEmployee) as List<IGenericObject>;
            return tmpList?.Cast<Employee>().ToList();
        }

        public static int GetNewId(IGenericObject obj)
        {
            var getNewIdso = new GetNewIDSO();
            return Convert.ToInt32(getNewIdso.ExecuteSO(obj));
        }

        public static List<Owner> GetAllOwners()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new Owner()) as List<IGenericObject>;
            return tmpList?.Cast<Owner>().ToList();
        }

        public static List<AutoType> GetAllAutoTypes()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new AutoType()) as List<IGenericObject>;
            return tmpList?.Cast<AutoType>().ToList();
        }

        public static int Input(IGenericObject obj)
        {
            var inputSo = new InputSO();
            return Convert.ToInt32(inputSo.ExecuteSO(obj));
        }

        public static List<Service> FindServices(string criteria)
        {
            var tmpService = new Service { Name = criteria };
            var findSo = new FindSO();
            var tmpList = findSo.ExecuteSO(tmpService) as List<IGenericObject>;
            return tmpList?.Cast<Service>().ToList();
        }

        public static int UpdateService(Service service)
        {
            var updateSo = new UpdateSO();
            return Convert.ToInt32(updateSo.ExecuteSO(service));
        }

        public static int UpdateAuto(Auto auto)
        {
            var updateSo = new UpdateSO();
            return Convert.ToInt32(updateSo.ExecuteSO(auto));
        }

        public static List<Auto> FindAutos(string criteria)
        {
            var tmpAuto = new Auto { RegNumber = criteria };
            var findSo = new FindSO();
            var tmpList = findSo.ExecuteSO(tmpAuto) as List<IGenericObject>;
            return tmpList?.Cast<Auto>().ToList();
        }

        public static int DeleteAuto(Auto auto)
        {
            var deleteSo = new DeleteSO();
            return Convert.ToInt32(deleteSo.ExecuteSO(auto));
        }

        public static List<Employee> GetAllEmployees()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new Employee()) as List<IGenericObject>;
            return tmpList?.Cast<Employee>().ToList();
        }

        public static List<Service> GetAllServices()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new Service()) as List<IGenericObject>;
            return tmpList?.Cast<Service>().ToList();
        }

        public static List<InvoiceItem> GetAllInvoiceItems()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new InvoiceItem()) as List<IGenericObject>;
            return tmpList?.Cast<InvoiceItem>().ToList();
        }

        public static List<Auto> GetAllAutos()
        {
            var getAllSo = new GetAllSO();
            var tmpList = getAllSo.ExecuteSO(new Auto()) as List<IGenericObject>;
            return tmpList?.Cast<Auto>().ToList();
        }

        public static List<Invoice> FindInvoices(string criteria)
        {
            var invoice = new Invoice();
            var id = Convert.ToInt32(criteria);
            invoice.Auto = new Auto
            {
                AutoId = id
            };

            var findSo = new FindSO();
            var tmpList = findSo.ExecuteSO(invoice) as List<IGenericObject>;
            return tmpList?.Cast<Invoice>().ToList();
        }

        public static List<InvoiceItem> FindInvoiceItems(string criteria)
        {
            var invoiceItem = new InvoiceItem();
            var id = Convert.ToInt32(criteria);
            invoiceItem.InvoiceNumber = id;

            var findSo = new FindSO();
            var getSo = new GetSO();
            var tmpList = findSo.ExecuteSO(invoiceItem) as List<IGenericObject>;
            var invoiceItems = tmpList?.Cast<InvoiceItem>().ToList();
            if (invoiceItems != null)
                foreach (var item in invoiceItems)
                {
                    var service = getSo.ExecuteSO(new Service {Id = item.Service.Id}) as Service;
                    item.Service = service;
                }
            return invoiceItems;
        }
    }
}