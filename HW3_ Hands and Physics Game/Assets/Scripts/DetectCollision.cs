using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Renderer>().material.name == "Bubblematerial")
        {
            Destroy(other);
        }
    }
}
