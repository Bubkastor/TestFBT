using MediatR;

namespace Models.Data.Commands;

public class DeleteAndSaveCommand : IRequest<bool>
{
    public required IList<DataItem> DataItems { get; set; }
}
