using SearchFight_CodingChallenge.Models;
using SearchFight_CodingChallenge.Services;
using System;
using System.Collections.Generic;
using LightInject;

namespace SearchFight_CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionConfig.ConfigureServices();

            var searchService = DependencyInjectionConfig.ServContainer.GetInstance<ISearchService>();

            List<SearchedWord> words = new List<SearchedWord>();

            if (args == null || args.Length == 0)
            {
                words.Add(searchService.SearchWord(".net"));
                words.Add(searchService.SearchWord("java"));
                
                Console.WriteLine("No parameters were found");                
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                    words.Add(searchService.SearchWord(args[i]));
            }

            #region Print Results
            //Print results in console
            words.ForEach(pl => Console.WriteLine($"{pl.name}: Google: {pl.googleResults} MSN Search: {pl.bingResults}"));

            //Print winners in console
            Console.WriteLine("Google Winner:");
            Console.WriteLine("Bing Winner:");
            Console.WriteLine("Total Winner:");
            #endregion Print Results
        }
    }
}
