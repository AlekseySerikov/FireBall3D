using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssingSkin : MonoBehaviour
{

    [SerializeField] private GameObject[] _tank;


    private void Start()
    {

        if (PlayerPrefs.GetInt("skinNum") == 0)
        {
            _tank[0].SetActive(true);
            _tank[1].SetActive(false);
            PlayerPrefs.SetInt("currentBullet", 0);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 1)
        {
            _tank[1].SetActive(true);
            _tank[0].SetActive(false);
            PlayerPrefs.SetInt("currentBullet", 1);
        }
        else if (PlayerPrefs.GetInt("skinNum") == 2)
        {
            _tank[2].SetActive(true);
            _tank[1].SetActive(false);
            _tank[0].SetActive(false);
            PlayerPrefs.SetInt("currentBullet", 2);
        }

        else
        {
            _tank[0].SetActive(true);
            PlayerPrefs.SetInt("currentBullet", 0);
        }
    }
}
