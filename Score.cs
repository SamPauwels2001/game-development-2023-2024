using System;

public class Score
{
    public int CurrentScore { get; private set; }

    public Score()
    {
        CurrentScore = 0; //start with 0
    }

    public void AddPoints(int points)
    {
        CurrentScore += points;
    }

    public void Reset()
    {
        CurrentScore = 0; //reset to 0
    }
}
