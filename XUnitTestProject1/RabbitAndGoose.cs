using RabbitAndGeese.Models;
using System;
using Xunit;

namespace RabbitAndGeese.Test
{
    public class SaddlingAGoose
    {
       

        [Fact]
        public void A_goose_and_Saddle_of_the_same_size_should_be_compatible()
        {
            //Arrange
            var bunny = new Rabbit();
            var emotionalState = "Pooped-filled Anger";
            var largeGoose = new Goose
            {
                Name = "Tedothy",
                Sex = Sex.Male,
                Size = Size.Large,
                EmotinalState = emotionalState
            };
            var largeSaddle = new Saddle
            {
                Size = Size.Large,
                InUse = false
            };
            bunny.OwnedSaddle.Add(largeSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            // ctrl. to create a method in Rabbit.cs
            bunny.SaddleThatGoose(largeGoose, largeSaddle);


            //Assert
           
            Assert.Same(largeSaddle, largeGoose.Saddle);
            Assert.True(largeSaddle.InUse);
            Assert.Equal(emotionalState, largeGoose.EmotinalState);
        }
        [Fact]
        public void A_goose_and_Saddle_that_are_not_same_size_should_not_be_compatible()
        {
            //Arrange
            var bunny = new Rabbit();
            var largeGoose = new Goose
            {
                Name = "Tedothy",
                Sex = Sex.Male,
                Size = Size.Large
            };
            var smallSaddle = new Saddle { Size = Size.Small, InUse = false };
            bunny.OwnedSaddle.Add(smallSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            bunny.SaddleThatGoose(largeGoose, smallSaddle);

            //Assert
            Assert.NotSame(smallSaddle, largeGoose.Saddle); // what we are not expecting, what should happen
            Assert.False(smallSaddle.InUse);
            Assert.Equal("Distraught by fat shaming", largeGoose.EmotinalState);
        }
        [Fact]
        public void A_goose_that_is_saddled_should_not_accept_another_saddle()
        {
            //Arrange
            var bunny = new Rabbit();
            var emotionalState = "Pooped-filled Anger";
            var orignalSaddle = new Saddle();
            var largeGoose = new Goose
            {
              Name = "Tedothy",
              Sex = Sex.Male,
              Size = Size.Large,
              EmotinalState = emotionalState,
              Saddle = orignalSaddle
            };
            var largeSaddle = new Saddle { Size = Size.Large, InUse = false };
            bunny.OwnedSaddle.Add(largeSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            bunny.SaddleThatGoose(largeGoose, largeSaddle);

            //Assert
           // Assert.NotEqual(largeSaddle, largeGoose.Saddle);
            Assert.Equal(orignalSaddle, largeGoose.Saddle);
            Assert.Equal("Exhausted", largeGoose.EmotinalState); // the goose should be exhausted
        }

    }
}
