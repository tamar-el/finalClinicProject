namespace clinicProject.Middlewares
{
    public static class ClinicMiddlewareExtensions
    {
        public static IApplicationBuilder UseClinic(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClinicMiddleware>();
        }
    }
}
