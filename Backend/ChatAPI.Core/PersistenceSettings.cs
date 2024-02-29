namespace ChatAPI.Core;

public record PersistenceSettings
{
    public string ConnectionStringTemplate { get; set; } = default!;
    public string Host { get; set; } = default!;
    public string Database { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;

    public string GetConnectionString()
    {
        if (ConnectionStringTemplate == null)
            throw new ArgumentException($"{nameof(PersistenceSettings)} {nameof(ConnectionStringTemplate)} cannot be null");

        var connectionString = ConnectionStringTemplate
            .Replace("{host}", Host, StringComparison.OrdinalIgnoreCase)
            .Replace("{database}", Database, StringComparison.OrdinalIgnoreCase)
            .Replace("{username}", Username, StringComparison.OrdinalIgnoreCase)
            .Replace("{password}", Password, StringComparison.OrdinalIgnoreCase);

        return connectionString;
    }
}