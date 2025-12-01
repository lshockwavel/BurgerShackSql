
namespace burger_shack_api.Repositories;
public class BurgersRepository : IRepository<Burger>
{
    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
        _db = db;
    }

    public List<Burger> GetAll()
    {
        string sql = "SELECT * FROM burgers;";
        return _db.Query<Burger>(sql).ToList();
    }

    public Burger GetById(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @id;";
        return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public Burger Create(Burger burgerData)
    {
        string sql = @"
        INSERT INTO burgers (name, description, price)
        VALUES (@Name, @Description, @Price);
        SELECT * FROM burgers WHERE id = LAST_INSERT_ID();";

        Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault(); //REVIEW We use Query here but execute in Delete? Why not ExecuteScalar?
        return burger;
    }

    public bool Delete(int id)
    {
        string sql = "DELETE FROM burgers WHERE id = @id LIMIT 1;";
        int affectedRows = _db.Execute(sql, new { id });
        

        if(affectedRows != 1)
        {
            throw new Exception("No burger found with the provided ID.");
        }

        return affectedRows > 0;
    }

    public Burger Update(int burgerId, Burger burger)
    {
        string sql = @"
        UPDATE burgers
        SET
            name = @Name,
            description = @Description,
            price = @Price,
            isAvailable = @IsAvailable
        WHERE id = @BurgerId;
        SELECT * FROM burgers WHERE id = @BurgerId;";

        int rowsAffected = _db.Execute(sql, new { BurgerId = burgerId, burger.Name, burger.Description, burger.Price, burger.IsAvailable }); //REVIEW Is there a better way to do this?
        if (rowsAffected != 1)
        {
            throw new Exception( rowsAffected + " rows were affected, expected 1.");
        }
        return burger;
    }
}