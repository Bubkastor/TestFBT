using Persistance.Models;

namespace Persistance.Repositories
{
    public interface IDataRepository
    {
        public Task DeleteAllAsync();
        public Task AddRangeAsync(IList<DataEntite> dataEntites);
        public Task<IList<DataEntite>> GetDataEntitesByFilterCodeAsync(int? code);
    }
}
