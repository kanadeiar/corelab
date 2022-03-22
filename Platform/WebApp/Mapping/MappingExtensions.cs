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
    /// Маппинг из [этого типа] в [этот тип]
    /// </summary>
    /// <typeparam name="P">Из этого типа</typeparam>
    /// <typeparam name="T">В этот тип</typeparam>
    /// <param name="from">Исходный объект</param>
    /// <returns>Требуемые объект</returns>
    public static T Map<P, T>(this P from)
    {
        return _mapper.Map<T>(from);
    }
}
