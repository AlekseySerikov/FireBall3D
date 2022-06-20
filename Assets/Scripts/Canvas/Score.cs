using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance = null;
    [SerializeField] private TMP_Text _ScoreText;
    [SerializeField] private int _score;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _ScoreText.text = "" + PlayerPrefs.GetInt("score").ToString();
    }


    public void AddScore(int amount)
    {
        _score += amount;
        _score += PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", _score);
        _ScoreText.text = "" + _score.ToString();
    }
}
