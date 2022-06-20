using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Transform _builderPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Crystal [] _cristal;
    [SerializeField] private Color[] _colors;
    private int _randnumb;
    private int nextrotation = 1;
    private int chois;
    private List<Block> _blocks;

    private void Awake()
    {
        _randnumb = Random.Range(0, 3);
        PlayerPrefs.SetInt("crystailScore", _randnumb);
    }
    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _builderPoint;

            for (int i = 0; i < _towerSize; i++)
            {
                Block newBlock = BuildBock(currentPoint);
                newBlock.transform.rotation = Quaternion.Euler(0, nextrotation++ * 5, 0);
                newBlock.SetColor(_colors[chois]);              
                _blocks.Add(newBlock);
                currentPoint = newBlock.transform;
            if (i >= _towerSize-1)
            {
                Instantiate(_cristal[_randnumb], GetBuildPoint(currentPoint), Quaternion.identity);
            }
            chois++;
            if (chois >= 2)
            {
                chois = 0;
            }         
        }        

        return _blocks;
    }
    private Block BuildBock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity);
    }

    private Vector3 GetBuildPoint(Transform currentSegmemt)
    {
        return new Vector3(_builderPoint.position.x, currentSegmemt.position.y + currentSegmemt.localScale.y / 2 + _block.transform.localScale.y / 2,_builderPoint.position.z);
    }
    public int OnTowerStartSize()
    {
        return _towerSize;
    }
}
