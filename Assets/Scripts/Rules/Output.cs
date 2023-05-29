using System;

public enum Output
{
    Slow,
    Moderate,
    Fast,
}

public enum Direction
{
    None,
    Weak,
    Strong,
}


[Serializable]
public class OutPut
{
    public Output Output;
    public Direction Horizontal;
    public Direction Vertical;
}