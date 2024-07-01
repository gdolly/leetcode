using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Practice.Tests.test.Bowling;

public class BowlingKataTests
{

    [Fact]
    public void ShouldScore0For0PinsKnocked()
    {
        var bowlingGame = new BowlingGame();
        RollMany(bowlingGame, 20, 0);
        var score = bowlingGame.GetScore();
        Assert.Equal(0, score);
    }
    
    [Fact]
    public void ShouldScore20For20PinsKnocked()
    {
        var bowlingGame = new BowlingGame();
        RollMany(bowlingGame, 20, 1);
        var score = bowlingGame.GetScore();
        Assert.Equal(20, score);
    }
    
    [Fact]
    public void ShouldScoreASpareFor10PinsKnockedInOneTry()
    {
        var bowlingGame = new BowlingGame();
        
        RollSpare(bowlingGame);
        bowlingGame.Roll(3);
        RollMany(bowlingGame, 17, 1);
        
        var score = bowlingGame.GetScore();
        Assert.Equal(43, score);
    }

    [Fact]
    public void ShouldScoreAStrikeFor10PinsKnockedFirstRollOfAFrame()
    {
        var bowlingGame = new BowlingGame();

        RollAStrike(bowlingGame);
        bowlingGame.Roll(3);
        bowlingGame.Roll(6);
        RollMany(bowlingGame, 16, 1);
        
        var score = bowlingGame.GetScore();
        Assert.Equal(54, score);
    }

    private static void RollAStrike(BowlingGame bowlingGame)
    {
        bowlingGame.Roll(10);
        bowlingGame.Roll(0);
    }


    private static void RollSpare(BowlingGame bowlingGame)
    {
        bowlingGame.Roll(5);
        bowlingGame.Roll(5);
    }

    private static void RollMany(BowlingGame bowlingGame, int rolls, short pinsKnocked)
    {
        foreach (var i in Enumerable.Range(1, rolls))
        {
            bowlingGame.Roll(pinsKnocked);
        }
    }
}

public class BowlingGame
{
    private List<int> rolls = new();

    public int GetScore()
    {
        var score = 0;
        var roll = 0;
        foreach (var frame in Enumerable.Range(0,10))
        {
            if (IsAStrike(roll))
            {
                var bonusStrike = rolls[roll + 2] + rolls[roll + 3];
                score += 10 + bonusStrike;
            }
            else if (IsSpare(roll))
            {
                score += 10 + bonusSpare(roll);
            }
            score += ScoreOfCurrentFrame(roll);
            roll += 2;
        }
        return score;
    }

    private bool IsAStrike(int roll)
    {
        return rolls[roll] == 10;
    }

    private int ScoreOfCurrentFrame(int roll)
    {
        return rolls[roll] + rolls[roll+1];
    }

    private int bonusSpare(int roll)
    {
        return rolls[roll+2];
    }

    private bool IsSpare(int roll)
    {
        return rolls[roll] + rolls[roll + 1] == 10;
    }

    public void Roll(int pinsKnocked)
    {
        rolls.Add(pinsKnocked);
    }
}