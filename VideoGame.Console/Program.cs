using VideoGame.Console.Data;
using VideoGame.Console.Entities;

var playerName = Prompt("Enter a player name: ");
var playerType = PromptPlayerType("Enter a class (warrior, warlock): ");
var player = new Player(playerName, playerType);
var playerRepository = new PlayerRepository();
var weaponsRepository = new WeaponsRepository();

// Dit start een oneindige loop (tot de speler het spel afsluit of tot we 'break' gebruiken).
while (true)
{
    Console.WriteLine($"What will {player.Name} do now?");
    Console.Write("> ");
    var action = Console.ReadLine();

    if (action == "fight")
    {
        var monster = new Monster("Goblin", 10);
        while (monster.Health > 0 && player.Health > 0)
        {
            var playerDamage = player.AmountOfDamage();
            var monsterDamage = monster.AmountOfDamage();
            monster.Health -= playerDamage;
            player.Health -= monsterDamage;
            Console.WriteLine($"{player.Name} deals {playerDamage} to {monster.Name} and {monster.Name} deals {monsterDamage} to {player.Name}");
        }

        if (player.Health == 0)
        {
            Console.WriteLine($"{monster.Name} wins, you died!");
            break; // Eindig spel, monster wint.
        }
        else
        {
            Console.WriteLine($"{player.Name} defeated {monster.Name}!");
        }
    }
    else if (action == "rest")
    {
        player.Health = 100;
        Console.WriteLine($"{player.Name} recovers all his health!");
    }
    else if (action == "save")
    {
        weaponsRepository.Save(player.Weapon);
        playerRepository.Save(player);
    }
    else if (action == "stop")
    {
        // Wanneer de gebruiker 'stop' invoert stopt de while loop en eindigt het programma.
        break;
    }
    else
    {
        Console.WriteLine("A list of possible commands:");
        Console.WriteLine("- fight: fight a randomly generated monster");
        Console.WriteLine("- rest: fully heals the player to 100 health");
        Console.WriteLine("- stop: stops the game");
    }
}

// Dit helpt ook zien wanneer onze software zichzelf afsluit.
Console.WriteLine("Thank you for playing, until next time!");

// Deze functie vraagt de gebruiker iets in te voeren en controleert dat het antwoord niet leeg is.
string Prompt(string message)
{
    string? result;
    do
    {
        Console.Write(message);
        result = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(result)); // Zolang de input leeg is, null of enkel spaties blijven we loopen.

    return result;
}

// Dit laat ons een player type invoeren, bij een geldige invoer geeft dit de correcte enum waarde terug, bij een foutieve invoer geven we een foutmelding terug.
Player.PlayerType PromptPlayerType(string message)
{
    while (true)
    {
        string type = Prompt(message);

        // string.Equals laat ons toe om een StringComparison te definieren, in dit geval IgnoreCase (A == a) zodat Warlock, warlock, WARLOCK, WaRlOcK allemaal hetzelfde zijn.
        if (string.Equals(type, "warrior", StringComparison.InvariantCultureIgnoreCase))
            return Player.PlayerType.Warrior;
        else if (string.Equals(type, "warlock", StringComparison.InvariantCultureIgnoreCase))
            return Player.PlayerType.Warlock;

        Console.WriteLine("Unknown player class!");
    }
}