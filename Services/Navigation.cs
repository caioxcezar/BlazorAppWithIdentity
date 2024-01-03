using Microsoft.AspNetCore.Authentication;

namespace BlazorAppWithIdentity.Services;

public static class Navigation
{
    public static void NavigateFromPost(string url)
    {
        var context = new HttpContextAccessor();
        if (context.HttpContext == null) throw new Exception("HttpContext not found. ");
        context.HttpContext.Response.Redirect(url, true);
    }

    public static async Task Challenge(string provider, AuthenticationProperties properties)
    {
        var context = new HttpContextAccessor();
        if (context.HttpContext == null) throw new Exception("HttpContext not found. ");
        await context.HttpContext.ChallengeAsync(provider, properties);
    }
}
