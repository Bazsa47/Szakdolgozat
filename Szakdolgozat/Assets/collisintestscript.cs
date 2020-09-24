using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisintestscript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision occured: " + other.other.name);
    }
}
