using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public AttackButtonController attackButtonController;

    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;

    public Button CrossBowButton;
    public Button SwordButton;
    public Button Sword2Button;
    public Button SpearButton;
    public Button BowButton;

    public AudioSource equipSound;

    // Start is called before the first frame update
    void Start()
    {
        equipSound = GetComponent<AudioSource>();
        CrossBowButton.onClick.AddListener(SwitchToCrossbow);
        SwordButton.onClick.AddListener(SwitchToSword);
        Sword2Button.onClick.AddListener(SwitchToSword2);
        SpearButton.onClick.AddListener(SwitchToSpear);
        BowButton.onClick.AddListener(SwitchToBow);

        attackButtonController = FindObjectOfType<AttackButtonController>();

        if (attackButtonController == null)
        {
            Debug.LogError("AttackButtonController not found in the scene!");
        }

        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for(int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0; 
    }
    //switch to 1st weapon
    void SwitchToCrossbow()
    {
        SwitchWeapon(0);
    }
    //switch to 2nd weapon
    void SwitchToSword()
    {
        SwitchWeapon(1);
    }

    //switch to 3rd weapon
    void SwitchToSword2()
    {
        SwitchWeapon(2);
    }

    //switch to 4th weapon
    void SwitchToSpear()
    {
        SwitchWeapon(3);
    }
    //switch to 5th weapon
    void SwitchToBow()
    {
        SwitchWeapon(4);
    }

    // A generic function to switch to a weapon
    void SwitchWeapon(int newIndex)
    {
        Debug.Log("Switching to weapon: " + newIndex);

        equipSound.Play();
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = newIndex;
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];

        attackButtonController.SwitchAttackButtons(newIndex);

    }
}
