using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 1;
    public GameObject gameOverText, restartButton, blood;

    public AudioSource Death;

    public Rigidbody2D rb;
    public Animator animation;
    public float speed = 5f;
    public float jumpForce = 1500f;
    [SerializeField] private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = LayerMask.GetMask("Ground");
        if(Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.1f, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }


        float hDir = Input.GetAxisRaw("Horizontal");
        Vector2 hMove = new Vector2(hDir * speed, rb.velocity.y);

        if(hDir < 0)
        {
            transform.localScale = new Vector3(-7, 7, 7);
        }
        else if(hDir > 0)
        {
            transform.localScale = new Vector3(7, 7, 7);
        }

        if (hDir != 0)
            animation.SetBool("isMoving", true);
        else
            animation.SetBool("isMoving", false);

        rb.velocity = hMove;

        //animation if player shoots with bow
        if (Input.GetKeyDown("space"))
        {
            animation.SetTrigger("isFiring");
        }

        //out of bounds
        if(transform.position.y <= -20)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            Death.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            Death.Play();
        }
    }

}
