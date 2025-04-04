using LinqToDB;
using LinqToDB.Data;
using Persistance.Models;

namespace Persistance.Repositories
{
    internal class DataRepository(DbStorage storage) : IDataRepository
    {
        public async Task AddRangeAsync(IList<DataEntite> dataEntites)
        {
            await storage.DataEntites.BulkCopyAsync(dataEntites);
        }

        public async Task DeleteAllAsync()
        {
            await storage.DataEntites.DeleteAsync();
        }

        public async Task<IList<DataEntite>> GetDataEntitesByFilterCodeAsync(int? code)
        {
            if (code.HasValue)
            {
                return await storage.DataEntites.Where(x => x. Code == code).ToListAsync();
            }
            else
            {
                return await storage.DataEntites.ToListAsync();
            }
        }
    }
}
