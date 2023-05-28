using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using System;

public class UiHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public static int scoreVal;
    [SerializeField]Image gameOver;
    public static UnityEvent HandleUI = new UnityEvent();
    public static UnityEvent HandleUI2 = new UnityEvent();
    private void Awake()
    {
        scoreText.text = "0";
        scoreVal = 0;
        HandleUI.AddListener(UiScoreUpdate);
        HandleUI2.AddListener(OnGameover);
    }

    private void OnGameover()
    {
        gameOver.gameObject.SetActive(true);
        SceneManager.LoadScene(2);
        ScoreAndProfileManager.currentUser.score = scoreVal;
        ScoreAndProfileManager.Save();
    }

    // Start is called before the first frame update

    void UiScoreUpdate()
    {
        scoreVal++;
        scoreText.text = scoreVal.ToString();
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
