using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D body;
    public AudioSource audioSource;
    GameManager manager;
    void Start()
    {
        GameObject found = GameObject.FindGameObjectWithTag("GameController");

        manager = found.GetComponent<GameManager>();
        
        
        ResetPosition();
        PickDirectionAndMove();
    }

    void ResetPosition()
    {
        body.MovePosition(Vector2.zero);
    }

    void PickDirectionAndMove()
    {
        float xDirection = Random.Range(45, 90);
        float yDirection = Random.Range(45, 90);

        body.velocity = new Vector2(xDirection, yDirection).normalized * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        audioSource.Play();
        
 
        //collision.gameObject is other object we collided with
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            manager.OnBlockDestroyed();
        }
        if (collision.gameObject.CompareTag("Barrier"))
        {
            manager.OnBallDestroyed();
            ResetPosition();
            PickDirectionAndMove();
        }
    }
}
