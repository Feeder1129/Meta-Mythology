using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Popup : MonoBehaviour
{
    private TextMeshPro TextMesh;
    private void Awake()
    {
        TextMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int Damage)
    {
        if (Damage > 800)
        {
            TextMesh.SetText("CRIT");
        }
        else
        {
            TextMesh.SetText(Damage.ToString());
        }
        }

        public void Lvl(int Level)
    {
        // Set the text
        TextMesh.SetText("LVL. " + Level.ToString());
        // Flip the TextMesh sideways by changing the local scale
        transform.localScale = new Vector3(-1f, 1f, 1f);

    }

}
