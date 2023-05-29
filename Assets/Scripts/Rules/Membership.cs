public class Membership
{
    private float[] Points { get; }

    public Membership(float[] points)
    {
        Points = points;
    }

    public float Get(float value)
    {
        if (value <= Points[0] || value >= Points[3])
            return 0f;
        if (value >= Points[1] && value <= Points[2])
            return 1f;
        if (value < Points[1])
            return (value - Points[0]) / (Points[1] - Points[0]);
        return (Points[3] - value) / (Points[3] - Points[2]);
    }
    
    
    public float Get2(float value)
    {
        if (value > Points[1])
            return 0f;
        return (Points[1] - value) / Points[1];
    }
    
}