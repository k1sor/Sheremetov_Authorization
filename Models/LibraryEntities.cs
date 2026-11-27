using System.Data.Entity;

namespace Sheremetov_Authorization.Models
{
    public class LibraryEntities : DbContext
    {
        private static LibraryEntities _context;

        static LibraryEntities()
        {
            Database.SetInitializer<LibraryEntities>(null);
        }

        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        /// <summary>
        /// Метод для получения контекста данных, необходимого для подключения к базе данных.
        /// </summary>
        /// <returns>Контекст данных типа LibraryEntities.</returns>
        public static LibraryEntities GetContext()
        {
            if (_context == null)
            {
                _context = new LibraryEntities();
            }
            return _context;
        }
    }
}
