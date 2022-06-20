using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CrystalBlocks : MonoBehaviour
{

    [SerializeField] private int _crystalHealth;
    [SerializeField] private ParticleSystem _destroyEffect;
     private int _scoreAddCrystal;


    private void Start()
    {
        PlayerPrefs.GetInt("score");
        switch (PlayerPrefs.GetInt("crystailScore"))
        {
            case 0:
                {
                    _scoreAddCrystal = Random.Range(0, 50);
                    Debug.Log($"{_scoreAddCrystal} Очков");
                    break;
                }
            case 1:
                {
                    _scoreAddCrystal = Random.Range(50, 100);
                    Debug.Log($"{_scoreAddCrystal} Очков");
                    break;
                }
            case 2:
                {
                    _scoreAddCrystal = Random.Range(100, 150);
                    Debug.Log($"{_scoreAddCrystal} Очков");
                    break;
                }
        }
    }

    public void OndamegeCrystal(int damage)
    {
        _crystalHealth -= damage;
        SoundManager.instance.OnSoundEffect("Hit");
        Break();
        if (_crystalHealth <= 0)
        {
            Score.instance.AddScore(_scoreAddCrystal);
            Destroy(gameObject);
        }
    }

    public void Break()
    {
        ParticleSystemRenderer render = Instantiate(_destroyEffect,
                                                    _destroyEffect.transform.position = new Vector3(1.62f, -0.55f, -4.36f),
                                                    transform.localRotation).GetComponent<ParticleSystemRenderer>();
        render.material.color = Color.red;     
    }
}
