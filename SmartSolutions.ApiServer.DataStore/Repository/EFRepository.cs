using Microsoft.EntityFrameworkCore;
using SmartSolutions.ApiServer.DataStore.Entites;

namespace SmartSolutions.ApiServer.DataStore.Repository
{
    public class EFRepository<TContext> : EFReadOnlyRepository<TContext>, IRepository
     where TContext : DbContext
    {
        public EFRepository(TContext context)
            : base(context)
        {
        }

        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = createdBy;
            context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdatedBy = modifiedBy;
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class, IEntity
        {
            TEntity entity = context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            var dbSet = context.Set<TEntity>();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                //ThrowEnhancedValidationException(e);
                e.ToString();
            }
        }
        public virtual Task SaveAsync()
        {
            try
            {
                return context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                //ThrowEnhancedValidationException(e);
                e.ToString();
            }

            return Task.FromResult(0);
        }

        //protected virtual void ThrowEnhancedValidationException(Exception e)
        //{
        //    var errorMessages = e.EntityValidationErrors
        //            .SelectMany(x => x.ValidationErrors)
        //            .Select(x => x.ErrorMessage);

        //    var fullErrorMessage = string.Join("; ", errorMessages);
        //    var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
        //    throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        //}
    }
}
