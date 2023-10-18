using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    //define the health of our target
    public float health = 100f;
    void Start()
    {
        Debug.Log("Health: " + health);
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Damage Taken: " + amount);
        Debug.Log("Remaining Health: " + health);
        if (health <= 0f)
        {
            Die();
        }
    }


    void Die()
        {
            //destroy a gameobject
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }



