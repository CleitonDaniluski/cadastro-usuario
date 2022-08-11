namespace UsuarioCadastro.Middleware
{
    public class LogMiddleWare
    {
        private readonly RequestDelegate _next;

        public LogMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var url = httpContext.Request.Path;
            Console.WriteLine(url);

            await _next(httpContext);
        }        
    }
}
