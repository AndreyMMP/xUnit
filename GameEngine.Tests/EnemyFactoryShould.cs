using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }
        [Fact]
        public void CreateBossEnemy_CastReturnedTypeAssert()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }
        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }
        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }
    }
}
