using System;
using System.ComponentModel.DataAnnotations;

namespace Mission13.Models
{
    //this is a sinlge instane of a bowler then we will use a list or Iqueryable to get multiple instances 
    public class Bowler
    {
        //if you just have a get, then it is read only
        [Key]
        [Required]
        public int BowlerId { get; set; }

        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }

        public string BowlerLastName { get; set; }

        public string BowlerAddress { get; set; }

        public string BowlerCity { get; set; }

        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
