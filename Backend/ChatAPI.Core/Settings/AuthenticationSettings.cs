namespace ChatAPI.Core.Settings;

public record  AuthenticationSettings
{
    public string SecretKey { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string DurationInMinutes { get; set; } = default!;
}