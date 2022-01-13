using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 horizontal;
    public float speed;
    public float rightscreenEdge;
    public float leftscreenEdge;
    public GameManager gm;
    
    // Update is called once per frame
    void Update()
    {
        
        if (gm.gameOver)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < leftscreenEdge)
        {
            transform.position = new Vector2(leftscreenEdge, transform.position.y);
        }
        if (transform.position.x > rightscreenEdge)
        {
            transform.position = new Vector2(rightscreenEdge, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("extraLift")) { 
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
    }


}
