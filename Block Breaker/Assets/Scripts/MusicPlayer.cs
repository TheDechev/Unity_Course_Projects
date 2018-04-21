using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject); //actually means calling the DontDestroyOnLoad and using it on the gameObject (music Player in this case)
        }
    }

	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
