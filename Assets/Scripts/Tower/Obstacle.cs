using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int _amount;

    private void Update()
    {
        _amount = GameObject.FindGameObjectsWithTag("Block").Length;
        if (_amount == 0)
        {
            Obstacle.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.instance.OnSoundEffect("Obstacle");
    }
}
