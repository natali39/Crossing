namespace Crossing
{
    public class Passager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Food { get; set; }

        public Passager(int id, string name, string food)
        {
            Id = id;
            Name = name;
            Food = food;
        }
    }
}
