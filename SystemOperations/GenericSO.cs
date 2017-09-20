using Domain;
using Session;
using System;
using System.Collections.Generic;

namespace SystemOperations
{
    public abstract class GenericSO
    {
        private readonly Broker _broker;

        protected GenericSO()
        {
            _broker = Broker.GetSession();
        }

        public object ExecuteSO(IGenericObject odo)
        {
            object result;

            _broker.OpenConnection();
            _broker.BeginTransaction();

            try
            {
                result = Execute(odo, _broker);
                _broker.Save();
            }
            catch (Exception ex)
            {
                _broker.Rollback();
                throw ex;
            }
            finally
            {
                _broker.CloseConnection();
            }

            return result;
        }

        protected virtual object Execute(IGenericObject odo, Broker broker)
        {
            return null;
        }
    }
}
