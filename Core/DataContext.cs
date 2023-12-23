using Core.Schemas;
using Core.Schemas.User;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public partial class DataContext : DbContext
    {
        public DataContext() {}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) {}

        public virtual DbSet<UserSchema> Users { get; set; }
        public virtual DbSet<RoleSchema> Roles { get; set; }
        public virtual DbSet<PermSchema> Perms { get; set; }
        public virtual DbSet<RolesPerms> RolesPerms { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<GroupFollower> GroupFollowers { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupMessage> GroupMessages { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<PostSchema> Posts { get; set; }
        public DbSet<CommentSchema> Comments { get; set; }
		public DbSet<LikeSchema> Likes { get; set; }
        public DbSet<LikeTypeSchema> LikeTypes { get; set; }
        public DbSet<MessageSchema> Messages { get; set; }
        public DbSet<MediaSchema> Medias { get; set; }
        public DbSet<NotificationSchema> Notifications { get; set; }
		public DbSet<GroupSchema> Groups { get; set; }
		public DbSet<DeviceTokenSchema> DeviceTokens { get; set; }
	}
}
