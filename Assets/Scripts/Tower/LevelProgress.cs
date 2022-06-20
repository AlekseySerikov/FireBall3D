using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private float _filedDuration;

    private float _towerStartSize;

    private void Awake()
    {
        _towerStartSize = _towerBuilder.OnTowerStartSize();
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _tower.SizeUpdated += OnTowerSizeUpdate;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnTowerSizeUpdate;
    }

    private void OnTowerSizeUpdate(int size)
    {
        if (size != _towerStartSize)
        {
            _slider.DOValue((_towerStartSize - size) / _towerStartSize,_filedDuration);
        }   
    }

  
}
