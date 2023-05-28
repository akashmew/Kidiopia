using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class ProfileHandler : MonoBehaviour
{
   
    [SerializeField] TMP_InputField UserText;
    [SerializeField] Button createProfileAndGameStartButton;
    public static string json;

  
    private void Start()
    {
        Assert.IsNotNull(UserText);
        Assert.IsNotNull(createProfileAndGameStartButton);

        createProfileAndGameStartButton.onClick.AddListener(OnCreateProfileClick);
    }

    void OnCreateProfileClick()
    {
        if (UserText.text.Length == 0) return;

        Users newUser = new Users(UserText.text);

        //ScoreAndProfileManager saveObj= new ScoreAndProfileManager( newUser);
        new ScoreAndProfileManager(newUser);
        //Debug.Log(json);

       
        
        SceneManager.LoadScene(1);
    }
}
[System.Serializable]
public class Users
{
    public string name;
    public int score;

    public  Users(string _name, int _score=0)
    {
        name = _name;
        score = _score;
    }
}

public class HighScoreList
{
   public List<Users> UsersList = new List<Users>();
}
