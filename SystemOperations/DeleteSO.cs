using Domain;
using Session;

namespace SystemOperations
{
    public class DeleteSO : GenericSO
    {
        protected override object Execute(IGenericObject odo, Broker broker)
        {
            return broker.Delete(odo);
        }
    }
}
