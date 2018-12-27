using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut; // system under test
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Criando um novo Player Character");

            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            _output.WriteLine($"Fazendo dispose de Player Character {_sut.FullName}");

            //_sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }
        [Fact]
        public void CalculateFullName()
        {
            _sut.FirstName = "Andrey";
            _sut.LastName = "Pinto";

            Assert.Equal("Andrey Pinto", _sut.FullName);
        }
        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _sut.FirstName = "Andrey";
            _sut.LastName = "Pinto";

            Assert.StartsWith("Andrey", _sut.FullName);
        }
        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Andrey";
            _sut.LastName = "Pinto";

            Assert.EndsWith("Pinto", _sut.FullName);
        }
        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            _sut.FirstName = "ANDREY";
            _sut.LastName = "PINTO";

            Assert.Equal("Andrey Pinto", _sut.FullName, ignoreCase: true);
        }
        [Fact]
        public void CalculateFullName_SubstringAssert()
        {
            _sut.FirstName = "Andrey";
            _sut.LastName = "Pinto";

            Assert.Contains("rey Pin", _sut.FullName);
        }
        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Andrey";
            _sut.LastName = "Pinto";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }
        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }
        [Fact]
        public void StartWithDefaultHealth_NotEqualAssert()
        {
            Assert.NotEqual(0, _sut.Health);
        }
        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();

            Assert.InRange(_sut.Health, 101, 200);
        }
        [Fact]
        public void NotHaveNicknameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }
        [Fact]
        public void HaveLongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }
        [Fact]
        public void NotHaveStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }
        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }
        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }
    }
}
