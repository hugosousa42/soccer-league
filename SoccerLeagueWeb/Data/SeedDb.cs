using SoccerLeagueLibrary.Data.Entities;

namespace SoccerLeagueWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Clubs.Any())
            {
                AddClubs();
                await _context.SaveChangesAsync();           
            }
            else
            {
                Console.WriteLine("Clubs are already seeded in the database.");
            }
        }

        private void AddClubs( )
        {
            var clubs = new[]
            {
                new Club { Name = "Benfica", Location = "Lisboa", Founded = new DateTime(1904, 2, 28) },
                new Club { Name = "Porto", Location = "Porto", Founded = new DateTime(1893, 9, 28) },
                new Club { Name = "Sporting", Location = "Lisboa", Founded = new DateTime(1906, 7, 1) },
                new Club { Name = "Braga", Location = "Braga", Founded = new DateTime(1921, 1, 19) },
                new Club { Name = "Vitória de Guimarães", Location = "Guimarães", Founded = new DateTime(1922, 9, 22) },
                new Club { Name = "Famalicão", Location = "Famalicão", Founded = new DateTime(1931, 8, 21) },
                new Club { Name = "Boavista", Location = "Porto", Founded = new DateTime(1903, 8, 1) },
                new Club { Name = "Rio Ave", Location = "Vila do Conde", Founded = new DateTime(1939, 5, 10) },
                new Club { Name = "Vizela", Location = "Vizela", Founded = new DateTime(1939, 1, 1) },
                new Club { Name = "Estoril", Location = "Estoril", Founded = new DateTime(1939, 5, 17) },
                new Club { Name = "Gil Vicente", Location = "Barcelos", Founded = new DateTime(1924, 5, 3) },
                new Club { Name = "Chaves", Location = "Chaves", Founded = new DateTime(1949, 9, 27) },
                new Club { Name = "Arouca", Location = "Arouca", Founded = new DateTime(1951, 12, 25) },
                new Club { Name = "Casa Pia", Location = "Lisboa", Founded = new DateTime(1920, 7, 3) },
                new Club { Name = "Portimonense", Location = "Portimão", Founded = new DateTime(1914, 8, 14) },
                new Club { Name = "Moreirense", Location = "Moreira de Cónegos", Founded = new DateTime(1938, 11, 1) },
                new Club { Name = "Farense", Location = "Faro", Founded = new DateTime(1910, 4, 1) },
                new Club { Name = "Estrela da Amadora", Location = "Amadora", Founded = new DateTime(1932, 1, 22) }
            };

            foreach (var club in clubs)
            {
                _context.Clubs.Add(club);           
            }           
        }
    }
}


