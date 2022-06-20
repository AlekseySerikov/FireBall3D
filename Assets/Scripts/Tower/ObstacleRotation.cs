using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _directionMove;
    private int amountBlock;


    private void Start()
    {
        Obstacle(_directionMove);
        amountBlock = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    private void Update()
    {
        if (amountBlock == 0)
        {         
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Аргумент меняе направление движения. от -360 до 360
    /// </summary>
    /// <param name="_directionMove"></param>
    private void Obstacle(float _directionMove)
    {
        transform.DORotate(new Vector3(0, _directionMove, 0), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
