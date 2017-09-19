using Domain;
using Session;


namespace SystemOperations
{
    public class FindSO: GenericSO
    {
        protected override object Execute(IGenericObject odo, Broker broker)
        {
            return broker.GetAllObjectsByCondition(odo);
        }
    }
}
