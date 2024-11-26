using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public bool isBounce;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        int random = Random.Range(0,2);
        Debug.Log(random);

        if (random == 0)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    private void Update()
    {
        
        if (transform.position.x > 12 || transform.position.x < -12 || transform.position.y > 8 || transform.position.y < -8)
        {
            GameManager.instance.SpawnBall();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Racket Red" && !isBounce)
        {
            Vector2 dir = new Vector2(1, 0).normalized;
            rb.velocity = dir * speed;
            StartCoroutine("DelayBounce");
        }

        if (col.gameObject.tag == "Racket Blue" && !isBounce)
        {
            Vector2 dir = new Vector2(-1, 0).normalized;
            rb.velocity = dir * speed;
            StartCoroutine("DelayBounce");
        }
    }

    private IEnumerator DelayBounce()
    {
        isBounce = true;
        yield return new WaitForSeconds(1f); // Wait for 1 second
        isBounce = false;
    }
}