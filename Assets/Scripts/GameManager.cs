using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField]
    private List<string> stanzas;

    [SerializeField]
    private TextMeshProUGUI pageTmp;

    [SerializeField]
    private Image blackScreen;

    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

    [SerializeField]
    private PlayableDirector pageDirector;

    [SerializeField]
    private float introTime;

    [SerializeField]
    private float timeToRead;

    [SerializeField]
    private float timeToFade;

    [SerializeField]
    private float slowDown;

    [SerializeField]
    private bool playIntro;

    private PlayableDirector introDirector;

    private int stanzaCounter;

    private void Start()
    {
        stanzaCounter = 0;

        introDirector = GetComponent<PlayableDirector>();
        if (playIntro)
            introDirector.Play();
    }

    public void IncrementPoem()
    {
        stanzaCounter++;
        pageTmp.text = stanzas[stanzaCounter - 1];
        pageDirector.Stop();
        pageDirector.Play();

        if (stanzaCounter == stanzas.Count)
            StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        fpsController.WalkSpeed = fpsController.WalkSpeed / slowDown;
        fpsController.RunSpeed = fpsController.RunSpeed / slowDown;

        for (float counter = 0; counter <= timeToRead; counter += Time.deltaTime)
        {
            yield return null;
        }

        for (float counter = 0; counter <= timeToFade; counter += Time.deltaTime)
        {
            Color color = blackScreen.color;
            color.a = counter / timeToFade;
            blackScreen.color = color;
            yield return null;
        }

        Application.Quit();
    }
}
