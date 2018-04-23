using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    public LevelManger levelManagerObj;

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelManagerObj.LevelLoad("Win Screen");
    }
}
