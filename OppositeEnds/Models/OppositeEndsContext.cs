using System.Data.Entity;

namespace OppositeEnds.Models
{
    public class OppositeEndsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OppositeEndsContext() : base("name=OppositeEndsContext")
        {
        }

        public System.Data.Entity.DbSet<OppositeEnds.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<OppositeEnds.Models.Floral> Florals { get; set; }

        public System.Data.Entity.DbSet<OppositeEnds.Models.Furniture> furnitures { get; set; }
    }
}
