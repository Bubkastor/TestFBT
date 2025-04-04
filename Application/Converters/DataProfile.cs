using AutoMapper;
using Models.Data;
using Persistance.Models;

namespace Application.Converters;

public class DataProfile : Profile
{
    public DataProfile()
    {
        CreateMap<DataEntite, DataItemResponse>();
        CreateMap<DataItem, DataEntite>();
    }
}
