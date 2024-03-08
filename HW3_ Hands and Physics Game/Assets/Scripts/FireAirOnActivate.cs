using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireAirOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float firespeed = 20;
    

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireAir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireAir(ActivateEventArgs arg)
    {
        GameObject Air = Instantiate(bullet);
        Air.transform.position = spawnpoint.position;
        Air.GetComponent<Rigidbody>().velocity = spawnpoint.forward * firespeed;
        Destroy(Air, 3);
    }
}
