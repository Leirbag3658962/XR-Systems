using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPadTester : MonoBehaviour
{
    public NumberPad numberPad;

    private void Update()
    {
        // Tester avec le clavier
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            numberPad.AddNumberToSequence(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            numberPad.AddNumberToSequence(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            numberPad.AddNumberToSequence(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            numberPad.AddNumberToSequence(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            numberPad.AddNumberToSequence(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            numberPad.AddNumberToSequence(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            numberPad.AddNumberToSequence(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            numberPad.AddNumberToSequence(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            numberPad.AddNumberToSequence(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            numberPad.AddNumberToSequence(9);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                TouchButton touchButton = hit.collider.GetComponent<TouchButton>();
                if (touchButton != null)
                {
                    touchButton.SendMessage("OnHoverEntered", null, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
