namespace Platform.Services;

public static class EndpointExtensions
{
    public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
    {
        var methodInfo = typeof(T).GetMethod(methodName);
        if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
        {
            throw new Exception("Method cannot be used");
        }
        T instance = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);
        var methodParams = methodInfo.GetParameters();
        //app.MapGet(path, (RequestDelegate)methodInfo.CreateDelegate(typeof(RequestDelegate), instance));
        app.MapGet(path, context =>
        {
            T instance = ActivatorUtilities.CreateInstance<T>(context.RequestServices);
            return (Task)methodInfo.Invoke(instance, methodParams.Select(p => p.ParameterType == typeof(HttpContent)
            ? context
            : context.RequestServices.GetService(p.ParameterType)).ToArray())!;
        });
        
        //(Task)methodInfo.Invoke(instance,
        //    methodParams.Select(p => p.ParameterType == typeof(HttpContent)
        //    ? context
        //    : context.RequestServices.GetService(p.ParameterType)).ToArray())!);
            //: app.ServiceProvider.GetService(p.ParameterType)).ToArray())!);
    }
}
