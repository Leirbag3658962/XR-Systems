using UnityEngine;

public class CongratulationsScreenController : MonoBehaviour
{
    public GameObject[] objectsToKeep;

    private void OnEnable()
    {
        DisableAllObjectsInSceneExceptGiven();
    }

    private void OnDisable()
    {
        EnableAllObjectsInScene();
    }

    private void DisableAllObjectsInSceneExceptGiven()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (!IsObjectToKeep(obj))
            {
                obj.SetActive(false);
            }
        }
    }

    private bool IsObjectToKeep(GameObject obj)
    {
        foreach (GameObject objectToKeep in objectsToKeep)
        {
            if (obj == objectToKeep)
            {
                return true;
            }
        }
        return false;
    }

    private void EnableAllObjectsInScene()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            obj.SetActive(true);
        }
    }
}
