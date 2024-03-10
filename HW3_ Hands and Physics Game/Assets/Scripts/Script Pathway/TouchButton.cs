using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [SerializeField] private int value;
    private NumberPad numberPad;

    private MeshRenderer buttonMeshRenderer;
    private Material baseMaterial;
    [SerializeField] private Material onHoverMaterial;

    protected override void Awake()
    {
        base.Awake();
        buttonMeshRenderer = GetComponent<MeshRenderer>();
        baseMaterial = buttonMeshRenderer.material;
        numberPad = FindObjectOfType<NumberPad>(); 
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        if (numberPad != null)
        {
            numberPad.AddNumberToSequence(value);
            buttonMeshRenderer.material = onHoverMaterial;
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        buttonMeshRenderer.material = baseMaterial;
    }
}
