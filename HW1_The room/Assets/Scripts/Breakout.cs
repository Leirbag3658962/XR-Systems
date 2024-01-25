using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Breakout : MonoBehaviour
{
    public InputActionReference action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (transform.position == new Vector3(0, 0, 0))
            {
                transform.Translate(new Vector3(0, 12.9f, -5.3f));
            }
            else if (transform.position == new Vector3(0, 12.9f, -5.3f))
            {
                transform.Translate(new Vector3(-14.7f, 15f, 19.4f));
                transform.Rotate(new Vector3(0, 135, 0));
            }
            else if (transform.position == new Vector3(-14.7f, 15f, 19.4f))
            {
                transform.Translate(new Vector3(0, 0, 0));
                transform.Rotate(new Vector3(0, 0, 0));
            }
        };
    }
}
