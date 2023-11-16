using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int items { get; private set; }

    public void Collected()
    {
        items++;
    }
}
