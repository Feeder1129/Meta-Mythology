using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;

    // Attach this method to the Bag Button's onClick event in the Unity Editor
    public void OnBagButtonClick()
    {
        // Set the inventory panel to active when the bag button is clicked
        inventoryPanel.SetActive(true);
    }

    // Attach this method to the X Button's onClick event in the Unity Editor
    public void OnCloseButtonClick()
    {
        // Set the inventory panel to inactive when the X button is clicked
        inventoryPanel.SetActive(false);
    }
}
