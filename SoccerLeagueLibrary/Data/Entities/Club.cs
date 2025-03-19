namespace SoccerLeagueLibrary.Data.Entities
{
    public class Club : IEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public DateTime Founded { get; set; }
    }
}
