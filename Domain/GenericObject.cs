using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Domain
{
    public interface IGenericObject
    {
        string GetTableName();

        string GetInsertValues();

        string GetUpdateValues();

        string GetPrimaryKeyValue();

        string GetPrimaryKeyName();

        string GetCondition();

        string GetInsertColumns();

        IGenericObject GetObject(OleDbDataReader reader);

        List<IGenericObject> GetList(OleDbDataReader reader);
    }
}
