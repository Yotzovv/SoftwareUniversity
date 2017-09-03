using System;

public abstract class Mission : IMission
{
    private string name;
    private double scoreToComplete;
    private double wearLvlDecrement;
    private double enduranceRequired;

    protected Mission(string name, double scoreToComplete, double wearLvlDecrement, double enduranceRequired)
    {
        this.name = name;
        this.scoreToComplete = scoreToComplete;
        this.wearLvlDecrement = wearLvlDecrement;
        this.enduranceRequired = enduranceRequired; 
    }

    public double EnduranceRequired { get { return this.enduranceRequired; } }

    public string Name { get { return this.name; } }

    public double ScoreToComplete { get { return this.scoreToComplete; } }

    public double WearLevelDecrement { get { return this.wearLvlDecrement; } }
}

