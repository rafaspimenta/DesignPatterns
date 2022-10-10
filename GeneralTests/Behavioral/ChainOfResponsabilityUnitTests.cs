using Behavioral.ChainOfResponsability;
using NUnit.Framework;

namespace GeneralTests.Behavioral
{
    public class ChainOfResponsabilityUnitTests
    {
        [Test]
        public void CreatureModifierTest()
        {
            var game = new Game();
            var goblin = new Creature(game, "Goblin", 2, 2);
            Assert.That(goblin.Attack, Is.EqualTo(2));
            Assert.That(goblin.Defense, Is.EqualTo(2));

            using (var da1 = new DoubleAttackModifier(game, goblin)) 
            {
                Assert.That(goblin.Attack, Is.EqualTo(4));
            }

            using (var da2 = new DoubleAttackModifier(game, goblin)) 
            { 
                Assert.That(goblin.Attack, Is.EqualTo(4));
            }

            using (var id1 = new IncreaseDefenseModifier(game, goblin)) 
            {
                Assert.That(goblin.Defense, Is.EqualTo(3));
            }
        }
    }
}
