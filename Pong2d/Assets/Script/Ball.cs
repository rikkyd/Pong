using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public bool isBounce;
    public bool bonusGoal;
    public bool isLastHit1;

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
        soundManager.instance.BallBounceSfx();
        if (col.gameObject.tag == "Racket Red" && !isBounce)
        {
            float randomX = Random.Range(0.5f, 1.0f); 
            float randomY = Random.Range(-1.0f, 1.0f); 
            Vector2 dir = new Vector2(randomX, randomY).normalized;

            rb.velocity = dir * speed;
            StartCoroutine("DelayBounce");
            isLastHit1 = true;
        }

        if (col.gameObject.tag == "Racket Blue" && !isBounce)
        {
            float randomX = Random.Range(-1.0f, -0.5f);
            float randomY = Random.Range(-1.0f, 1.0f); 
            Vector2 dir = new Vector2(randomX, randomY).normalized;

            rb.velocity = dir * speed;
            StartCoroutine("DelayBounce");
            isLastHit1 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Goal 1")
        {
            soundManager.instance.GoalSfx();
            GameManager.instance.player2Score++;
            if (bonusGoal)
            {
                GameManager.instance.player2Score++;
            }
            GameManager.instance.SpawnBall();
            Destroy(gameObject);

            if (GameManager.instance.goldenGoal) 
            {
                GameManager.instance.GameOver();
            }
        }

        if (col.gameObject.tag == "Goal 2")
        {
            soundManager.instance.GoalSfx();
            GameManager.instance.player1Score++;
            if (bonusGoal)
            {
                GameManager.instance.player1Score++;
            }
            GameManager.instance.SpawnBall();
            Destroy(gameObject);

            if (GameManager.instance.goldenGoal) 
            {
                GameManager.instance.GameOver();
            }
        }
    }
    private IEnumerator DelayBounce()
    {
        isBounce = true;
        yield return new WaitForSeconds(1f); // Wait for 1 second
        isBounce = false;
    }
}