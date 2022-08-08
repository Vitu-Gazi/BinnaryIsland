using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private int gameTime;
    [SerializeField] private int panicTime;
    [SerializeField] private int timeStep = 1;

    private int currentTime;

    public static Action StartPanicTime;


    private void Start()
    {
        StartGameController.Instance.StartTheGame += SetTimer;

        currentTime = gameTime;
        timeText.text = currentTime.ToString();
    }
    private void OnDisable()
    {
        StartGameController.Instance.StartTheGame -= SetTimer;
    }


    private void SetTimer (CharacterState characterState)
    {
        if (characterState == CharacterState.ACTIVE)
        {
            StartCoroutine(GoTimer());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator GoTimer ()
    {
        yield return new WaitForSeconds(timeStep);

        currentTime -= timeStep;
        timeText.text = currentTime.ToString();

        if (panicTime == currentTime)
        {
            StartPanicTime?.Invoke();
        }
        if (currentTime <= 0)
        {
            EndGameController.Instance.EndGame(false);
        }
        else
        {
            StartCoroutine(GoTimer());
        }
    }
}
