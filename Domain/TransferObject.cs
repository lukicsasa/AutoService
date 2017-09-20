using System;

namespace Domain
{
    public enum Operation
    {
        End = 1,
        Login,
        GetEmployeesNames,
        FindEmployee,
        GetAutoTypes,
        GetNewID,
        GetAllOwners,
        Input,
        FindService,
        UpdateService,
        UpdateAuto,
        FindAuto,
        DeleteAuto,
        GetAllEmployees,
        FindInvoice,
        GetAllServices,
        GetAllAutos,
        GetAllInvoiceItems,
        FindInvoiceItems
    }

    [Serializable]
    public class TransferObject
    {
        private Operation _operation;
        private object _transferObject;

        public Operation Operation
        {
            get => _operation;
            set => _operation = value;
        }

        public object TransferObj
        {
            get => _transferObject;
            set => _transferObject = value;
        }
    }
}