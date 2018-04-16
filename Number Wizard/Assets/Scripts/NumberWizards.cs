using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {
    int guessNumber;
    int min;
    int max;

	// Use this for initialization
	void Start () {
        print("Welcome to the guess game!");
        print("If you'd like to restart the game at anytime, press R");
    }
	
	// Update is called once per frame
    void startGame()
    {
        guessNumber = Random.Range(0, 10000);
        min = 0;
        max = 10000;
        print("============================================\n");
        print("Press <Up> for higher --- Press <Down> for higher --- Press <Enter> to end ");
        print("============================================\n");
        print("Is this your number: " + guessNumber + " ? or is it higher or lower ?");
        
    }

    void guessFunc()
    {
        guessNumber = (max + min) / 2;
        print("Is this your number: " + guessNumber + " ? or is it higher or lower ?");
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guessNumber;
            guessFunc();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))

        {
            max = guessNumber;
            guessFunc();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Yay, I guessed it!\n");
            print("============================================\n");

        } else if (Input.GetKeyDown(KeyCode.R))
        {
            startGame();
        }
    }
}
