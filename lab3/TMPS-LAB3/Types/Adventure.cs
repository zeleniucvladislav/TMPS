using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Enemies
{
    public class Adventure : IType
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public FilmType Type { get; set; }

        public Adventure(int id, string owner, FilmType type)
        {
            Id = id;
            Owner = owner;
            Type = type;
        }

        public void Create()
        {
            Console.WriteLine($"Filmul de tip {Type} cu proprietarul {Owner} a fost creat cu succes!");
        }

        public object Clone()
        {
            var copy = new Adventure(Id, Owner, Type)
            {
                Id = Id,
                Owner = Owner,
                Type = Type
            };

            return copy;
        }
    }
}
