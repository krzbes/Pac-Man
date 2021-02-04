using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Save 
{
    private string _name;
    private int _points;
    private string _path = "Assets/score.txt";
    private string[] _topScore = new string[10];
    public Save(string name,int points)
    {
        _name = name;
        _points = points;
    }
    public Save()
    {
        LoadTopTen();
    }
    public void SaveScore()
    {
        StreamWriter writer = new StreamWriter(_path, true);
        writer.WriteLine(_name+"\n"+_points);
        writer.Close();
    }
    private void LoadTopTen()
    {
        StreamReader reader = new StreamReader(_path);
        List<Score> topScores = new List<Score>();
        while (!reader.EndOfStream)
        {
            topScores.Add(new Score(reader.ReadLine(), Convert.ToInt32(reader.ReadLine())));
        }
        topScores.Sort();
        int i = 0;
        foreach(Score result in topScores)
        {
            if (i == 10)
            {
                break;
            }
            _topScore[i] = result.ToString(); 
            i++;
        }
    }
    public string GetScore(int i)
    {
        return _topScore[i];
    }
    
}
public class Score : IComparable<Score>
{
    public string _name;
    public int _points;
    public Score(string name, int score)
    {
        _points = score;
        _name = name;
    }
    public int CompareTo(Score compareScore)
    {
        if (this._points < compareScore._points)
            return 1;

        else if (this._points > compareScore._points)
            return -1;
        else
            return 0;
    }
    public override string ToString()
    {
        return _name + " " + _points;
    }
}


