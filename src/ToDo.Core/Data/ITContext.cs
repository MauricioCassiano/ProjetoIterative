using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Reflection;
using System.Text;

namespace ToDo.Core.Data
{
    public class ITContext :DbContext
    {
        #region Construtores

        public ITContext()
            : this("name=ITContext")
        { }

        public ITContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Sobrescrita

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }

        #endregion

        #region Classes Internas

        internal sealed class EFDbInitializer : CreateDatabaseIfNotExists<ITContext>
        {
            protected override void Seed(ITContext context)
            {
                base.Seed(context);
            }
        }

        internal sealed class EFDbConfiguration : DbConfiguration
        {
            #region Construtores

            public EFDbConfiguration()
                : this(new EFDbInitializer())
            { }

            public EFDbConfiguration(IDatabaseInitializer<ITContext> dbInitializer)
            {
                this.SetDatabaseInitializer<ITContext>(dbInitializer);
            }

            #endregion
        }

        #endregion
    }
}
