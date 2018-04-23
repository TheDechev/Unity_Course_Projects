using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Paddle paddleObj;
    private bool hasStarted = false; 
    private Vector3 paddleToBallVector;
    private Rigidbody2D ballrigidbody2d;

    // Use this for initialization
    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        paddleToBallVector = this.transform.position - paddleObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (!hasStarted)
        {
            this.transform.position = paddleToBallVector + paddleObj.transform.position;
        }

        if(Input.GetMouseButtonDown(0))
        {
            rigidbody2d.velocity = new Vector2(2f, 15f);
            hasStarted = true;
            print("mouse clicked");
        } 
	}
}
