namespace burger_shack_api.Models;
    public class Burger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
    }