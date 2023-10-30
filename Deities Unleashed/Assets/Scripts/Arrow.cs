using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float life = 10;
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float impactForce = 40f;

    // Define the tags that the arrow should compare against
    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle"};


    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (string targetTag in targetTags)
        {
            if (collision.gameObject.CompareTag(targetTag))
            {
                EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);
                }
                Destroy(gameObject);
                return; // Exit the loop once we've found a matching tag
            }
        }

        // If no matching tag is found, simply destroy the arrow
        Destroy(gameObject);
    }
}
