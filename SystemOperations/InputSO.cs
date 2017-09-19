using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Session;

namespace SystemOperations
{
    public class InputSO : GenericSO
    {
        protected override object Execute(IGenericObject odo, Broker broker)
        {
            return broker.Input(odo);
        }
    }
}
