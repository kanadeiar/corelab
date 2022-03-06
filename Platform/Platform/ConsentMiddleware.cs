using Microsoft.AspNetCore.Http.Features;

namespace Platform;

public class ConsentMiddleware
{
    private readonly RequestDelegate _next;
    public ConsentMiddleware(RequestDelegate nextDelegate)
    {
        _next = nextDelegate;
    }
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/consent")
        {
            var consentFeature = context.Features.Get<ITrackingConsentFeature>();
            if (consentFeature.HasConsent)
            {
                consentFeature.WithdrawConsent();
            }
            else
            {
                consentFeature.GrantConsent();
            }
            await context.Response.WriteAsync(consentFeature.HasConsent ? "Consent Granted" : "Consent Withdrawn");
        }
        await _next(context);
    }
}
