using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class ScoreSaveSystem : MonoBehaviour
{
    public int scoreValue = 0;
    public Text scoreText;
    public string KeyName;
    public string[] scores;
    public string[] names;

    //temp variables for reading keys
    private string ti;
    private string tn;

    //User Name Input
    public InputField iField;
    public string myName;
   

    // Start is called before the first frame update
    void Awake()
    {
        ScoreCheck();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();
        if(Input.GetKey(KeyCode.Space)){
            scoreValue += 10;
        }
        //SetInt(KeyName, scoreValue); 
    }

    public void SetName()
    {
        myName = iField.text;
    }

    void ScoreCheck()
    {
        names = new string[10];
        scores = new string[10];

        
        Array.Clear(scores, 0, scores.Length);
        Array.Clear(names, 0, names.Length);

        //get scores and names and put them in an array
        for (int i = 0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey("score" + i.ToString()) == true)
            {
                ti = (PlayerPrefs.GetInt("score" + i.ToString())).ToString();
                ti.ToString();
                scores[i] = ti;
                Debug.Log(ti);
            }
            if(PlayerPrefs.HasKey("name" + i.ToString()) == true)
            {
                tn = (PlayerPrefs.GetString("name" + i.ToString())).ToString();
                names[i] = tn;
                Debug.Log(tn);
            }
        }

        SortBoard();
    }

    void ScoreWrite()
    {
        for (int i = 0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey("score" + i.ToString()) == false)
            {
                PlayerPrefs.SetInt("score" + i.ToString(), scoreValue);
            }
            if(PlayerPrefs.HasKey("name" + i.ToString()) == false)
            {
                PlayerPrefs.SetString("name" + i.ToString(), myName);
                i = 100;
            }
        }

        ScoreCheck();
    }

    void SortBoard()
    {
        Array.Sort(scores, names);
        Debug.Log(scores[0]);
        Array.Reverse(scores);
        Array.Reverse(names);
    }

    public void FinishScore()
    {
        ScoreCheck();
        ScoreWrite();
        scoreValue = 0;
    }
}