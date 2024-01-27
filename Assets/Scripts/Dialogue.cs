using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] audioClips;
    public float textSpeed;
    public float delayBetweenDialogues = 10f; // Adjust as needed

    private int index = 0;
    private bool lineFinished = true;
    public bool dialogueTriggered = false;

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    void Update()
    {
        // Check if the dialogue has been triggered and the line has finished
        if (dialogueTriggered && lineFinished)
        {
            TriggerDialogue();
        }
    }

    // Call this method to trigger the dialogue
    public void TriggerDialogue()
    {
        if(index < lines.Length-1) 
        {
            index++;
        }
        else
        {
            index = 0;
        }
        StartCoroutine(DialogueSequence());
    }

    IEnumerator DialogueSequence()
    {
        

        while (dialogueTriggered)
        {
            StartDialogue();
            yield return new WaitForSeconds(delayBetweenDialogues);
        }
    }

    void StartDialogue()
    {
        
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        lineFinished = false;
        textComponent.text = string.Empty;
        audioSource.clip = audioClips[index];
        audioSource.Play();

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(10);

        lineFinished = true;
    }
}
