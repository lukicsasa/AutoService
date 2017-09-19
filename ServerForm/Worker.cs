using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Domain;

namespace ServerForm
{
    public class Worker
    {
        private readonly NetworkStream _networkStream;
        private readonly BinaryFormatter _formatter;
        private readonly BLLController _controller;


        public Worker(NetworkStream networkStream)
        {
            _networkStream = networkStream;
            _formatter = new BinaryFormatter();
            _controller = new BLLController();

            ThreadStart ts = Handle;
            var thread = new Thread(ts);
            thread.Start();
        }

        private void Handle()
        {
            try
            {
                var operation = 0;
                while (operation != (int) Operation.End)
                {
                    var transferObject = _formatter.Deserialize(_networkStream) as TransferObject;
                    if (transferObject == null) continue;
                    switch (transferObject.Operation)
                    {
                        case Operation.GetEmployeesNames:
                            transferObject.TransferObj = BLLController.GetEmployeesNames();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.Login:
                            transferObject.TransferObj =
                                _controller.Login(transferObject.TransferObj as Employee);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.FindEmployee:
                            transferObject.TransferObj =
                                BLLController.FindEmployee(transferObject.TransferObj as string);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetNewID:
                            transferObject.TransferObj =
                                BLLController.GetNewId(transferObject.TransferObj as IGenericObject);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAllOwners:
                            transferObject.TransferObj = BLLController.GetAllOwners();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAutoTypes:
                            transferObject.TransferObj = BLLController.GetAllAutoTypes();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.Input:
                            transferObject.TransferObj =
                                BLLController.Input(transferObject.TransferObj as IGenericObject);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.FindService:
                            transferObject.TransferObj =
                                BLLController.FindServices(transferObject.TransferObj as string);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.UpdateService:
                            transferObject.TransferObj =
                                BLLController.UpdateService(transferObject.TransferObj as Service);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.UpdateAuto:
                            transferObject.TransferObj = BLLController.UpdateAuto(transferObject.TransferObj as Auto);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.FindAuto:
                            transferObject.TransferObj =
                                BLLController.FindAutos(transferObject.TransferObj as string);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.DeleteAuto:
                            transferObject.TransferObj =
                                BLLController.DeleteAuto(transferObject.TransferObj as Auto);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAllEmployees:
                            transferObject.TransferObj = BLLController.GetAllEmployees();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.FindInvoice:
                            transferObject.TransferObj =
                                BLLController.FindInvoices(transferObject.TransferObj as string);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAllServices:
                            transferObject.TransferObj = BLLController.GetAllServices();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAllAutos:
                            transferObject.TransferObj = BLLController.GetAllAutos();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.GetAllInvoiceItems:
                            transferObject.TransferObj = BLLController.GetAllInvoiceItems();
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.FindInvoiceItems:
                            transferObject.TransferObj =
                                BLLController.FindInvoiceItems(transferObject.TransferObj as string);
                            _formatter.Serialize(_networkStream, transferObject);
                            break;
                        case Operation.End:
                            operation = 1;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}