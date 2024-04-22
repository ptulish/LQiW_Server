namespace LQiW_Server.Classen;

public class CalculateRating
{
    public static int CalculateRating500(double distance)
    {
        if (distance <= 1) return 5;
        else if (distance <= 2) return 4;
        else if (distance <= 3) return 3;
        else if (distance <= 4) return 2;
        else if (distance <= 8) return 1;
        else return 0; 
    }
    public static int CalculateRating30(double distance)
    {
        if (distance <= 0.09) return 5;
        else if (distance <= 0.16) return 4;
        else if (distance <= 0.5) return 3;
        else if (distance <= 1) return 2;
        else if (distance <= 2) return 1;
        else return 0; 
    }public static int CalculateRating100(double distance)
    {
        if (distance <= 0.2) return 5;
        else if (distance <= 0.4) return 4;
        else if (distance <= 1) return 3;
        else if (distance <= 1.8) return 2;
        else if (distance <= 3.0) return 1;
        else return 0; 
    }
    public static int CalculateRating200(double distance)
    {
        if (distance <= 0.4) return 5;
        else if (distance <= 0.8) return 4;
        else if (distance <= 1.9) return 3;
        else if (distance <= 3) return 2;
        else if (distance <= 5.0) return 1;
        else return 0; 
    }
    public static double CalculateWeightedAverage(List<double> values, List<double> weights)
    {
        double totalWeight = 0;
        double sumProduct = 0;

        for (int i = 0; i < values.Count; i++)
        {
            sumProduct += values[i] * weights[i];
            totalWeight += weights[i];
        }

        if (totalWeight == 0) return 0;

        return sumProduct / totalWeight;
    }
}