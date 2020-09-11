using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    private bool lookedRight;
    private bool lookedLeft;

    private bool OMGLeft;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        float hDir = Input.GetAxisRaw("Horizontal");



        if(hDir > 0)
        {
            lookedRight = true;
        }

        if(hDir < 0)
        {
            lookedLeft = true;
        }


        if (hDir == 0 && OMGLeft == true)
        {
            rb.velocity = transform.right * speed * -1 + transform.up * 3f;
            transform.localScale = new Vector3(-7, 7, 7);
        }
        else if (hDir > 0 && lookedRight == true)
        {
            rb.velocity = transform.right * speed + transform.up * 3f;
            transform.localScale = new Vector3(7, 7, 7);
            setLookedRight();
        }
        else if(hDir < 0 && lookedLeft == true)
        {
            transform.localScale = new Vector3(-7, 7, 7);
            rb.velocity = transform.right * speed * -1 + transform.up * 3f;
            setLookedLeft();
            setOMGLeft();
        }
        else if(hDir == 0)
        {
            rb.velocity = transform.right * speed + transform.up * 3f;
            transform.localScale = new Vector3(7, 7, 7);
        }
        

    }

    private void setLookedRight()
    {
        lookedRight = true;
    }

    private void setLookedLeft()
    {
        lookedLeft = true;
    }

    private void setOMGLeft()
    {
        OMGLeft = true;
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        print(col.name);
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    
}