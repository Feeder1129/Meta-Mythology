using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public Shoot shoot;

    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;
    public Button SwitchButton;
    private int currentWeapon = 1;

    void Start()
    {
        // Find the SwitchButton by its name and attach the OnSwitchButtonClick method to its click event
        SwitchButton = GameObject.Find("SwitchBtn").GetComponent<Button>();
        SwitchButton.onClick.AddListener(OnSwitchButtonClick);

        // Initially equip the first weapon
        Equip1();
    }

    void OnSwitchButtonClick()
    {
        // Handle the button click event to switch weapons
        currentWeapon = (currentWeapon == 1) ? 2 : 1;


        // Equip the appropriate weapon based on the currentWeapon value
        switch (currentWeapon)
        {
            case 1:
                Equip1();
                break;
            case 2:
                Equip2();
                break;
        }
    }

    void Equip1()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        shoot.SetCanShoot(true); // Allow shooting with this weapon
    }

    void Equip2()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        shoot.SetCanShoot(false); // Prevent shooting with this weapon
    }
}
