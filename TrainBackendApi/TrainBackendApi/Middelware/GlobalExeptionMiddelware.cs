namespace TrainBackendApi.Middelware
{
    public class GlobalExeptionMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}
