using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private int _AddScore;
    [SerializeField] private float passingTime;
    [SerializeField] private int multiplication;
    public event UnityAction<Block> BulletHit;

    private MeshRenderer _meshRender;

    private void Awake()
    {
        _meshRender = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        _meshRender.material.color = color;
    }
    private void OnDestroy()
    {
        SoundManager.instance.OnSoundEffect("Hit");
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer render = Instantiate(_destroyEffect,
                                                    _destroyEffect.transform.position = new Vector3(0,0.7f,0),
                                                    transform.localRotation).GetComponent<ParticleSystemRenderer>();
        render.material.color = _meshRender.material.color;
        Destroy(gameObject);
    }
}
