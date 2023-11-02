using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float life = 10;
    [SerializeField] int minDamage = 5; // Minimum damage
    [SerializeField] int maxDamage = 15; // Maximum damage
    [SerializeField] float range = 100f;
    [SerializeField] float impactForce = 40f;

    // Define the tags that the arrow should compare against
    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle" };

    private bool damageApplied = false; // Flag to track if damage has already been applied

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if damage has already been applied
        if (damageApplied)
            return;

        // Generate a random damage value between minDamage and maxDamage
        int damage = Random.Range(minDamage, maxDamage + 1); // +1 to include the maximum value

        // Generate a random number between 1 and 10 for critical hit
        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical:" + criticalRoll);
        // Check for a critical hit (e.g., if the roll is 5, add 1000 damage)
        if (criticalRoll == 5)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        foreach (string targetTag in targetTags)
        {
            if (collision.gameObject.CompareTag(targetTag))
            {
                EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);
                    damageApplied = true; // Set the flag to true to indicate damage has been applied
                }
                Destroy(gameObject);
                return; // Exit the loop once we've found a matching tag
            }
        }

        // If no matching tag is found, simply destroy the arrow
        Destroy(gameObject);
    }
}