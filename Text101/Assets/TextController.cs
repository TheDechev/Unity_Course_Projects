using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
    public enum States {startPoint, holdingBook, bookScratch, bookExamine, bookRead, crackExamine_0, crackExamine_1, crackPunch_0, crackPunch_1, preWin, playerWon_0, playerWon_1 };

    private States playerState;

    public Text text;

	void Start () {
        playerState = States.startPoint;
    }

    void Update()
    {
        if (playerState == States.startPoint) { startState(); }
        else if (playerState == States.bookExamine) { bookExamine(); }
        else if (playerState == States.crackExamine_0 || playerState == States.crackExamine_1) { crackExamine(); }
        else if (playerState == States.bookScratch) { bookScratch(); }
        else if (playerState == States.bookRead) { bookRead(); }
        else if (playerState == States.holdingBook) { holdingBook(); }
        else if (playerState == States.crackPunch_0) { crackPunch_0(); }
        else if (playerState == States.crackPunch_1) { crackPunch_1(); }
        else if (playerState == States.playerWon_0) { blackScreen(); }
        else if (playerState == States.playerWon_1) { winningScreen(); }
        else if (playerState == States.preWin) { preWin(); }

    }

    #region statesMethodRegion

    void startState() // also the first room
    {
        

        text.text = "You are in huge white room. Everything seems the same. The walls, the ceiling, the floor, everything is white! \n " +
                  "But before you start to panic, you notice a tiny crack in the wall in front of you, and a white book on the floor. \n\n " +
                  "Press <C> to examine the crack or press <B> to examine the book";

        if (Input.GetKeyDown(KeyCode.B)) { playerState = States.bookExamine;   }
        else if (Input.GetKeyDown(KeyCode.C)) { playerState = States.crackExamine_0; }
    }

    void bookExamine()
    {


        text.text = "You slowly approach the book, and notice that the book is covered in white paint \n\n" +
                    "Press <S> to scratch off the paint from the book or press <R> to read it's pages or press <T> to take it ";

        if (Input.GetKeyDown(KeyCode.S)) { playerState = States.bookScratch; }
        else if (Input.GetKeyDown(KeyCode.R)) { playerState = States.bookRead; }
        else if (Input.GetKeyDown(KeyCode.T)) { playerState = States.holdingBook; }

    }

    void bookScratch()
    {
        text.text = "Scratching off the paint reveals the title : \"The book.\" \n " +
                    "Dissapointed and frustrated you decide: \n\n" +
                    "Press <T> to throw away the book, or <B> to re-examine it.";

        if (Input.GetKeyDown(KeyCode.T)) { playerState = States.startPoint; }
        else if (Input.GetKeyDown(KeyCode.B)) { playerState = States.bookExamine; }

    }

    void bookRead()
    {


        text.text = "You notice that the book is almost empty, except one page. \n" +
                    "This page might be the only hope you'll have, so you quickly rush to read it! \n" +
                    "Unfortunately the only thing written is : \"Darkness is the key to a true light\" \n" +
                    "Confused and angry you decide to: \n\n " +
                    "press <T> to throw the book away or press <K> to keep holding it";

        if (Input.GetKeyDown(KeyCode.T)) { playerState = States.startPoint; }
        else if (Input.GetKeyDown(KeyCode.K)) { playerState = States.bookExamine; }

    }



    void crackExamine()
    {


        text.text = "Slowly approaching the crack you realise that all of the room's light is coming from the crack \n" +
                    "You cover parts of the crack with your hand and the room gets frighteningly dark. \n\n" +
                    "Press <P> to punch the crack, press <B> to go back ";

        if (Input.GetKeyDown(KeyCode.P)) {
            if (playerState == States.crackExamine_1)
            {
                playerState = States.crackPunch_1;
            }
            else
            {
                playerState = States.crackPunch_0;
            }
                }
        else if (Input.GetKeyDown(KeyCode.B)) { playerState = States.holdingBook; }

    }

    void crackPunch_0()
    {
        text.text = "The crack stays the same no matter how hard you try punching it. \n" +
                    "So you start kicking it, yet.. The crack remains the same size and undamaged. \n\n" +
                    "Press <P> to keep punching it, press <C> to re-examine the crack, press <B> to go back. ";

        if (Input.GetKeyDown(KeyCode.P)) { playerState = States.crackPunch_0; }
        else if (Input.GetKeyDown(KeyCode.C)) { playerState = States.crackExamine_0; }
        else if (Input.GetKeyDown(KeyCode.B)) { playerState = States.startPoint; }
    }

    void crackPunch_1()
    {
        text.text = "The crack stays the same no matter how hard you try punching it. \n" +
                    "So you start kicking it, yet.. The crack remains the same size and undamaged. \n" +
                    "But wait.. you realize that the crack forms a weird shape.. almost like YOUR BOOK! \n" +
                    "Quickly without even thinking you slowly cover the crack with the book, when suddenly..";


        playerState = States.preWin;
    }

    void preWin()
    {
        text.text = "The room gets DARK!" +
                    "You can't see the book, you can't see the crack, you can't even see yourself, NOTHING! \n" +
                    "Before you panic you realize the room trembles, and slowly it gets stronger and stronger when all of a sudden.. \n" +
                    "Everything colapses, and ...";
        if (!Input.GetKeyDown(KeyCode.Escape)) { playerState = States.playerWon_0; }
        else { playerState = States.startPoint; }
        
    }


    void blackScreen()
    {
        text.text = "";
        if (!Input.GetKeyDown(KeyCode.Escape)) { playerState = States.playerWon_1; }
        else { playerState = States.startPoint; }
        playerState = States.playerWon_1;
    }

    void winningScreen()
    {
        text.text = "Congratulations you made it out of the room, you're free! \n" +
                    "I know you had it in you, well done!";
    }

    void holdingBook()
    {


        text.text = "Holding the book relentlessly, you start wondering how the hell did you end up here. \n" +
                    "But the white light is so bright, that you're barely able to concentrate for a moment \n" +
                    "So you decide to take control of the situation and get out of here! \n\n" +
                    "Press <T> to throw the book, or press <C> to examine the crack. ";

        if (Input.GetKeyDown(KeyCode.T)) { playerState = States.startPoint; }
        else if (Input.GetKeyDown(KeyCode.C)) { playerState = States.crackExamine_1; }

    }

    #endregion

}
