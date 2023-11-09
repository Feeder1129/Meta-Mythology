using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour
{
    public AudioSource slashSound;

    public GameObject sword;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    public Button swordAttackButton;

    // Reference to the player's level system
    public CharacterLevelSystem CS;

    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle" };

    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        swordAttackButton.onClick.AddListener(OnClickSwordAttack);

        // Find the "Player" GameObject and get the attached "CharacterLevelSystem" script
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            CS = player.GetComponent<CharacterLevelSystem>();
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the GameObject is named 'Player' and has the 'CharacterLevelSystem' script attached.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add additional logic here if needed
    }

    public void OnClickSwordAttack()
    {
        if (canAttack)
        {
            SwordAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("attack");

        int damage = CalculateSwordDamage();
        Debug.Log("Sword Damage: " + damage);

        DealDamage(damage);
    }

    public int CalculateSwordDamage()
    {
        int minDamage = 2 + (3 * CS.currentLevel);
        int maxDamage = 10 + (5 * CS.currentLevel);

        int damage = Random.Range(minDamage, maxDamage + 1);
        Debug.Log("Calculated Damage: " + damage);

        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical Roll: " + criticalRoll);

        if (criticalRoll == 5)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        return damage;
    }

    void DealDamage(int damage)
    {
        // Code for dealing damage to enemies goes here
        // You can add the collision and damage logic here
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
