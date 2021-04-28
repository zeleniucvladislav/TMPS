﻿using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Enemies;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Map;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Factories
{
    class Level2Factory : ILevelFactory
    {
        public IType CreateFilmType(string owner, int id, FilmType type)
        {
            return new Adventure(id, owner, type);
        }

        public IRestriction CreateRestriction(string protectionType, FilmType type)
        {
            return new GreenBand(protectionType, type);
        }
    }
}
