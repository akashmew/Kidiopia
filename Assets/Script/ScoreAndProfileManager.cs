using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ScoreAndProfileManager
{
    const string highScoreList = "/save.txt";
    static string resourcePath;

    public static Users currentUser;
    public static HighScoreList _HighScoreList = new HighScoreList();
    List<Users> Profiles = new List<Users>();

    string jsonText;


    public ScoreAndProfileManager( Users _currentUser)
    {
        resourcePath = UnityEngine.Application.dataPath + highScoreList;
        currentUser = _currentUser;

        if (File.Exists(resourcePath))
        {
            string value = File.ReadAllText(resourcePath);
            _HighScoreList = JsonConvert.DeserializeObject<HighScoreList>(value);
        }
        else
        {

        }
        


    }

    public static void Save()
    {
        _HighScoreList.UsersList.Add(currentUser);
        File.WriteAllText(resourcePath, JsonConvert.SerializeObject(_HighScoreList));
    }
    // Start is called before the first frame update

}
