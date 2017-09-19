using Domain;
using Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class GetAllSO : GenericSO
    {
        protected override object Execute(IGenericObject odo, Broker broker)
        {
            return broker.GetAllObjects(odo);
        }
    }
}
