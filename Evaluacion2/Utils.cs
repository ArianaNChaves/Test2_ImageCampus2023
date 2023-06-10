namespace Evaluacion2;

public class Utils
{
    public static bool IsCritic(int chance)
    {
        Random random = new Random();
        //todo Cambiar la variable show por random.Next..
        int show = random.Next(100);
        Console.WriteLine("random number: " + show);
        return show <= chance;
    }
}