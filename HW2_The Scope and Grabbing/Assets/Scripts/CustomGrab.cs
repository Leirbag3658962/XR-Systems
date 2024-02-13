using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // Référence à l'autre main
    CustomGrab otherHand = null;

    // Liste des objets proches
    public List<Transform> nearObjects = new List<Transform>();

    // Objet saisi actuellement
    public Transform grabbedObject = null;

    // Référence à l'action d'entrée
    public InputActionReference action;

    // État de saisie actuel
    bool grabbing = false;

    // Position de l'objet saisi
    public Vector3 grabbedObjectPosition;

    // Rotation de l'objet saisi
    public Quaternion grabbedObjectRotation;

    // Valeur de l'action d'entrée
    public float actionValue;

    void Start()
    {
        // Activer l'action d'entrée
        action.action.Enable();

        // Trouver l'autre main
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    void Update()
    {
        // Obtenir l'état de saisie de l'action d'entrée
        grabbing = action.action.IsPressed();

        // Obtenir la valeur de l'action d'entrée
        actionValue = action.action.ReadValue<float>();

        if (grabbing)
        {
            // Si aucun objet n'est saisi, essayez de saisir un objet proche ou celui dans l'autre main
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                // Obtenir la position et la rotation de l'objet saisi
                grabbedObjectPosition = grabbedObject.position;
                grabbedObjectRotation = grabbedObject.rotation;

                // Appliquer les nouvelles valeurs de position et de rotation à l'objet saisi
                grabbedObject.position = transform.position;
                grabbedObject.rotation = transform.rotation;
            }
        }
        else
        {
            // Si le bouton est relâché, libérer l'objet saisi
            grabbedObject = null;
        }

        // Réinitialiser la liste des objets proches
        nearObjects.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ajouter les objets proches à la liste
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        // Retirer les objets proches de la liste
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }
}
