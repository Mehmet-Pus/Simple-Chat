namespace ChatAPI.Core;

public record  AuthenticationSettings
{
    public string JwtTemplate { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string DurationInMinutes { get; set; } = default!;

    public string GetJwtSetting()
    {
        if (JwtTemplate == null)
            throw new ArgumentException($"{nameof(AuthenticationSettings)} {nameof(JwtTemplate)} cannot be null");

        var jwtTemplate = JwtTemplate
            .Replace("{secretKey}", SecretKey, StringComparison.OrdinalIgnoreCase)
            .Replace("{issuer}", Issuer, StringComparison.OrdinalIgnoreCase)
            .Replace("{audience}", Audience, StringComparison.OrdinalIgnoreCase)
            .Replace("{durationinminutes}", DurationInMinutes, StringComparison.OrdinalIgnoreCase);

        return jwtTemplate;
    }
}