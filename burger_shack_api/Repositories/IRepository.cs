namespace burger_shack_api.Repositories;

public interface IRepository<T>
{
    List<T> GetAll(); //REVIEW: Originally it was IEnumerable<T>, is that ok I switch to IEnumerable?
    T GetById(int id);
    T Create(T data);
    bool Delete(int id);
    T Update(int id, T updateData);
}