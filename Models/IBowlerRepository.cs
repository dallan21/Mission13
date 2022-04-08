using System;
using System.Linq;
using Mission13.Models.ViewModel;

namespace Mission13.Models
{
    public interface IBowlerRepository
    {
       IQueryable<Bowler> Bowlers { get; }

        public void SaveBowler(Bowler b);


        public void AddBowler(BowlerViewModel b);

        public void DeleteBowler(BowlerViewModel b);
    }
}
