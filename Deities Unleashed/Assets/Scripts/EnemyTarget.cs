using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public CharacterLevelSystem CS;
    public int Level;
    public float Health;
    public float MinDmg;
    public float MaxDmg;
    public float Defense;

    // Define the health of our target

    private int minLevel = 1;
    private int maxLevel = 25;



    void Start()
    {
        Debug.Log("Health: " + Health);
        // Ensure CS is not null
        if (CS != null)
        {
            // Calculate the minimum value for the random level
            int min = Mathf.Max(minLevel, CS.currentLevel - 1);  // Minimum level is 1 or current level - 1, whichever is higher

            // Calculate the maximum value for the random level
            int max = Mathf.Min(CS.currentLevel + 1, maxLevel);  // Maximum level is current level + 1 or the maximum level, whichever is lower

            // Generate a random level within the updated range
            int MonsterLvl = Random.Range(min, max + 1);  // Adding 1 to max to make it inclusive

            // Assign the generated level to currentLevel
            Level = MonsterLvl;

            int lvl = CS.currentLevel;

            if (lvl < 9)
            {
                if (Level == 9)
                {
                    Level -= 1;
                }
                StatsStg1();
            }
            else if (lvl < 17)
            {
                StatsStg2();
            }
        }
    }

    void StatsStg1()
    {
        string objectTag = gameObject.tag;

        if (objectTag == "Tiyanak")
        {
            Health = 35f + (5f * Level);
            MinDmg = 2f + (2f * Level);
            MaxDmg = 10f + (5f * Level);
            Defense = 2f + (2f * Level);
        }
        else if (objectTag == "BalBal")
        {
            Health = 55f + (5f * Level);
            MinDmg = 10f + (2f * Level);
            MaxDmg = 15f + (5f * Level);
            Defense = -1f + (1f * Level);
        }
        else if (objectTag == "TikTik")
        {
            Health = 45f + (5f * Level);
            MinDmg = 6f + (2f * Level);
            MaxDmg = 10f + (5f * Level);
            Defense = 4f + (2f * Level);
        }
    }

    void StatsStg2()
    {
        string objectTag = gameObject.tag;

        if (objectTag == "Phoenix")
        {
            Health = 60f;
            MinDmg = 15f;
            MaxDmg = 20f;
            Defense = 5f;
        }
    }

    public void TakeDamage(float amount)
    {
        // Deduct health based on the amount of damage taken
        Health -= amount;
        Debug.Log("Damage Taken: " + amount);
        Debug.Log("Remaining Health: " + Health);
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the game object when health reaches zero
        Destroy(gameObject);
        Debug.Log("Dead");
    }
}