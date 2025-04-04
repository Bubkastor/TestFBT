using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Models.Data;
using Models.Data.Queries;
using Persistance.Repositories;

namespace Application.Features.Data.Queries;

internal class GetDataItemQueryHandler(IDataRepository dataRepository, IMapper mapper, ILogger<GetDataItemQueryHandler> logger) : IRequestHandler<GetDataItemQuery, IList<DataItemResponse>>
{
    public async Task<IList<DataItemResponse>> Handle(GetDataItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await dataRepository.GetDataEntitesByFilterCodeAsync(request.CodeFilter);
            return mapper.Map<IList<DataItemResponse>>(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error with database");
            return new List<DataItemResponse>();
        }
    }
}
