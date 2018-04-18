using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
    public Text guessText;
    int guessNumber;
    int min;
    int max;
    public int maxGuessesAllowed = 20;
	
	void Start () {
        startGame();
        guessText.text = guessNumber.ToString();
    }
	
	// Update is called once per frame
    void startGame()
    {
        guessNumber = Random.Range(0, 10001);
        min = 0;
        max = 10000;
    }

    public void guessHigher()
    {
        min = guessNumber;
        nextGuess();
    }

    public void guessLower()
    {
        max = guessNumber;
        nextGuess();
    }

    void nextGuess()
    {
        guessNumber = Random.Range(min, max + 1);
        guessText.text = guessNumber.ToString();
        maxGuessesAllowed -= 1;

        if (maxGuessesAllowed <= 0)
        {
            Application.LoadLevel("Win");
        }
    }


}
