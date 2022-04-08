using System;
using System.Linq;
using Mission13.Models.ViewModel;
using System.Threading.Tasks;


namespace Mission13.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        private BowlerDbContext _context { get; set; }

        public EFBowlerRepository (BowlerDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void SaveBowler(Bowler b)
        {
            
            _context.SaveChanges();
        }
     
        public void EditBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
