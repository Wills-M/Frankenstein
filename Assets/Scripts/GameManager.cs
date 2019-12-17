using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField]
    private List<string> stanzas;

    [SerializeField]
    private TMPro.TextMeshProUGUI canvas;

    private int stanzaCounter;

    private void Start()
    {
        stanzaCounter = 0;
    }

    public void IncrementPoem()
    {
        stanzaCounter++;
        canvas.text = stanzas[stanzaCounter - 1];
    }
}
