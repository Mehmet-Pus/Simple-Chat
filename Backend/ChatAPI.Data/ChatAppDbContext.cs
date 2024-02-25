using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ChatAPI.Data;
using Microsoft.EntityFrameworkCore;

public class ChatAppDbContext : DbContext
{
    public ChatAppDbContext()
    {
        
    }

    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}