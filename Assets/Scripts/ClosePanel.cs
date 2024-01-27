using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }
}
