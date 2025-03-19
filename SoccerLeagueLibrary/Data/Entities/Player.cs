namespace SoccerLeagueLibrary.Data.Entities
{
    public class Player : IEntity
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Position { get; set; }

        public int JerseyNumber { get; set; }

        public bool IsInjured { get; set; }
    }
}
