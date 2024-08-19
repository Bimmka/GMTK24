using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Gameplay.Features.CharacterStats
{
    public static class InitStats
    {
        public static Dictionary<Stats, float> EmptyRabbitStatDictionary()
        {
            return Enum.GetValues(typeof(Stats))
                .Cast<Stats>()
                .Except(new[] {Stats.Unknown, Stats.HuntDuration, Stats.RabbitToGetEnough, Stats.BeforeNextHuntInterval})
                .ToDictionary(x => x, _ => 0f);
        }
        
        public static Dictionary<Stats, float> EmptyFoxStatDictionary()
        {
            return Enum.GetValues(typeof(Stats))
                .Cast<Stats>()
                .Except(new[] {Stats.Unknown, Stats.ReplicationDuration})
                .ToDictionary(x => x, _ => 0f);
        }
    }
}