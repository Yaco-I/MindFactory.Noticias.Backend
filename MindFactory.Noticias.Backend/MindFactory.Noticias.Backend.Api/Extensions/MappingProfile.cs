using AutoMapper;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Services.DTOs.Categoria;
using MindFactory.Noticias.Backend.Services.DTOs.Noticia;

namespace MindFactory.Noticias.Backend.Api.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria, CategoriaDto>().ReverseMap();

        CreateMap<Noticia, NoticiaDto>()
            .ForCtorParam("CategoriaNombre", opt => opt.MapFrom(src => src.Categoria.Nombre));


        CreateMap<NoticiaDto, Noticia>()
            .ForMember(dest => dest.Categoria, opt => opt.Ignore());
    }
}
