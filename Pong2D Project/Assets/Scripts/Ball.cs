using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    private void StartBall()
    {
        int rand = Random.Range(0, 2);

        if(rand == 0)
        {
            rb.AddForce(new Vector2(-4, 3), ForceMode2D.Impulse);
        }
        else if(rand == 1)
        {
            rb.AddForce(new Vector2(4, 3), ForceMode2D.Impulse);
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void RestartGame()
    {
        ResetBall();
        Invoke("StartBall", 2f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player")) //jika terkena player
        {
            Vector2 vel;
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3); //mengambil nilai velocity player
            rb.velocity = vel;
        }
    }
}
