﻿using System;
using System.Threading;

namespace Pendu
{
    class Program
    {

        

        static string generateWords(int lvl)
        {
            string[] listHard = { "unique",
                                 "valeur",
                                    "zebi",
                                    "amélanchier",
                                    "bruxomanie",
                                    "chleuasme",
                                    "dispomanie",
                                    "fuligneux",
                                    "gourgandine",
                                    "meteorisme",
                                    "ziggourat",
                                    "thaumaturge",
                                    "croquignole",
                                    "cucule",
                                    "emoucher",
                                    "logomachie",
                                    "boulingrin",
                                    "hippopotomonstrosesquippedaliophobie"};

            string[] listAlcool =
            {
                "vodka",
                "vin",
                "biere",
                "mojito",
                "pastis",
                "rose",
                "goute",
                "cognac",
                "armagnac",
                "whisky",
                "rhum",
                "absinthe",
                "amaretto",
                "bourbon",
                "cocktail",
                "malibu",
                "sake",
                "ricard",
                "suze",
                "tequilla",
                "gentiane",
                "jagermeister"};

            if (lvl==1)
            {
                Random rand = new Random();
                string word = listAlcool[rand.Next(0, listAlcool.Length)];
                return word;
            }
            else
            {
                Random rand = new Random();
                string word = listHard[rand.Next(0, listHard.Length)];
                return word;
            }
        }

        static void Main(string[] args)
        {
            play();
        }

        static void play()
        {
            Console.WriteLine("Bonsoir jeune aventurier ! bienvenu dans ce nouveau jeu au concept inconnu et spécial !");
            Thread.Sleep(500);
            Console.WriteLine("LE PENDU ! ");
            ChoiceLvl();
        }

        static void ChoiceLvl()
        {
            Console.WriteLine("A toi de choisir le mode de jeu de ton pendu ! tu préfères jouer sur les noms d'alcools ou les mots les plus compliqués ever (1/2)");
            string answer = Console.ReadLine();
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("il nous faut que tu répondes par 1 ou 2");
                answer = Console.ReadLine();
            }
            GameTime(answer);

        }

        static void GameTime(string lvl)
        {
            int HP = 6;
            bool InGame = false;
            string word = generateWords(int.Parse(lvl));

            char [] LetterInWord = initTab(word);
            char[] NotLetterInWord = new char[26-LetterInWord.Length];

            while (InGame == false) //play until the player win/lose the game
            {
                InGame = PrintGame(LetterInWord, NotLetterInWord, word,HP) ;
            }
            
        }

        static string [] initTab(string word)
        {
            char[] Tab;
            Tab = word.ToCharArray();
            for (int i = 0; i< word.Length; i++)
            {
                
            }
        }
        
    }
}
