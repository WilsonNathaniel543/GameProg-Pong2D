using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float moveVertical;
    public KeyCode moveUp;
    public KeyCode moveDown;
    [SerializeField] private float moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            moveVertical = 1;
        }
        else if (Input.GetKey(moveDown))
        {
            moveVertical = -1;
        }
        else
        {
            moveVertical = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveVertical * moveSpeed);
    }
}
