using System;
using System.Linq;
using Mission13.Models.ViewModel;

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
            _context.Update(b);
            _context.SaveChanges();
        }
       

        public void AddBowler(BowlerViewModel b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }
        

        public void DeleteBowler(BowlerViewModel b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
