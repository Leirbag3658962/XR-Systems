using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorLight : MonoBehaviour
{
    public Light light;
    public InputActionReference action;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (light.color == Color.white)
            {
                light.color = Color.green;
            }
            else if (light.color == Color.green)
            {
                light.color = Color.blue;
            }
            else if (light.color == Color.blue)
            {
                light.color = Color.red;
            }
            else if (light.color == Color.red)
            {
                light.color = Color.white;
            }
        };
    }
}
