namespace Task3;

public class Help
{
    static public void HelpTable(string[] args)
    {
        // Console.WriteLine(args);
        int mode = (args.Length - 1) / 2;

        for (int i = 0; i < args.Length; i++)
        {
            Console.Write("{0}\t\t", args[i]);
            if((i+1) == args.Length)
                Console.Write("Your choice ↓"); 
        }
        Console.WriteLine("");

        for (int i = 0; i < args.Length; i++)
        {
            for (int j = 0; j < args.Length; j++)
            {
                Console.Write("{0}\t\t", CompareElem(i , j, mode));
                if((j + 1) == args.Length)
                    Console.Write(" " + args[i]);
            }
            Console.WriteLine();
            continue;
        }
        Console.WriteLine("");
    }
    
    static public string CompareElem (int i, int j, int mode)
    {
        if (i == j)
        {
            return "Draw";
        }
 
        if (((j - i) > 0 && ((j - i) <= mode)) || (j - i) < ((-1) * mode) )
        {
            return "Win";
        }

        return "Lose";
    }
}