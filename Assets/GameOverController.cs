using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Assertions;
using System;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerText;
    [SerializeField] TextMeshProUGUI PlayerScore;
    [SerializeField]TextMeshProUGUI HighestScore;
    [SerializeField]Button PlayAgain;

    private void Start()
    {
        Assert.IsNotNull(PlayerText);
        Assert.IsNotNull(PlayerScore);
        Assert.IsNotNull(HighestScore);
        Assert.IsNotNull(PlayAgain);

        CheckScoreAndDisplay(ScoreAndProfileManager.currentUser);
        PlayAgain.onClick.AddListener(OnPlayAgainClicked);
    }

    private void OnPlayAgainClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void CheckScoreAndDisplay(Users currentUser)
    {
        List<int> usersScoreWithSameName = new List<int>();
        foreach(Users u in ScoreAndProfileManager._HighScoreList.UsersList)
        {
            if(u.name.ToLower() == currentUser.name.ToLower())
            {
                usersScoreWithSameName.Add(u.score);
            }
        }
        if(usersScoreWithSameName.Count != 0)
        {
            usersScoreWithSameName.Sort();
            HighestScore.text = usersScoreWithSameName[usersScoreWithSameName.Count - 1].ToString();
        }
        else
        {
            HighestScore.text = currentUser.score.ToString();
        }

        PlayerText.text = currentUser.name;
        PlayerScore.text = currentUser.score.ToString();
        
    }
}
