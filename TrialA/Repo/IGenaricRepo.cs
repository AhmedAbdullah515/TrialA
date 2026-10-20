namespace TrialA.Repo
{
    public interface IGenaricRepo< T> where T : class
    {
        public Task Add(T item);
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public void Delet(int id);

    }
}
