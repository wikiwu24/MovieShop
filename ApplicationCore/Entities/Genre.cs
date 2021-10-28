using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string  Name { get; set; }
        //Navigation Property
        public ICollection<MovieGenre> Movies { get; set; }
    }
}
