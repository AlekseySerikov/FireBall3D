using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject _panelSelect;
    [SerializeField] private GameObject [] _battons;



    public void OpenLevelSelect()
    {
        for (int i = 0; i < _battons.Length; i++)
        {
            _panelSelect.SetActive(true);
            _battons[i].SetActive(false);
        }
    }

    public void BackInMenu()
    {
        for (int i = 0; i < _battons.Length; i++)
        {
            _panelSelect.SetActive(false);
            _battons[i].SetActive(true);
        }
    }


    public void LevelSwitched(int level)
    {
        SceneManager.LoadScene(level);
    }

}
