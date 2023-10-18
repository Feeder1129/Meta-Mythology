using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float life = 10;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float impactForce = 40f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
            if (enemyDamageReceiver != null)
            {
                enemyDamageReceiver.TakeDamage(damage);
                Debug.Log("Applied Damage: " + damage);
            }
        }

        Destroy(gameObject);
    }


}
