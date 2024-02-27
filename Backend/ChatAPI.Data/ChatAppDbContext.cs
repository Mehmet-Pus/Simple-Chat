using ChatAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Data;

public class ChatAppDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
    public ChatAppDbContext(
        DbContextOptions<ChatAppDbContext> options, DbSet<Message> messages, DbSet<ChatRoom> chatRooms, DbSet<ChatRoomUser> chatRoomUsers)
    : base(options)
    {
        Messages = messages;
        ChatRooms = chatRooms;
        ChatRoomUsers = chatRoomUsers;
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
            .HasOne<ChatRoom>(x => x.ChatRoom)
            .WithMany(x => x.Messages);

        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.ChatRoomId)
            .IsRequired();
        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.UserId)
            .IsRequired();
        modelBuilder.Entity<ChatRoomUser>()
            .Property(x => x.Description)
            .HasMaxLength(20);
        modelBuilder.Entity<ChatRoomUser>()
            .HasOne<ChatRoom>(x => x.ChatRoom)
            .WithMany(x => x.ChatRoomUsers);

        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();
        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.IsPrivateChat);
        modelBuilder.Entity<ChatRoom>()
            .Property(x => x.IsOneToOneChat);
        modelBuilder.Entity<ChatRoom>()
            .HasMany<ChatRoomUser>(x => x.ChatRoomUsers);
            //.WithMany(x => x.User Sender will be implemented later);
            
        base.OnModelCreating(modelBuilder);
    }
}