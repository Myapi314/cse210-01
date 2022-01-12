string[] places = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

string player = "";
bool game = true;
int turns = 0;

do
{   
    turns += 1;
    Console.WriteLine($"\n\nTurn {turns}:");
    // Build the board.
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

    if ((turns % 2) != 0)
    {
        player = "x";
    }
    else
    {
        player = "o";
    }
    Console.Write($"{player}'s turn to choose a square (1-9): ");
    int boxNum = Convert.ToInt32(Console.ReadLine()) - 1;
    places[boxNum] = player;

    if ((places[0] == places[1] && places[0] == places[2]) ||
        (places[3] == places[4] && places[3] == places[5]) ||
        (places[6] == places[7] && places[6] == places[8]) ||
        (places[0] == places[3] && places[0] == places[6]) ||
        (places[1] == places[4] && places[1] == places[7]) ||
        (places[2] == places[5] && places[2] == places[8]) ||
        (places[0] == places[4] && places[0] == places[8]) ||
        (places[2] == places[4] && places[2] == places[6]))
    {
        game = false;
    }
    if (turns >= 9)
    {
        game = false;
    }
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
Console.WriteLine("Good Game. Thanks for playing!");
