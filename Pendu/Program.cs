using System;
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
                                    "hippopotomonstrosesuipedaliophobie"};

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

            char [] LetterInWord = initLetterInWord(word);
            char[] NotLetterInWord = initNotLetterTab(LetterInWord);
            char[] PrintableTab = initPrintableTab(LetterInWord);
            while (InGame == false) //play until the player win/lose the game
            {
                PrintableTab = PrintGame(LetterInWord, NotLetterInWord, word,HP,PrintableTab) ;
                InGame = IfWin(PrintableTab);
            }
            
        }

        static char [] initLetterInWord(string word)
        {
            char[] LetterInWord;
            LetterInWord = word.ToCharArray();
            return LetterInWord;
            
        }

        static char [] initPrintableTab(char [] LetterInWord)
        {
            char[] PrintableTab = new char[LetterInWord.Length];
            for (int i = 0; i < LetterInWord.Length; i++)
            {
                PrintableTab[i] = '_';
            }
            return PrintableTab;
        }

        static char [] initNotLetterTab(char[] LetterInWord)
        {
            
            int num = 26;
            for (int i = 0; i < LetterInWord.Length; i++)
            {
                if (LetterInWord[i] == (char)0)
                {

                }
                else
                {
                    char c = LetterInWord[i];
                    num = num - 1;
                    LetterInWord[i] = (char)0;
                    for (int a =0; a < LetterInWord.Length; a++)
                    {
                        if (LetterInWord[a] == c)
                        {
                            LetterInWord[a] = (char) 0;
                        }
                    }
                }
                
            }
            char[] NotLetterInWord = new char[num];
            return NotLetterInWord;
        }

        static char[] PrintGame(char[] LetterInWord, char[] NotLetterInWord, string word, int Hp, char[] PrintableTab) 
        {
            PrintableTab = IfLetterRight(LetterInWord, PrintableTab,NotLetterInWord) ;
            bool Pendu = PrintPendu(PrintableTab);

        }

        static char[] IfLetterRight(char[] LetterInWord, char [] PrintableTab,char[] NotLetterInWord) //Test if the char that th player give us is in the word 
        {
            Console.Clear();
            Console.WriteLine("A toi de jouer donne nous une lettre !");
            char CharChoose = Letter(PrintableTab,NotLetterInWord);
            for (int i = 0; i < LetterInWord.Length; i++)
            {
                if (CharChoose == LetterInWord[i])
                {
                    PrintableTab[i] = CharChoose;

                }
            }
            return PrintableTab;

        }

        static char Letter(char[] PrintableTab, char[] NotLetterInWord)
        {
            char[] List =
            {
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
            };
            
            try
            {
                char CharChooseS = Char.Parse(Console.ReadLine());
                for (int a = 0; a < PrintableTab.Length; a++)
                {
                    if (CharChooseS == PrintableTab[a])
                    {
                        Console.WriteLine("Il nous faut une lettre que tu n'as pas déjà donné");
                        return Letter(PrintableTab, NotLetterInWord);
                    }
                }
                for (int i = 0; i<NotLetterInWord.Length; i++)
                {
                    if (CharChooseS == NotLetterInWord[i])
                    {
                        Console.WriteLine("Il nous faut une lettre que tu n'as pas déjà donné");
                        return Letter(PrintableTab, NotLetterInWord); 
                    }
                }
                
                    for (int i = 0; i < List.Length; i++)
                    {
                        
                        if (CharChooseS == List[i])
                        {
                        return CharChooseS;
                        }
                        
                    }

                Console.WriteLine("Il ne nous faut qu'une lettre en minuscule et rien d'autre");
                return Letter(PrintableTab,NotLetterInWord);

            }
            catch
            {
                Console.WriteLine("Il ne nous faut qu'une lettre en minuscule et rien d'autre");
                return Letter(PrintableTab,NotLetterInWord);
            }
        }
        
    }
}
