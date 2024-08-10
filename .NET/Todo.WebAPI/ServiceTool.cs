namespace Todo.WebAPI;

public static class ServiceTool
{
    public static ServiceProvider ServiceProvider { get; set; }

    public static IServiceCollection AddServiceTool(this IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}