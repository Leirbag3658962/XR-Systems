using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [SerializeField]
    private GameObject Lock;

    private Transform keyCardTransform = null;

    private Vector3 enterPosition;
    private Vector3 exitPosition;

    private bool validSwap;


    public TextMeshProUGUI dotText;
    public TextMeshProUGUI etoText;
    private void Update()
    {
 
        if(keyCardTransform != null)
        {
            Vector3 keyCardUp = keyCardTransform.forward;
            float dot = Vector3.Dot(keyCardUp, Vector3.up);
            dotText.SetText($"DOT: ${dot}");
            if (dot < 0.90)
            {
                validSwap = false;
            }
        }
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        keyCardTransform = args.interactableObject.transform;

        enterPosition = keyCardTransform.position;
        validSwap = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        exitPosition = args.interactableObject.transform.position;
        Vector3 entryToExit = exitPosition - enterPosition;
        etoText.SetText($"ETO: {entryToExit.y}");
        if(validSwap && entryToExit.y < -0.15f)
        {
            Lock.gameObject.SetActive(false);
        }
        keyCardTransform = null;
    }
}
