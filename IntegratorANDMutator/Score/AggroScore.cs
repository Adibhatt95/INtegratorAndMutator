﻿using System;
using System.Collections.Generic;
using System.Linq;
using SabberStoneCore.Model.Zones;
using SabberStoneCore.Model.Entities;

namespace IntegratorANDMutator.Score
{
    public class AggroScore : IntegratorANDMutator.Score.Score
    {
        public override int Rate()
        {
            if (OpHeroHp < 1)
                return int.MaxValue;

            if (HeroHp < 1)
                return int.MinValue;

            int result = 0;

            if (OpBoardZone.Count == 0 && BoardZone.Count > 0)
                result += 1000;

            if (OpMinionTotHealthTaunt > 0)
                result += OpMinionTotHealthTaunt * -1000;

            result += MinionTotAtk;

            result += (HeroHp - OpHeroHp) * 1000;

            return result;
        }

        public override Func<List<IPlayable>, List<int>> MulliganRule()
        {
            return p => p.Where(t => t.Cost > 3).Select(t => t.Id).ToList();
        }
    }
}
