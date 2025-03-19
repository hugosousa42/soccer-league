using SoccerLeagueLibrary.Data.Entities;

namespace SoccerLeagueWeb.Data.Repositories
{
    public class PlayerRepository : GenericRepository<Player> , IPlayerRepository
    {
        private readonly DataContext _context;
        public PlayerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
