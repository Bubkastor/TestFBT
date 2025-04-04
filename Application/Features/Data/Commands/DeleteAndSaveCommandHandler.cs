using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Models.Data.Commands;
using Persistance.Models;
using Persistance.Repositories;

namespace Application.Features.Data.Commands;

internal class DeleteAndSaveCommandHandler(IDataRepository dataRepository, IMapper mapper, ILogger<DeleteAndSaveCommandHandler> logger) : IRequestHandler<DeleteAndSaveCommand, bool>
{
    public async Task<bool> Handle(DeleteAndSaveCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await dataRepository.DeleteAllAsync();
            var sorterdItems = request.DataItems.OrderBy(x => x.Code);
            var items = mapper.Map<IList<DataEntite>>(sorterdItems.ToList());
            await dataRepository.AddRangeAsync(items);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error with database");
            return false;
        }
    }
}
