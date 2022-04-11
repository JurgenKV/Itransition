using System.Security.Cryptography;
using System.Text;
using Task3;

internal class Program
{
    static private readonly Random _random = new Random();
    
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("The number of arguments shouldn't be equal to zero");
            return;
        }

        if (args.Length < 3)
        {
            Console.WriteLine("The number of arguments should be >=3");
            return;
        }

        if (args.Length % 2 == 0)
        {
            Console.WriteLine("The number of arguments must be odd");
            return;
        }

        IEnumerable<string> duplicateCheck = args.Distinct();

        if (duplicateCheck.Count() != args.Length)
        {
            Console.WriteLine("Arguments must not be repeated");
            return;
        }

        var a = HashMac.GenerateRandomKey();
        var computerMove = RandomNumber(0, args.Length);
        var valueHmac = HashMac.GenerateHMAC(args[computerMove], a);

        Console.WriteLine("HMAC:  " + Convert.ToBase64String(valueHmac));

        int userMove;
        while (true)
        {
            createMenu(args);
            var str = Console.ReadLine();
            if (str.Equals("0"))
                return;

            if (str.Equals("?"))
            {
                Help.HelpTable(args);
                continue;
            }

            try
            {
                userMove = Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your move is incorrect. Try again");
                continue;
            }

            if (userMove >= args.Length + 1 || userMove < 0)
            {
                Console.WriteLine("Your move is incorrect. Try again");
                continue;
            }

            userMove--;
            break;
        }

        Console.WriteLine("Your move: " + args[userMove]);
        Console.WriteLine("Computers move: " + args[computerMove]);

        var winNumbsLength = args.Length / 2;
        var winNums = new int[winNumbsLength];
        var userM = userMove;
        var g = 0;

        for (var j = 0; j < winNums.Length; j++)
        {
            userM++;
            if (userM == args.Length)
                userM = 0;

            winNums[g] = userM;
            g++;
        }

        GameControl.RoundResult(userMove, computerMove, winNums, a);
    }

    public static void createMenu(string[] args)
    {
        for (var i = 0; i < args.Length; i++)
            Console.WriteLine(i + 1 + " - " + args[i]);
        
        Console.WriteLine("0" + " - " + "Exit");
        Console.WriteLine("?" + " - " + "Help");
        Console.Write("Enter your move: ");
    }
    
    static public int RandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}