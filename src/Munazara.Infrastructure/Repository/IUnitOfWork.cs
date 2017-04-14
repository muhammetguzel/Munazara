namespace Munazara.Data.Repository
{
    public interface IUnitOfWork
    {
        void Dispose();

        IGenericRepository<T> Repository<T>() where T : class;

        void SaveChanges();
    }
}