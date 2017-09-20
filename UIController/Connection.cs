using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Domain;

namespace UIController
{
    public class Connection
    {
        private BinaryFormatter _formatter;
        private TcpClient _client;
        private NetworkStream _networkStream;


        public void Connect()
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 50000);
                _networkStream = _client.GetStream();
                _formatter = new BinaryFormatter();

            }
            catch
            {
                MessageBox.Show("Error establishing connection, try again!");
                throw;
            }
        }
        

        public Employee Login(Employee employee)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = employee,
                    Operation = Operation.Login
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as Employee;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }
        
        internal List<AutoType> GetAllAutoTypes()
        {
            try
            {
                var transfer = new TransferObject {Operation = Operation.GetAutoTypes};
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<AutoType>;
            }
            catch (Exception)
            {
                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        internal List<Owner> GetAllOwners()
        {
            try
            {
                var transfer = new TransferObject {Operation = Operation.GetAllOwners};
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Owner>;
            }
            catch (Exception)
            {
                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public int GetNewId(IGenericObject obj)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = obj,
                    Operation = Operation.GetNewID
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                if (transfer != null) return (int) transfer.TransferObj;
                return -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public int Input(IGenericObject odo)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = odo,
                    Operation = Operation.Input
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                if (transfer != null) return (int) transfer.TransferObj;
                return -1;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public List<Service> FindServices(string criteria)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = criteria,
                    Operation = Operation.FindService
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Service>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public int UpdateService(Service service)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = service,
                    Operation = Operation.UpdateService
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                if (transfer != null) return (int) transfer.TransferObj;
                return -1;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public int UpdateAuto(Auto auto)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = auto,
                    Operation = Operation.UpdateAuto
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                if (transfer != null) return (int) transfer.TransferObj;
                return -1;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public List<Auto> FindAuto(string criteria)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = criteria,
                    Operation = Operation.FindAuto
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Auto>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        public int DeleteAuto(Auto auto)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = auto,
                    Operation = Operation.DeleteAuto
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                if (transfer != null) return (int) transfer.TransferObj;
                return -1;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        internal List<Employee> GetAllEmployees()
        {
            try
            {
                var transfer = new TransferObject {Operation = Operation.GetAllEmployees};
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Employee>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }

        internal List<Service> GetAllServices()
        {
            try
            {
                var transfer = new TransferObject {Operation = Operation.GetAllServices};
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Service>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }


        internal List<Auto> GetAllAutos()
        {
            try
            {
                var transfer = new TransferObject {Operation = Operation.GetAllAutos};
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Auto>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }
        
        public List<InvoiceItem> FindInvoiceItems(string criteria)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = criteria,
                    Operation = Operation.FindInvoiceItems
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<InvoiceItem>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }


        public List<Invoice> FindInvoice(string criteria)
        {
            try
            {
                var transfer = new TransferObject
                {
                    TransferObj = criteria,
                    Operation = Operation.FindInvoice
                };
                _formatter.Serialize(_networkStream, transfer);

                transfer = _formatter.Deserialize(_networkStream) as TransferObject;
                return transfer?.TransferObj as List<Invoice>;
            }
            catch (Exception)
            {

                MessageBox.Show("Error establishing connection!");
                throw;
            }
        }
    }
}