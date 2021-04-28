using System;
using TMPS_LAB3.Factories;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            string name;
            string choice;
            Console.Clear();
            Console.WriteLine($"1) Creati un film de tip {FilmType.Horror}");
            Console.WriteLine($"2) Creati un film de tip {FilmType.Adventure}");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: \n");

            switch (Console.ReadLine())
            {
                case "1":
                    ILevelFactory filmHorror = new Level1Factory();

                    Console.WriteLine("\nIntroduceti compania filmului :");

                    name = Console.ReadLine();

                    IType typeHorror = filmHorror.CreateFilmType(name, 1, FilmType.Horror);
                    IRestriction restrictionHorror = filmHorror.CreateRestriction("restrictat minorilor", FilmType.Horror);

                    typeHorror.Create();
                    restrictionHorror.Apply();

                    Console.WriteLine("Doriti sa mai creati un film de acelasi tip? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nIntroduceti compania filmului :");

                        name = Console.ReadLine();

                        var type2 = (IType)typeHorror.Clone();
                        type2 = filmHorror.CreateFilmType(name, 2, FilmType.Horror);
                        var restriction2 = (IRestriction)restrictionHorror.Clone();
                        restriction2 = filmHorror.CreateRestriction("restrictat minorilor", FilmType.Horror);
                        type2.Create();
                        restriction2.Apply();
                    }

                    Console.WriteLine("Doriti sa creati alt film ? yes / no \n");
                    choice = Console.ReadLine();

                    var returnChoice1 = choice.ToLower() == "yes" ? true : false;

                    return returnChoice1;

                case "2":
                    ILevelFactory filmAdventure = new Level2Factory();

                    Console.WriteLine("\nIntroduceti compania filmului :");

                    name = Console.ReadLine();

                    IType typeAdventure = filmAdventure.CreateFilmType(name, 1, FilmType.Adventure);
                    IRestriction restrictionAdventure = filmAdventure.CreateRestriction("permis persoanelor cu orice vârstă", FilmType.Adventure);

                    typeAdventure.Create();
                    restrictionAdventure.Apply();

                    Console.WriteLine("Doriti sa mai creati un film de acelasi tip? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nIntroduceti compania filmului :");

                        name = Console.ReadLine();

                        var type2 = (IType)typeAdventure.Clone();
                        type2 = filmAdventure.CreateFilmType(name, 2, FilmType.Adventure);
                        var protection2 = (IRestriction)restrictionAdventure.Clone();
                        protection2 = filmAdventure.CreateRestriction("permis persoanelor cu orice vârstă", FilmType.Adventure);
                        type2.Create();
                        protection2.Apply();
                    }

                    Console.WriteLine("Doriti sa creati alt film ? yes / no \n");
                    choice = Console.ReadLine();


                    var returnChoice2 = choice.ToLower() == "yes" ? true : false;
                    return returnChoice2;

                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
