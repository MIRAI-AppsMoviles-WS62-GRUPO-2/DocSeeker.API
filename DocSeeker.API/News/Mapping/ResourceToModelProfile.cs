using AutoMapper;
using DocSeeker.API.News.Domain.Models;
using DocSeeker.API.News.Resources;

namespace DocSeeker.API.News.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveNewResource, New>();
    }
}