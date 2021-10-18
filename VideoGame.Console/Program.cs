Console.Write("Enter a player name: ");
var playerName = Console.ReadLine();
Console.Write("Enter your class (warrior/warlock): ");
var className = Console.ReadLine();

// Dit start een oneindige loop (tot de speler het spel afsluit of tot we 'break' gebruiken).
while (true)
{
    Console.WriteLine($"What will {playerName} do now?");
    Console.Write("> ");
    var action = Console.ReadLine();

    if (action == "stop")
    {
        // Wanneer de gebruiker 'stop' invoert stopt de while loop en eindigt het programma.
        break;
    }
}

// Dit helpt ook zien wanneer onze software zichzelf afsluit.
Console.WriteLine("Thank you for playing, until next time!");