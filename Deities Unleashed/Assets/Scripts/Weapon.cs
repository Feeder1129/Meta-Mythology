using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
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

    void SwitchToCrossbow()
    {
        SwitchWeapon(0);
    }

    void SwitchToSword()
    {
        SwitchWeapon(1);
    }

    // Add a function to switch to Sword2
    void SwitchToSword2()
    {
        SwitchWeapon(2);
    }

    // Add a function to switch to Spear
    void SwitchToSpear()
    {
        SwitchWeapon(3);
    }

    void SwitchToBow()
    {
        SwitchWeapon(4);
    }

    // A generic function to switch to a weapon
    void SwitchWeapon(int newIndex)
    {
        equipSound.Play();
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = newIndex;
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];
    }
}
