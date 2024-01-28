using System;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public AudioClip[] clips;
    [SerializeField] public float textSpeed;
    private int index;
    public Fixer vocal;
    private bool spasitelj = false;
    private Coroutine typeLineCoroutine;
    private List<int> shuffledIndexes = new List<int>();
    private bool lineFinshed = true;
    // public PlayerCombat playerCombat;
    public static bool lineSay = true;
    

    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        lineSay = true;
        
        textComponent.text = string.Empty;
        // ShuffleIndexes();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartDialogue();
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        // Debug.Log(lineSay);
        if (lineSay == true && lineFinshed)
        {
            NextLine();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(typeLineCoroutine);
            textComponent.text = lines[Random.Range(0, lines.Length)];
            if (Input.GetMouseButtonDown(0))
            {
                textComponent.text = String.Empty;
                audioSource.Stop();
                lineFinshed = true;
                lineSay = false;
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
        lineSay = false;
        lineFinshed = true;
        // spasitelj = false;
    }

    void NextLine()
    {
        index = Random.Range(1, lines.Length);
        
        StartCoroutine(TypeLine(index));
        // index++;
        //
        // // Check if index is within the bounds of the shuffled indexes array
        // if (index < shuffledIndexes.Count)
        // {
        //     spasitelj = true;
        //     typeLineCoroutine = StartCoroutine(TypeLine());
        // }
        // else
        // {
        //     // If index exceeds the array length, you can end the dialogue or loop back to the beginning
        //     // For example, you can set index back to 0: index = 0;
        //     // spasitelj = false;
        // }
    }

    void ShuffleIndexes()
    {
        // Fill a list with the indexes of the lines array
        for (int i = 0; i < lines.Length; i++)
        {
            shuffledIndexes.Add(i);
        }
        
        // Shuffle the list using the Fisher-Yates algorithm
        for (int i = shuffledIndexes.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = shuffledIndexes[i];
            shuffledIndexes[i] = shuffledIndexes[randomIndex];
            shuffledIndexes[randomIndex] = temp;
        }
    }
}