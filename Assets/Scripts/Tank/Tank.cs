using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet [] _bullet;
    [SerializeField] private Transform _bulletTemplate;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private float _recoilDistance;
    private int _currentBullet;
    private GameObject[] BulletLenght;

    private float _timeAfterShoot;

    private int amount;
    private int crystal;

    private void Start()
    {
        _currentBullet = PlayerPrefs.GetInt("currentBullet");
    }
    private void Update()
    {

        amount = GameObject.FindGameObjectsWithTag("Block").Length;
        crystal = GameObject.FindGameObjectsWithTag("Crystal").Length;

        _timeAfterShoot += Time.deltaTime;


        if (_timeAfterShoot > _delayBetweenShoot)
        {
            if (Input.GetMouseButton(0))
            {
                    Shoot();
                    _timeAfterShoot = 0;
                    transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);               
            }
        }
        if (HealthPlayer.instance._health == 0)
        {
            Destroy(gameObject);
        }
        if (amount == 0 && crystal == 0)
        {
            Destroy(gameObject);
            Destruction();
        }
    }


    private void Destruction()
    {
        BulletLenght = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < BulletLenght.Length; i++)
        {
            Destroy(BulletLenght[i]);
        }
    }
    private void Shoot()
    {
        Instantiate(_bullet[_currentBullet], _bulletTemplate.position, Quaternion.identity);
    }

}
