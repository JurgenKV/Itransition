namespace Task3;
public class GameControl
{
    static public void RoundResult(int userMove, int computerMove, int[] winNums, byte[] a )
    {
        if (userMove == computerMove)
        {
            Console.WriteLine("It's draw");
            Console.WriteLine("HMAC key:  " + Convert.ToBase64String(a));
            return;
        }
        for (int j = 0; j < winNums.Length; j++)
        {
            if(winNums[j]==computerMove)
            {
                Console.WriteLine("You win");
                Console.WriteLine("HMAC key:  " + Convert.ToBase64String(a));
                return;
            }
        }
        Console.WriteLine("You lose");
        Console.WriteLine("HMAC key:  " + Convert.ToBase64String(a));
    }
    
}