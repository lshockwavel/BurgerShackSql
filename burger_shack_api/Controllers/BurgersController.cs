namespace burger_shack_api.Controllers;

[ApiController]
[Route("api/burgers")]
public class BurgersController : ControllerBase
{
    private readonly BurgersService _service;
    public BurgersController(BurgersService service)
    {
        _service = service;
    }

    [HttpGet("test")]
    public ActionResult<string> GetTest()
    {
        return Ok("🍔 test success!");
    }

    [HttpGet]
    public ActionResult<List<Burger>> GetBurgers()
    {
        try
        {
            List<Burger> burgers = _service.GetBurgers();
            return Ok(burgers);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Burger> GetBurgerById(int id)
    {
        try
        {
            Burger burger = _service.GetBurgerById(id);
            return Ok(burger);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost]
    public ActionResult<Burger> CreateBurger([FromBody] Burger burger)
    {
        try
        {
            var newBurger = _service.CreateBurger(burger);
            return Ok(newBurger);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> DeleteBurger(int id)
    {
        try
        {
            string result = _service.DeleteBurger(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Burger> UpdateBurger(int id, [FromBody] Burger update)
    {
        try
        {
            Burger burger = _service.UpdateBurger(id, update);
            return Ok(burger);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}