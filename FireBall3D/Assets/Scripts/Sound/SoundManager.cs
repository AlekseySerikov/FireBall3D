using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource _hitBlock;
    [SerializeField] private AudioSource _hitObstacle;
    [SerializeField] private AudioSource []  _musikBackground;
    [SerializeField] private AudioSource _complitelevel;
    private int ChoisMusikBackGround = 0;

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
        ChoisMusikBackGround = Random.Range(0, 3);
    }
    private void Start()
    {
        
        _musikBackground[ChoisMusikBackGround].Play();
    }


    public void OnSoundEffect(string numbAudio)
    {
            switch (numbAudio)
            {
                case "Hit":
                    {
                    _hitBlock.pitch = (Random.Range(0.8f, 1));
                    _hitBlock.Play();
                        break;
                    }
                case "Obstacle":
                    {
                        _hitObstacle.Play();
                        break;
                    }
                case "MusikBack":
                    {
                        _musikBackground[ChoisMusikBackGround].volume -= 0.2f * Time.deltaTime;                 
                        break;
                    }
        }     
    }
}
