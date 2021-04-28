using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    interface ILevelFactory
    {
        IRestriction CreateRestriction(string filmRestriction, FilmType type);
        IType CreateFilmType(string owner, int id, FilmType type);
    }
}
