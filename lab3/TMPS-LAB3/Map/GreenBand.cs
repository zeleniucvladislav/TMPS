using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Map
{
    public class GreenBand : IRestriction
    {
        public string FilmRestriction { get; set; }
        public FilmType Type { get; set; }

        public GreenBand(string filmRestriction, FilmType type)
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
            var copy = new GreenBand(FilmRestriction, Type)
            {
                FilmRestriction = FilmRestriction,
                Type = Type
            };

            return copy;
        }
    }
}
