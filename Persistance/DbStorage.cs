using LinqToDB;
using LinqToDB.Data;
using Persistance.Models;

namespace Persistance;

internal class DbStorage(DbStorageOptions dbStorageOptions) : DataConnection(dbStorageOptions.DataOptions)
{

    public ITable<DataEntite> DataEntites => this.GetTable<DataEntite>();

}
