using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _panelDeath;
    [SerializeField] private GameObject _nextLevel;
    [SerializeField] private Animator _animation;
    [SerializeField] private InterstitialAds _ad;

    private int amount;
    private int crystal;

    private void Start()
    {
           
    }
    private void Update()
    {
        amount = GameObject.FindGameObjectsWithTag("Block").Length;
        crystal = GameObject.FindGameObjectsWithTag("Crystal").Length;

        if (amount == 0 && crystal == 0)
        {
            SoundManager.instance.OnSoundEffect("MusikBack");
            OnAnimDeath();
            StartCoroutine(DelayPanel(0.5f, _nextLevel));
        }
        if (HealthPlayer.instance._health == 0)
        {
            //_ad.ShowAd();
            StartCoroutine(DelayPanel(0,_panelDeath));     
        }
    }
    private IEnumerator DelayPanel(float delay,GameObject panel)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(true);
    }
    public void OnAnimDeath()
    {
        _animation.SetTrigger("Death"); 
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SettingMenu()
    {
        LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
