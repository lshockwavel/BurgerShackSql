namespace burger_shack_api.Services;

public class BurgersService
{
    private readonly BurgersRepository _repo;
    public BurgersService(BurgersRepository repo)
    {
        _repo = repo;
    }

    public List<Burger> GetBurgers()
    {
        return _repo.GetAll();
    }

    public Burger CreateBurger(Burger burgerData)
    {
        Burger newBurger = _repo.Create(burgerData);
        return newBurger;
    }

    public string DeleteBurger(int id)
    {
        bool deleted = _repo.Delete(id);
        if (deleted)
        {
            return "Burger deleted successfully.";
        }
        throw new Exception("Failed to delete burger.");
    }

    public Burger UpdateBurger(int id, Burger update)
    {
        Burger originalBurger = _repo.GetById(id);

        originalBurger.Name = update.Name ?? originalBurger.Name;
        originalBurger.Description = update.Description ?? originalBurger.Description;
        originalBurger.Price = update.Price ?? originalBurger.Price; //REVIEW Price & IsAvailable needs to be nullable since it doesn't have null right?
        originalBurger.IsAvailable = update.IsAvailable ?? originalBurger.IsAvailable;

        return _repo.Update(id, originalBurger);
    }
}