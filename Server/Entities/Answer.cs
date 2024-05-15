using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Answer
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string? Phrase { get; set; }
        [Required, MaxLength(250), Column("Answer")]
        public string? AnswerToPhrase { get; set; }     
    }
}
