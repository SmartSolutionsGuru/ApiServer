using SmartSolutions.ApiServer.DataStore.Entites;

namespace SmartSolutions.ApiServer.DataStore.Repository
{
    /// <summary>
    /// Interface for Generic Repository
    /// Implement IReadOnly Repository
    /// </summary>
    public interface IRepository : IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class, IEntity;

        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        //int SaveChanges();
        void Save();
        Task SaveAsync();
    }
}
