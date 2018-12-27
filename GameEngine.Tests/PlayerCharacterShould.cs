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
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Andrey",
                LastName = "Pinto"
            };

            Assert.Equal("Andrey Pinto", sut.FullName);
        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Andrey",
                LastName = "Pinto"
            };

            Assert.StartsWith("Andrey", sut.FullName);
        }
        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Andrey",
                LastName = "Pinto"
            };

            Assert.EndsWith("Pinto", sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "ANDREY",
                LastName = "PINTO"
            };

            Assert.Equal("Andrey Pinto", sut.FullName, ignoreCase: true);
        }
        [Fact(Skip = "Não é necessário executar pois foi somente teste de funcionalidade do xUnit")]
        public void CalculateFullName_SubstringAssert()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Andrey",
                LastName = "Pinto"
            };

            Assert.Contains("rey Pin", sut.FullName);
        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter
            {
                FirstName = "Andrey",
                LastName = "Pinto"
            };

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotEqualAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }
        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            Assert.InRange(sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNicknameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }
        [Fact]
        public void HaveLongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }
        [Fact]
        public void NotHaveStaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }
        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }
        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }
    }
}
