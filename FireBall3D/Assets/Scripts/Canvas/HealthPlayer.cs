using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer instance = null;

    public int _health;

    public int numOfHearts;
    //Массив спрайтов сердец
    public Image[] hearts;
    //Спрайт полного сердечка
    public Sprite fullHeart;
    //Спрайт пустого сердечка
    public Sprite empityHeart;

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
    private void Update()
    {
        if (_health > numOfHearts)
        {
            _health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(_health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = empityHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

    
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

}
