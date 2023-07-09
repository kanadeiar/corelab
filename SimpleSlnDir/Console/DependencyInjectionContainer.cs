using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Контейнер внедрения зависимостей
/// </summary>
public static class DependencyInjectionContainer
{
    private static IServiceProvider? _provider;
    private static IServiceCollection? _collection;

    /// <summary>
    /// Сервисы для использования из постащика сервисов из контейнера внедрения зависимостей
    /// </summary>
    public static IServiceProvider Services => _provider ?? Build();

    /// <summary>
    /// Создать коллекцию сервисов - это начало конфигурирования контейнера
    /// </summary>
    /// <returns>Коллекция сервисов для конфигурирования</returns>
    public static IServiceCollection CreateServiceCollection()
    {
        _collection = new ServiceCollection();
        InternalRegisterServices(_collection);
        return _collection;
    }

    /// <summary>
    /// Создать и сконфигурировать коллекцию сервисов - это конфигурирование контейнера
    /// </summary>
    /// <param name="action">Конфигуратор коллекции сервисов</param>
    public static void RegisterServices(Action<IServiceCollection> action)
    {
        var collection = _collection ?? CreateServiceCollection();
        action.Invoke(collection);
    }

    /// <summary>
    /// Построение поставщика сервисов
    /// </summary>
    /// <returns>Сервисы для использования из поставщика сервисов</returns>
    public static IServiceProvider Build()
    {
        _provider = (_collection ?? CreateServiceCollection()).BuildServiceProvider();
        return _provider;
    }

    /// <summary>
    /// Регистрация базовых сервисов в контейнере
    /// </summary>
    /// <param name="collection"></param>
    private static void InternalRegisterServices(IServiceCollection collection)
    {
        collection.AddSingleton<IServiceProvider>(Services);


    }
}