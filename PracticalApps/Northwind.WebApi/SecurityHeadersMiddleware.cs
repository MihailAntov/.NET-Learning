using Microsoft.Extensions.Primitives;

public class SecurityHeaders
{
    private readonly RequestDelegate next;
    public SecurityHeaders(RequestDelegate next)
    {
        this.next = next;
    }

    public Task Invoke(HttpContext context)
    {
        //add any http response headers you want here
        context.Response.Headers.Add(
            "super-secure", new StringValues("enable")
        );
        return next(context);
    }
}