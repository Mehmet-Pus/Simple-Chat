using ChatAPI.Data.Models;
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
        modelBuilder.Entity<Message>()
            .Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(500);
        modelBuilder.Entity<Message>()
            .Property(x => x.SenderId)
            .IsRequired();
        modelBuilder.Entity<Message>()
            .Property(x => x.ChatRoomId)
            .IsRequired();
        modelBuilder.Entity<Message>()
            .HasMany<ChatRoom>(x => x.ChatRooms)
            .WithMany(x => x.Messages);

        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.ChatRoomId)
            .IsRequired();
        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.UserId)
            .IsRequired();
        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.Description)
            .IsRequired();
        modelBuilder.Entity<ChatRoomUser>()
            .HasMany<ChatRoom>(x => x.ChatRooms)
            .WithMany(x => x.ChatRoomUsers);

        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.Name)
            .IsRequired();
        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.IsPrivateChat);
        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.IsOneToOneChat);
        modelBuilder.Entity<ChatRoom>()
            .HasMany<ChatRoomUser>(x => x.ChatRoomUsers)
            .WithMany(x => x.ChatRooms);
            
        base.OnModelCreating(modelBuilder);
    }
}