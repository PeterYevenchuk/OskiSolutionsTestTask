using Microsoft.EntityFrameworkCore;
using OskiFSPY.Core.Answers;
using OskiFSPY.Core.Questions;
using OskiFSPY.Core.Tests;
using OskiFSPY.Core.Users;
using OskiFSPY.Core.UsersTestsStatuses;

namespace OskiFSPY.Core.Context.Seeds;

public static class TestDataSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Test>().HasData(
            new Test { TestId = 1, Name = "Sun", Passed = false, UserId = 1, Description = "How well you know our sun?" },
            new Test { TestId = 2, Name = "Sun", Passed = true, UserId = 2, Description = "How well you know our sun?" },
            new Test { TestId = 3, Name = "Moon", Passed = true, UserId = 1, Description = "How well you know the moon?" },
            new Test { TestId = 4, Name = "Moon", Passed = false, UserId = 2, Description = "How well you know the moon?" }
        );

        modelBuilder.Entity<Question>().HasData(
            new Question { QuestionId = 1, QuestionText = "What size is the sun?", Points = 5, TestId = 1 },
            new Question { QuestionId = 2, QuestionText = "What is the temperature of the sun?", Points = 5, TestId = 1 },
            new Question { QuestionId = 3, QuestionText = "How far is the sun from the earth?", Points = 5, TestId = 1 },
            new Question { QuestionId = 4, QuestionText = "What size is the sun?", Points = 5, TestId = 2 },
            new Question { QuestionId = 5, QuestionText = "What is the temperature of the sun?", Points = 5, TestId = 2 },
            new Question { QuestionId = 6, QuestionText = "How far is the sun from the earth?", Points = 5, TestId = 2 },
            new Question { QuestionId = 7, QuestionText = "What size is the moon?", Points = 5, TestId = 3 },
            new Question { QuestionId = 8, QuestionText = "What is the temperature of the moon?", Points = 5, TestId = 3 },
            new Question { QuestionId = 9, QuestionText = "How far is the moon from the earth?", Points = 5, TestId = 3 },
            new Question { QuestionId = 10, QuestionText = "What size is the moon?", Points = 5, TestId = 4 },
            new Question { QuestionId = 11, QuestionText = "What is the temperature of the moon?", Points = 5, TestId = 4 },
            new Question { QuestionId = 12, QuestionText = "How far is the moon from the earth?", Points = 5, TestId = 4 }
        );

        modelBuilder.Entity<Answer>().HasData(
            new Answer { AnswerId = 1, AnswerText = "The radius of the Sun is 696,342 km, and its diameter is 1,392,684 km.", RightAnswer = true, QuestionId = 1 },
            new Answer { AnswerId = 2, AnswerText = "The radius of the Sun is 596,342 km, and its diameter is 1,192,684 km.", RightAnswer = false, QuestionId = 1 },
            new Answer { AnswerId = 3, AnswerText = "The photosphere is 6000 degrees Celsius.", RightAnswer = true, QuestionId = 2 },
            new Answer { AnswerId = 4, AnswerText = "The photosphere is 10000 degrees Celsius.", RightAnswer = false, QuestionId = 2 },
            new Answer { AnswerId = 5, AnswerText = "289.6 million kilometers.", RightAnswer = false, QuestionId = 3 },
            new Answer { AnswerId = 6, AnswerText = "149.6 million kilometers.", RightAnswer = true, QuestionId = 3 },
            new Answer { AnswerId = 7, AnswerText = "The radius of the Sun is 696,342 km, and its diameter is 1,392,684 km.", RightAnswer = true, QuestionId = 4 },
            new Answer { AnswerId = 8, AnswerText = "The radius of the Sun is 596,342 km, and its diameter is 1,192,684 km.", RightAnswer = false, QuestionId = 4 },
            new Answer { AnswerId = 9, AnswerText = "The photosphere is 6000 degrees Celsius.", RightAnswer = true, QuestionId = 5 },
            new Answer { AnswerId = 10, AnswerText = "The photosphere is 10000 degrees Celsius.", RightAnswer = false, QuestionId =5 },
            new Answer { AnswerId = 11, AnswerText = "289.6 million kilometers.", RightAnswer = false, QuestionId = 6 },
            new Answer { AnswerId = 12, AnswerText = "149.6 million kilometers.", RightAnswer = true, QuestionId = 6 },
            new Answer { AnswerId = 13, AnswerText = "The radius of the Moon is 1,737.4 km, and its diameter is 3,474.8 km.", RightAnswer = true, QuestionId = 7 },
            new Answer { AnswerId = 14, AnswerText = "The radius of the Moon is 1,337.4 km, and its diameter is 2,674.8 km.", RightAnswer = false, QuestionId = 7 },
            new Answer { AnswerId = 15, AnswerText = "The average temperature of the Moon's surface is about -233 degrees Celsius.", RightAnswer = true, QuestionId = 8 },
            new Answer { AnswerId = 16, AnswerText = "The average temperature of the Moon's surface is about 123 degrees Celsius.", RightAnswer = false, QuestionId = 8 },
            new Answer { AnswerId = 17, AnswerText = "The average distance from the Earth to the Moon is about 384,400 kilometers.", RightAnswer = true, QuestionId = 9 },
            new Answer { AnswerId = 18, AnswerText = "The average distance from the Earth to the Moon is about 84,400 kilometers.", RightAnswer = false, QuestionId = 9 },
            new Answer { AnswerId = 19, AnswerText = "The radius of the Moon is 1,737.4 km, and its diameter is 3,474.8 km.", RightAnswer = true, QuestionId = 10 },
            new Answer { AnswerId = 20, AnswerText = "The radius of the Moon is 1,337.4 km, and its diameter is 2,674.8 km.", RightAnswer = false, QuestionId = 10 },
            new Answer { AnswerId = 21, AnswerText = "The average temperature of the Moon's surface is about -233 degrees Celsius.", RightAnswer = true, QuestionId = 11 },
            new Answer { AnswerId = 22, AnswerText = "The average temperature of the Moon's surface is about 123 degrees Celsius.", RightAnswer = false, QuestionId = 11 },
            new Answer { AnswerId = 23, AnswerText = "The average distance from the Earth to the Moon is about 384,400 kilometers.", RightAnswer = true, QuestionId = 12 },
            new Answer { AnswerId = 24, AnswerText = "The average distance from the Earth to the Moon is about 84,400 kilometers.", RightAnswer = false, QuestionId = 12 }
        );

        // Hashed password for Sanchez: KiXXDOMi5akuNUje3XuJbQZ/lphdVD3McMkuEvoUJSw= = password non hashed user1user1
        // Hashed password for Simpson: txTsTxszRvb3SppozpXvwc5ac1NaRBsGTCyIt/Zrqxo= = password non hashed user2user2
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Bart", Surname = "Simpson", Email = "simpson@example.com", Password = "KiXXDOMi5akuNUje3XuJbQZ/lphdVD3McMkuEvoUJSw=", Role = Role.User, Salt = "VSNO6dFWojmgIOtB91byvw==" },
            new User { UserId = 2, Name = "Rick", Surname = "Sanchez", Email = "sanchez@example.com", Password = "txTsTxszRvb3SppozpXvwc5ac1NaRBsGTCyIt/Zrqxo=", Role = Role.User, Salt = "kk4M9Ee0OMMTrcFaHNPfag==" }
        );

        modelBuilder.Entity<UserTestStatus>().HasData(
            new UserTestStatus { UserTestStatusId = 1, Rating = 15, TestId = 2 },
            new UserTestStatus { UserTestStatusId = 2, Rating = 10, TestId = 3 }
        );
    }
}
