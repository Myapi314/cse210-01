// CSE210-01 Tic-Tac-Toe 
// Mya Finch Scottorn
// 15 Jan. 2022

// The array of spots on the tic-tac-toe board. 
string[] places = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

// Initialize the player variable. 
string player = "";

// Set game to true and start the turns at 0.
bool game = true;
int turns = 0;
bool winner = false;


// The main loop that runs the game. 
do
{   
    // The number of turn the players are on. Also for tracking when
    // the game becomes a draw. 
    turns += 1;
    Console.WriteLine($"Turn {turns}:");

    // Build and display the board.
    for (int i = 0; i < 9; i++)
    {
        Console.Write($"{places[i]}");
        if ((i + 1) % 3 != 0)
        {
            Console.Write("|");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("-+-+-");
        }
    }

    // Switch the player every turn.
    if (player == "o" || player == "")
    {
        player = "x";
    }
    else
    {
        player = "o";
    }

    // Ask the current player to choose a spot on the board.
    Console.Write($"{player}'s turn to choose a square (1-9): ");

    // Convert the input to an int and subtract one to get the 
    // corresponding index to edit in the array.
    int boxNum = Convert.ToInt32(Console.ReadLine()) - 1;
    places[boxNum] = player;

    // Check if there is 3 x's or o's in a row.
    if ((places[0] == places[1] && places[0] == places[2]) ||
        (places[3] == places[4] && places[3] == places[5]) ||
        (places[6] == places[7] && places[6] == places[8]) ||
        (places[0] == places[3] && places[0] == places[6]) ||
        (places[1] == places[4] && places[1] == places[7]) ||
        (places[2] == places[5] && places[2] == places[8]) ||
        (places[0] == places[4] && places[0] == places[8]) ||
        (places[2] == places[4] && places[2] == places[6]))
    {
        // If there are 3 in a row end the game and set winner
        // to true.
        game = false;
        winner = true;
    }

    // End the game when the board has been filled.
    else if (turns >= 9)
    {
        game = false;
    }

    Console.WriteLine("");

// Show the board one last time with the winning move. 
} while (game == true);

for (int i = 0; i < 9; i++)
{
    Console.Write($"{places[i]}");
    if ((i + 1) % 3 != 0)
    {
        Console.Write("|");
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine("-+-+-");
    }
}

// Display the winner or if it was a draw. End of game message. 
if (winner)
{
    Console.WriteLine($"{player}'s Win!");
}
else
{
    Console.WriteLine("DRAW :P");
}

Console.WriteLine("Good Game. Thanks for playing!");
