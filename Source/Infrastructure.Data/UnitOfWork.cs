using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using MundiPagg.Benfeitor.Infrastructure.Data.Mappings;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data {

    public class UnitOfWork : DbContext, IQueryableUnitOfWork {

        public UnitOfWork() : base("sql:ConnectionString") {

            Database.SetInitializer<UnitOfWork>(null);

            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = true;
        }

        public static void Initialize() {
            using (var context = new UnitOfWork()) {
                context.Database.Initialize(false);
            }
        }

        public void Log(string query) {
            Console.WriteLine(query);
        }

        #region IQueryableUnitOfWork Members

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class {
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public void Detach<TEntity>(TEntity item) where TEntity : class {
            base.Entry<TEntity>(item).State = EntityState.Detached;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class {
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit() {
            try {
                base.SaveChanges();
            } catch (DbEntityValidationException e) {
                throw e;
            }
        }

        public void Rollback() {
            base.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters) {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            //Remove unused conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Add entity configurations in a structured way using 'TypeConfiguration’ classes
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new DocumentMapping());
            modelBuilder.Configurations.Add(new LoanMapping());
            modelBuilder.Configurations.Add(new ChargeMapping());
        }

        #endregion
    }
}
