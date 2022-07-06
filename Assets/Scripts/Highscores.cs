using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    [SerializeField] private Text highscoresText;
    private int[] highscores = {0, 0, 0, 0, 0};

    private void Awake()
    {
        LoadData();
        highscoresText.text = "#1 - player - " + highscores[4].ToString("000000") + "\n"
                            + "#2 - player - " + highscores[3].ToString("000000") + "\n"
                            + "#3 - player - " + highscores[2].ToString("000000") + "\n"
                            + "#4 - player - " + highscores[1].ToString("000000") + "\n"
                            + "#5 - player - " + highscores[0].ToString("000000") + "\n";
    }

    public void NewRecord(int score)
    {
        if (score > highscores[0])
        {
            highscores[0] = score;
            Array.Sort(highscores);
            SaveData();
        }
    }

    private void LoadData()
    {
        for (int i = 0; i < 5; i++)
        {
            highscores[i] = PlayerPrefs.GetInt(i.ToString());
        }
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), highscores[i]);
        }
    }
}
