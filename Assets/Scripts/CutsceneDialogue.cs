using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class CutsceneDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] clips;
    [SerializeField] public float textSpeed;
    private int index;
    private Coroutine typeLineCoroutine;
    private bool lineFinshed = true;


    [SerializeField] private AudioSource audioSource;

    void Start()
    {


        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(typeLineCoroutine);
            textComponent.text = lines[Random.Range(0, lines.Length)];
            if (Input.GetMouseButtonDown(0))
            {
                textComponent.text = String.Empty;
                audioSource.Stop();
                lineFinshed = true;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;

        // Stop the previous coroutine before starting a new one
        if (typeLineCoroutine != null)
        {
            StopCoroutine(typeLineCoroutine);
        }

        typeLineCoroutine = StartCoroutine(TypeLine(index));
    }

    IEnumerator TypeLine(int index)
    {
        lineFinshed = false;
        textComponent.text = String.Empty;
        audioSource.PlayOneShot(clips[index]);


        // foreach (char c in lines[shuffledIndexes[index]].ToCharArray())
        foreach (char c in lines[index]) //.ToCharArray()
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // int randomIndex = Random.Range(0, i + 1);

        yield return new WaitForSeconds(2);
        lineFinshed = true;
        // spasitelj = false;
    }

}