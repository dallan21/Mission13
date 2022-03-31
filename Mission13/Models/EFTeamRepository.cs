using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFTeamRepository : ITeamRepository
    {
        private BowlerDbContext _context { get; set; }

        public EFTeamRepository(BowlerDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Team> Teams => _context.Teams;
    }
}
