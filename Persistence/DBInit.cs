namespace Persistence
{
    public static class DBInit
    {
        public static void init(UserDbContext userDbContext)
        {
            userDbContext.Database.EnsureCreated();
        }
    }
}