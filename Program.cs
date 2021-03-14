using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
       //2D array used for displaying the fields and changing it accordingly to X or O 
       static char[,] playField = new char[,]
           {

                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
           };

       
        //variable used for counting the turns for each play
        static int turns = 0;

        //method for resetting the field after a game has ended
        public static void ResetField()
        {
            //setting the initial field with this 2D array
            char[,] initialplayField = new char[,]
          {

                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
          };
            playField = initialplayField;
            SetField();
            turns = 0;
        }

        //setting the field and displaying the tictactoe interface to the console
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |       |");
            Console.WriteLine(" {0}   |   {1}   |   {2}", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("     |       |");
            Console.WriteLine("--------------------");
            Console.WriteLine("     |       |");
            Console.WriteLine(" {0}   |   {1}   |   {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("     |       |");
            Console.WriteLine("--------------------");
            Console.WriteLine("     |       |");
            Console.WriteLine(" {0}   |   {1}   |   {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |       |");
            turns++;
        }

        //method for assigning X or O according to the player in the 2D array
        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';
            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';



            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }

           



        }
        static void Main(string[] args)
        {
            int player = 1;
            int input = 0;
            bool inputCorrect = true;

           

            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

               
                SetField();
                //check if someone won 

                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars)
                {
                    

                  //horizontal check
                    if(((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))

                            || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))

                            || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                  //vertical check
                            || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))

                            || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))

                            || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))

                  //diagonal check
                            || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))

                            || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar)))
                    {

                        if(playerChar == 'X')
                           Console.WriteLine("\n ---- Winner !! -- Player 2\n");
                        else
                           Console.WriteLine("\n ---- Winner !! -- Player 1\n");
                        Console.WriteLine("Please press any key to reset the game !");
                        Console.ReadKey();
                        ResetField();
                        break;

                    }

                    //max turns 10, then displaying the draw game message and ressetting the game
                    else if(turns == 10)
                    {
                        Console.WriteLine("\n ---- Its a draw, No Winner !! ------\n");
                        Console.WriteLine("Please press any key to reset the game !");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                

                do
                {
                    Console.Write("Player {0} : Choose your field - ", player);
                    inputCorrect = Int32.TryParse(Console.ReadLine(), out input);

                    //checking the input from the player
                    if(!inputCorrect)
                    {
                        Console.WriteLine("Please enter the correct number !");
                        continue;
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        inputCorrect = true;

                    else
                    {
                        Console.WriteLine("\n Incorrect input. Field already used. Please enter another field!\n"); 
                        inputCorrect = false;
                    }
                      

                } while (!inputCorrect);

            } while (true);

        }
    }
}
