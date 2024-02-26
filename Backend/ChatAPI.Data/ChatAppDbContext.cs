using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Data;

public class ChatAppDbContext : DbContext
{
    public ChatAppDbContext(
        DbContextOptions<ChatAppDbContext> options)
    : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}