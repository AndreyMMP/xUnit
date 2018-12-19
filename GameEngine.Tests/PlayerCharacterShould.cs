using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            // system under test
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }
        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andrey";
            sut.LastName = "Pinto";

            Assert.Equal("Andrey Pinto", sut.FullName);
        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andrey";
            sut.LastName = "Pinto";

            Assert.StartsWith("Andrey", sut.FullName);
        }
        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andrey";
            sut.LastName = "Pinto";

            Assert.EndsWith("Pinto", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "ANDREY";
            sut.LastName = "PINTO";

            Assert.Equal("Andrey Pinto", sut.FullName, ignoreCase: true);
        }
        [Fact]
        public void CalculateFullName_SubstringAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andrey";
            sut.LastName = "Pinto";

            Assert.Contains("rey Pin", sut.FullName);
        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Andrey";
            sut.LastName = "Pinto";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
    }
}
