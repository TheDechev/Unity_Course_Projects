using UnityEngine;
using System.Collections;

public class LevelManger : MonoBehaviour {

    public void LevelLoad(string levelName)
    {
        Application.LoadLevel(levelName);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void ReturnRequest()
    {
        Application.LoadLevel("Start");
    }
}
