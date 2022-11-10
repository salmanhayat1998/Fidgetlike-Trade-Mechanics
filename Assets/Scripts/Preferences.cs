using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : SingeltonBase<Preferences>
{
    [SerializeField]
    private int DefaultMoney=500;
    private int _levels;
    private int _score;
    private int _isfirstTime;
    public int Levels
    {
        get
        {
            return  _levels;
        }
        set
        {
            _levels = value;
            Save("Levels", _levels);
        }
    }
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            Save("Score", _score);
         
        }
    }
    public int isfirstTime
    {
        get
        {
            return _isfirstTime;
        }
        set
        {
            _isfirstTime = value;
            Save("isfirstTime", _isfirstTime);
         
        }
    }



    public override void Awake()
    {
        base.Awake();
        _levels = PlayerPrefs.GetInt("Levels", 0);
        _isfirstTime = PlayerPrefs.GetInt("isfirstTime", 0);
        _score = PlayerPrefs.GetInt("Score", DefaultMoney);
       
    }


    private void Save(string PrefKey, int value)
    {
        PlayerPrefs.SetInt(PrefKey, value);
    }
    private void Save(string PrefKey, float value)
    {
        PlayerPrefs.SetFloat(PrefKey, value);
    }
}
