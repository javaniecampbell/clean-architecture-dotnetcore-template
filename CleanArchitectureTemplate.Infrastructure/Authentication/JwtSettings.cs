namespace CleanArchitectureTemplate.Infrastructure.Authentication;

public class JwtSettings{

    public const string SectionName = nameof(JwtSettings);
    public string? Secret { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public int ExpirationInMinutes { get; set; }
}