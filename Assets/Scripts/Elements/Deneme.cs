using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MapObjects"))
        {
            print("triggered");
        }
        else
        {
            print(other.tag);
        }
    }
}
