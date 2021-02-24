namespace Crossing
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Food { get; set; }

        public Passenger(int id, string name, string food)
        {
            Id = id;
            Name = name;
            Food = food;
        }
    }
}
