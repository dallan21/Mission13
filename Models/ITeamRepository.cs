using System;
using System.Linq;

namespace Mission13.Models
{
    public interface ITeamRepository
    {
       
            IQueryable<Team> Teams { get; }

           
    }
}
