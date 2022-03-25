using AutoMapper;

namespace WebApp.Mapping;

public static class MappingExtensions
{
    private static IMapper _mapper;
    public static void Configure(IMapper mapper)
    {
        _mapper = mapper;
    }
    /// <summary>
    /// Маппинг в [этот тип]
    /// </summary>
    /// <typeparam name="T">В этот тип</typeparam>
    /// <param name="from">Исходный объект</param>
    /// <returns>Требуемые объект</returns>
    public static T Map<T>(this object from)
    {
        return _mapper.Map<T>(from);
    }
}
