using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;

namespace Ipmb_Game
{
    class Ipmb_Main
    {    
        static void Main()
        {
            char antwort;
            bool gültigeEingabe;

            Console.SetWindowSize(80, 40);
            Thread.Sleep(300);

            SoundPlayer MainMenuMusic = new SoundPlayer("MainMenuMusic.wav");
            MainMenuMusic.Load();
            MainMenuMusic.PlayLooping();
            
            do
            {
                Console.Clear();
                MenuText();
                gültigeEingabe = false;

                antwort = Console.ReadKey().KeyChar;
                if (antwort == '1')
                {
                    MainMenuMusic.Stop();
                    Spiel();
                }
                else 
                    if (antwort == '2')
                    {
                        MainMenuMusic.Stop();
                        Verlassen();
                    }
                    else 
                        if (antwort == '3')
                        {
                            MainMenuMusic.Stop();
                            Anleitung();
                        }
            } while (gültigeEingabe == false);  
        }
        static void KlickSound()
        {
            SoundPlayer KlickSound = new SoundPlayer("KlickSound.wav");
            KlickSound.Load();
            KlickSound.Play();
        }
        static void MenuText()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@".-.                     .-.            .-.                   .-.                
: :                     : :.-.         : :                   : :                
: :  .---.  .--.   .--. : `'.' .--.  .-' :  ,-.,-.,-..-..-.  : `-.  .--.   .--. 
: :  : .; `' .; ; '  ..': . `.' '_.'' .; :  : ,. ,. :: :; :  ' .; :' .; ; ' .; :
:_;  : ._.'`.__,_;`.__.':_;:_;`.__.'`.__.'  :_;:_;:_;`._. ;  `.__.'`.__,_;`._. ;
     : :                                              .-. :                .-. :
     :_;                                              `._.'                `._.'
            ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t\t\tSpielen ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("= 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tVerlassen ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("= 2\n\n\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\t\t\t\tAnleitung ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("= 3");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"                              ____
                         .---[[__]]----.
                        ;-------------.|       ____
                        |             ||   .--[[__]]---.
                        |             ||  ;-----------.|
                        |             ||  |           ||
                        |_____________|/  |           ||
                                          |___________|/
                               ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\n\n\nBy Samed\t\t\t\t\t\t\t    Version 0.1");      
        }
        static void Verlassen()
        {
            SoundPlayer KlickSound = new SoundPlayer("KlickSound.wav");
            KlickSound.Load();
            KlickSound.Play();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n\t\t   ------------------------------------------");
            Console.WriteLine("\t\t\t   Spiel wird geschlossen.");
            Console.WriteLine("\t\t   ------------------------------------------");
            Console.WriteLine("\t\t\t       In 3 sekunden...");
            KlickSound.Play();
            Thread.Sleep(1000);
            Console.WriteLine("\t\t\t       In 2 sekunden...");
            KlickSound.Play();
            Thread.Sleep(1000);
            Console.WriteLine("\t\t\t       In 1 sekunde...");
            KlickSound.Play();
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        static void Anleitung()
        {
            bool gültigeEingabe = false; 
            do
            {
                KlickSound();
                Thread.Sleep(200);
                SoundPlayer AnleitungMusik = new SoundPlayer("Melancholic Walk.wav");
                AnleitungMusik.Load();
                AnleitungMusik.PlayLooping();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"       _______ __   _        _______ _____ _______ _     _ __   _  ______
       |_____| | \  | |      |______   |      |    |     | | \  | |  ____
       |     | |  \_| |_____ |______ __|__    |    |_____| |  \_| |_____|
             ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t    +--------------------------------------+");
                Console.WriteLine("\t\t    |Wilkommen zu \"Ich packe meinen Koffer\"|");
                Console.WriteLine("\t\t    +--------------------------------------+\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t1: Geben Sie die Spieleranzahl ihrer Gruppe ein.\n");
                Console.WriteLine("\t2: Geben Sie die Spielernamen ihrer Spieler ein.\n");
                Console.WriteLine("\t3: Sammeln Sie viele Punkte in dem Sie in den einzelnen Runden lange\n\t   bestehen beleiben.\n");
                Console.WriteLine("\t4: Während den Runden hat jeder 3 Joker.\n");
                Console.WriteLine("   Joker 1: Die einmalige Berechtigung seine Runde zu überspringen.\n");
                Console.WriteLine(@"   Joker 2: Die einmalige Berechtigung weiter zu machen auch wenn man die
            Reinfolge der Gegenstände nicht richtig aufgeschrieben hat.
            ");
                Console.WriteLine(@"   Joker 3: Die einmalige Berechtigung einen Gegenstand aufzuschreiben auch 
            wenn es ihn schon gibt.
            ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\tViel Spaß :D");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n\n\nZurück = 1");
                gültigeEingabe = false;

                int antwort = Console.ReadKey().KeyChar;
                if (antwort == '1')
                {
                    AnleitungMusik.Stop();
                    KlickSound();
                    Main();
                }              
            } while (gültigeEingabe == false);
        }
        static void Spiel()
        {
            int antwort, laufzahl = 0;
            bool gültigeEingabe = false;
            bool ersterunde = false;

            List<Spieler> spieler = new List<Spieler>();

            KlickSound();
            SoundPlayer SpielMusik = new SoundPlayer("A Lonely Cherry Tree.wav");
            SpielMusik.Load();
            SpielMusik.PlayLooping();          
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"          ____ ___  _ ____ _    ____ ____ ____ _  _ ___  ____ _  _ _    
          [__  |__] | |___ |    |___ |__/ |__| |\ |   /  |__| |__| |    
          ___] |    | |___ |___ |___ |  \ |  | | \|  /__ |  | |  | |___                                                              
            ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t   Wie viele Spieler sollen erstellt werden?");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n\n\t\t\t      Spieleranzahl = ");
                Console.ForegroundColor = ConsoleColor.White;
                antwort = Convert.ToInt32(Console.ReadLine());
                KlickSound();
                Thread.Sleep(200);
                SpielMusik.PlayLooping();
                if (antwort > 1)
                {
                    for (int i = 0; i < antwort; i++)
                    {
                        spieler.Add(new Spieler());
                        gültigeEingabe = true;
                    }
                }
            } while (gültigeEingabe == false);           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\t\t         Spieler werden erstellt");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(700);
            Console.Write(".");
            Thread.Sleep(1200);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n\t\t       Spieler erstellung erfolgreich!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\n\nZurück = 2\t\t\t\t\t\t\t     Weiter = 1");


            do
            {
                antwort = Console.ReadKey().KeyChar;
                if (antwort == '1')
                {
                    KlickSound();
                    gültigeEingabe = true;  
                }
                else 
                    if (antwort == '2')
                    {
                        SpielMusik.Stop();
                        KlickSound();
                        Main();
                    }
            } while (gültigeEingabe == false);



            for(int a = 0; a < spieler.Count; a++)
            {
                Console.Clear();
                laufzahl++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"            ____ ___  _ ____ _    ____ ____ _  _ ____ _  _ ____ _  _ 
            [__  |__] | |___ |    |___ |__/ |\ | |__| |\/| |___ |\ | 
            ___] |    | |___ |___ |___ |  \ | \| |  | |  | |___ | \|                                                       
            ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t   Geben Sie die Spielernamen ein");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n\n\t\t\t      Spieler {0}:",laufzahl);
                Console.ForegroundColor = ConsoleColor.White;

                spieler[a]._name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\t\tNamensgebung erfolgreich!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nZurück = 2\t\t\t\t\t\t\t     Weiter = 1");
            

            do
            {
                antwort = Console.ReadKey().KeyChar;
                if (antwort == '1')
                {
                    KlickSound();
                    gültigeEingabe = true;
                }
                else 
                    if (antwort == '2')
                    {
                        SpielMusik.Stop();
                        KlickSound();
                        Main();
                    }
            } while (gültigeEingabe == false);

            //Erste Runde
            laufzahl = -1;
            string ersteswort = null;
            string weitereswort = null;
            int c = 0;
            do
            {

                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"                         ____ _  _ _  _ ___  ____    _ 
                         |__/ |  | |\ | |  \ |___    | 
                         |  \ |__| | \| |__/ |___    | 
                              
            ");
                Console.ForegroundColor = ConsoleColor.White;



                if (string.IsNullOrEmpty(ersteswort))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t{0} ist dran.", spieler[0]._name);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\tIch packe meinen Koffer und nehme mit ein/eine: \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    ersteswort = Convert.ToString(Console.ReadLine());
                    c++;
                    Console.Clear();
                    
                }
                else
                {
                    c++;
                }

                if (c == spieler.Count)
                {
                    c = 0;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t{0} ist dran.", spieler[c]._name);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tIch packe meinen Koffer und nehme mit ein/eine: \n");
                Console.ForegroundColor = ConsoleColor.White;
                string testwort = Console.ReadLine();
                if (ersteswort == testwort)
                {
                    
                    Console.Write(" ");
                    weitereswort = Console.ReadLine();
                    ersteswort = ersteswort + " " + weitereswort;

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"                         ____ _  _ _  _ ___  ____    _ 
                         |__/ |  | |\ | |  \ |___    | 
                         |  \ |__| | \| |__/ |___    | 
                              
            ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t{0} hat die falsche Reinfolge eingegeben!", spieler[c]._name);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\n\n\t\tHauptmenü = 1\t\t\t     Schließen = 2");
                    do
                    {
                        antwort = Console.ReadKey().KeyChar;
                        if (antwort == '1')
                        {
                            KlickSound();
                            Main();
                        }
                        else
                            if (antwort == '2')
                        { 
                            KlickSound();
                            Verlassen();
                        }
                    } while (gültigeEingabe == false);
                }

            } while (ersterunde == false);

        }
        
    }
    class Spieler
    {
        public string _name;      
    }
}
