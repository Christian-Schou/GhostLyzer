using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace GhostMetrics.Web.Infrastructure.Middleware;

public class ValidateWebhookSignatureMiddleware
{
    private readonly RequestDelegate _next;

    public ValidateWebhookSignatureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ValidateWebhookSignatureMiddleware> logger)
    {
        // Check if the signature header is present
        if (!context.Request.Headers.TryGetValue("x-ghost-signature", out var signatureHeader))
        {
            throw new UnauthorizedAccessException("Missing x-ghost-signature in header");
        }
        
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();
        
        // Check if the body contains valid JSON
        try
        {
            JsonDocument.Parse(body);
        }
        catch (JsonException)
        {
            throw new BadHttpRequestException("The body doesn't contain valid JSON");
        }
        
        // Retrieve the secret from the database
        const string secret = "helloSecretValue";
        
        // Compute a signature from the body and the secret
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        var computedSignature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(body)));

        if (signatureHeader != computedSignature)
        {
            throw new BadHttpRequestException("The webhook signature is invalid");
        }

        await _next(context);
    }
}