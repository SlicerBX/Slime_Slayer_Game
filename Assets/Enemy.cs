using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private LevelManager levelManager;

    public GameObject blood;

    public AudioSource death;

    //movement variables
    public LayerMask enemyMask;
    public float speed = 3;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        //myHeight = mySprite.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        // check to see if there's ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        //Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down); // just debugging purposes
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        // if theres no ground, turn around. if blocked, turn around
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        levelManager.updateScore();
        death.Play();
        Destroy(gameObject);
    }

}
