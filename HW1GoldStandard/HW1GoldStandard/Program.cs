/**************************************************************************************************************************
 * This program will use the Team and SoccerTeam classes to create a list of SoccerTeams
 * objects that are initialized with input from the user (points and name). It will then 
 * sort this list of SoccerTeam objects and display them in order.
 * 
 * 
 * Author: Shane Whitlock
 * NetID: sawhit
 * DateCreated: 9/14/2016
 * *************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1GoldStandard
{
    class Program
    {
        public class Team
        {
            //attributes
            public string teamName;
            public int wins;
            public int losses;

            public Team()
            {

            }

            public Team(int wins)
            {
                this.wins = wins;
            }
        }



        //SoccerTeam inherits from Team class
        public class SoccerTeam : Team
        {
            //attributes of soccer team class
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;
            public List<Game> soccerGames = new List<Game>();



            //default constructor
            public SoccerTeam()
            {

            }

            //constructor that receives one parameteres
            public SoccerTeam(String sName)
            {
                this.teamName = sName;
            }

            //constructor that receives two parameteres
            public SoccerTeam(String sName, int Points)
            {
                this.points = Points;
                this.teamName = sName;
            }

        }

        //the game class
        public class Game
        {

            public int pointsFor;
            public int pointsAgainst;
            public int totalPoints;
            public int Goods;
            public int gameID;

            public Game(int gameNum, int good, int bad)
            {
                this.gameID = gameNum;
                this.pointsAgainst = bad;
                this.pointsFor = good;
            }

        }

        //Function to get random number
        public static Random getrandom = new Random();

        //UppercaseFirst method will capitalize the first letter of the input
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        static void Main(string[] args)
        {
            bool startInput = true;

            Console.WriteLine("Would you like to: 1. Simulate a season or 2. Manually input points?");

            while (startInput == true)
            {
                string response = Console.ReadLine();

                if (response.Equals("1"))
                {
                    List<SoccerTeam> teams = new List<SoccerTeam>();

                    //get the number of teams
                    Console.Write("\nHow many teams? ");
                    //convert the input to an int
                    int numTeams = Convert.ToInt32(Console.ReadLine());

                    //create soccer team objects
                    for (int iCount = 0; iCount < numTeams; iCount++)
                    {
                        //Enter the team's name (iCount + 1) so we start at 1 instead of 0
                        Console.WriteLine("\nEnter team " + (iCount + 1) + "'s name: ");

                        //Read the team name
                        string sName = Console.ReadLine();

                        //Use the uppercasefirst method to make the first letter of the team name uppercased
                        string sUName = UppercaseFirst(sName);

                        //create a new SoccerTeam object
                        teams.Add(new SoccerTeam(sUName));

                    }

                    //ask how many games each team will play
                    Console.WriteLine("\n\nHow many games will each team play? ");

                    //get the number of games
                    int numGames = Convert.ToInt32(Console.ReadLine());

                    //simulate games for each team
                    foreach (SoccerTeam team in teams)
                    {
                        //simulate each game
                        for (int j = 1; j < (numGames + 1); j++)
                        {
                            //get two scores and create a game
                            int good = getrandom.Next(1, 10);
                            int bad = getrandom.Next(1, 10);
                            team.soccerGames.Add(new Game(j, bad, good));

                            //determine win/loss/draw
                            if (good > bad)
                            {
                                team.wins++;
                            }
                            else if (bad > good)
                            {
                                team.losses++;
                            }
                            else
                            {
                                team.draw++;
                            }

                            team.points = team.points + good;
                        }
                    }





                    //sort the list using linq
                    List<SoccerTeam> sortedTeams = teams.OrderByDescending(team => team.wins).ToList();

                    //create a counter to write the positiions in the output
                    int iCounter = 0;

                    //write the heading to the console
                    Console.WriteLine("\n\nHere is the sorted output: \n\n" + ("Position").PadRight(15) + ("Name").PadRight(15) + ("Record (W-L-D)").PadRight(25) + ("TotalPoints").PadRight(15) + "\n" +
                        ("---------").PadRight(15) + ("-----").PadRight(15) + ("----------------").PadRight(25) + ("--------"));

                    //foreach loop will display the sorted list with it's positions
                    foreach (SoccerTeam team in sortedTeams)
                    {

                        //increment the counter before printing it's value
                        ++iCounter;

                        //pad the output so it looks neat, in columns
                        Console.WriteLine(iCounter.ToString().PadRight(15) + team.teamName.PadRight(15) + team.wins.ToString() + "-" + team.losses.ToString() + "-" + team.draw.ToString().PadRight(25) + team.points.ToString());
                    }

                    //leave a readline so that the program will end on enter
                    Console.ReadLine();

                    startInput = false;

                }

                else if (response.Equals("2"))
                {
                    List<SoccerTeam> teams = new List<SoccerTeam>();

                    //get the number of teams
                    Console.Write("How many teams? ");

                    //convert the input to an int
                    int numTeams = Convert.ToInt32(Console.ReadLine());

                    //create soccer team objects
                    for (int iCount = 0; iCount < numTeams; iCount++)
                    {
                        //Enter the team's name (iCount + 1) so we start at 1 instead of 0
                        Console.WriteLine("\n\nEnter team " + (iCount + 1) + "'s name: ");

                        //Read the team name
                        string sName = Console.ReadLine();

                        //Use the uppercasefirst method to make the first letter of the team name uppercased
                        string sUName = UppercaseFirst(sName);

                        //Write the statement to the console with the new, uppercase, name
                        Console.WriteLine("\nEnter " + sUName + "'s points: ");

                        //create a bool variable to test break out of the while loop to test input
                        bool goodInput = false;

                        //while loop to keep testing the input
                        while (goodInput == false)
                        {
                            try
                            {
                                //convert the input to an integer
                                int iPoints = Convert.ToInt32(Console.ReadLine());

                                //create a new SoccerTeam object
                                teams.Add(new SoccerTeam(sUName, iPoints));

                                //break the while loop by changing the bool
                                goodInput = true;
                            }

                            //if the input is not an integer
                            catch (Exception e)
                            {
                                //ask the user to input an integer
                                Console.WriteLine("Enter an integer please: ");
                            }
                        }






                    }

                    //sort the list using linq
                    List<SoccerTeam> sortedTeams = teams.OrderByDescending(team => team.points).ToList();

                    //create a counter to write the positiions in the output
                    int iCounter = 0;

                    //write the heading to the console
                    Console.WriteLine("\n\nHere is the sorted output: \n\n" + ("Position").PadRight(25) + ("Name").PadRight(25) + ("Points").PadRight(25) + "\n" +
                        ("---------").PadRight(25) + ("-----").PadRight(25) + ("--------").PadRight(25));

                    //foreach loop will display the sorted list with it's positions
                    foreach (SoccerTeam team in sortedTeams)
                    {

                        //increment the counter before printing it's value
                        ++iCounter;

                        //pad the output so it looks neat, in columns
                        Console.WriteLine(iCounter.ToString().PadRight(25) + team.teamName.PadRight(25) + team.points.ToString().PadRight(25));
                    }

                    //leave a readline so that the program will end on enter
                    Console.ReadLine();

                    startInput = false;
                }
                else
                {
                    Console.Write("Plese enter either 1 or 2:  ");
                }
            }
        }
    }
}





