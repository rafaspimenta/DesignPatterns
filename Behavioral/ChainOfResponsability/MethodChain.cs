using System;

namespace Behavioral.ChainOfResponsability
{
    public class Creature
    {
        private readonly Game game;
        private int attack, defense;
        public Creature(Game game, string name, int attack, int defense)
        {
            this.game = game;
            Name = name;
            this.attack = attack;
            this.defense = defense;
        }

        public string Name;

        public int Attack
        {
            get 
            { 
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;
        protected CreatureModifier next;

        public CreatureModifier(Game game, Creature creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;
        }

        public void Dispose()
        {
            game.Queries -= Handle;
            GC.SuppressFinalize(this);
        }

        public abstract void Handle(object sender, Query query);
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature)
          : base(game, creature) { }
        public override void Handle(object sender, Query query)
        {
            if (query.CreatureName == creature.Name && query.WhatToQuery == Query.Argument.Attack)
            {
                Console.WriteLine($"Doubling {creature.Name}'s attack");
                query.Value *= 2;

            }
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Game game, Creature creature)
          : base(game, creature) { }
        public override void Handle(object sender, Query query)
        {
            if (query.CreatureName == creature.Name && query.WhatToQuery == Query.Argument.Defense)
            {
                if (creature.Attack <= 2)
                {
                    Console.WriteLine($"Increasing {creature.Name}'s defense");
                    query.Value++;
                }
            }
        }
    }

    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Game game, Creature creature)
          : base(game, creature) { }
        public override void Handle(object sender, Query query)
        {
            Console.WriteLine("No bonuses for you!");
            // no call to base.Handle() here
        }
    }

    public class Game // mediator pattern
    {
        public event EventHandler<Query> Queries; // effectively a chain
        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class Query
    {
        public string CreatureName;
        public enum Argument
        {
            Attack, Defense
        }
        public Argument WhatToQuery;
        public int Value; // bidirectional!

        public Query(string name, Argument argument, int value)
        {
            CreatureName = name;
            WhatToQuery = argument;
            Value = value;
        }
    }

}
