﻿using SearchFight_CodingChallenge.Models;
using SearchFight_CodingChallenge.Services;
using System;
using System.Collections.Generic;
using LightInject;
using System.Linq;

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
                Console.WriteLine("No parameters were found");
                CloseApp();
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                    words.Add(searchService.SearchWord(args[i]));
            }

            #region Print Results
            //Print results in console
            words.ForEach(pl => Console.WriteLine($"{pl.name}: Google: {pl.googleResults} MSN Search: {pl.bingResults}"));

            Console.WriteLine();

            //Print winners in console
            Console.WriteLine($"Google Winner     : {words.OrderByDescending(x => x.googleResults).FirstOrDefault().name}");
            Console.WriteLine($"MSN Search winner : {words.OrderByDescending(x => x.bingResults).FirstOrDefault().name}");
            Console.WriteLine($"Total Winner      : {words.OrderByDescending(x => x.total).FirstOrDefault().name}");
            #endregion Print Results

            CloseApp();
        }

        public static void CloseApp()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
