using System;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Map
{
    public class RedBand : IRestriction
    {
        public string FilmRestriction { get; set; }
        public FilmType Type { get; set; }

        public RedBand(string filmRestriction, FilmType type)
        {
            FilmRestriction = filmRestriction;
            Type = type;
        }

        public void Apply()
        {
            Console.WriteLine($"Filmul de tip {Type} este {FilmRestriction} \n");
        }
        public object Clone()
        {
            var copy = new RedBand(FilmRestriction, Type)
            {
                FilmRestriction = FilmRestriction,
                Type = Type
            };

            return copy;
        }
    }
}
