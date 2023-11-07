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
        TextMesh.SetText(Damage.ToString());
    }
}
