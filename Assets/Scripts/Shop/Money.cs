using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public static int money;
    public TMP_Text moneyText;


    private void Update()
    {
        money = PlayerPrefs.GetInt("score");
        moneyText.text = money.ToString();
    }
}
