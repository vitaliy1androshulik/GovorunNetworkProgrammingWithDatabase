using Microsoft.EntityFrameworkCore;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Helpers
{
    public static class DBInitializer
    {
        public static void SeedAnswers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(new Answer[]
            {
                new Answer
                {
                    Id = 1,
                    Phrase = "Hello",
                    AnswerToPhrase = "Hello!"
                },
                new Answer
                {
                    Id = 2,
                    Phrase = "How are you?",
                    AnswerToPhrase = "I`m good, you?"
                },
                new Answer
                {
                    Id = 3,
                    Phrase = "Goodbye",
                    AnswerToPhrase = "See you soon!"
                },
                new Answer
                {
                    Id = 4,
                    Phrase = "Your favourite dish?",
                    AnswerToPhrase = "Pizza)"
                }
            });
        }
    }
}
