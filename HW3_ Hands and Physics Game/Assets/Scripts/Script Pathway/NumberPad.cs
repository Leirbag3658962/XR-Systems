using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    public static NumberPad Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI textSequence;
    [SerializeField] private int CorrectSequence = 1234;
    [SerializeField] private GameObject KeyCard;
    [SerializeField] private Transform spawnPoint;

    public Timer timer; 

    private string currentSequence = string.Empty;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }

    public void AddNumberToSequence(int num)
    {
        if (!KeyCard.activeSelf)
        {
            currentSequence += num.ToString();
            textSequence.SetText(currentSequence);
            if (currentSequence.Length == CorrectSequence.ToString().Length)
            {
                if (currentSequence == CorrectSequence.ToString())
                {
                    KeyCard.SetActive(true);
                    currentSequence = "";
                    textSequence.text = "Good code";
                    timer.StopTimer();
                    TeleportAfterDelay(); 
                }
                else
                {
                    textSequence.text = "";
                    currentSequence = "";
                }
            }
        }
    }

    private void TeleportAfterDelay()
    {
        if (spawnPoint != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
        else
        {
            Debug.LogError("Spawn point not assigned!");
        }
    }
}
