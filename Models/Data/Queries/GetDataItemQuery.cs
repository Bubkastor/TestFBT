using MediatR;

namespace Models.Data.Queries;

public class GetDataItemQuery : IRequest<IList<DataItemResponse>>
{
    public int? CodeFilter { get; set; }
}
