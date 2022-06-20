using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceDistance;
    [SerializeField] private int damage;


    public event UnityAction<Obstacle> OnDamage; 

    private Vector3 _moveDirection;


    private void Start()
    {
        _moveDirection = Vector3.forward;
    }


    private void Update()
    {
        transform.Translate(_moveDirection * _speedBullet * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out Obstacle obstacle))
        {       
            Bounce();
        }
        if (other.TryGetComponent(out GreenBullet greenBullet))
        {
            if (PlayerPrefs.GetInt("currentBullet") == 1)
            {
                greenBullet.DestructionObjectGreen();
                Debug.Log("Green");
            }
            else
            {
                Bounce();
            }
        }
        if (other.TryGetComponent(out YellowBullet yellowBullet))
        {
            if (PlayerPrefs.GetInt("currentBullet") == 2)
            {
                yellowBullet.DestructionObjectYellow();
                Debug.Log("Yellow");
            }
            else
            {
                Bounce();
            }
        }
        if (other.TryGetComponent(out CrystalBlocks crystal))
        {
            crystal.OndamegeCrystal(1);
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out HealthPlayer player))
        {
            HealthPlayer.instance.TakeDamage(damage);
        }
      
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, 0.5f, 1), _bounceDistance);
    }
}
