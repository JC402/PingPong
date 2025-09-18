using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 direction;
    scoreManager score;

    // Sets ball direction to normalized vector, angle in radians
    void setDirAng(float angle) {
        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);
    }

    // Respawn ball in the center moving in a random direction
    void respawnBall() {
        rb.MovePosition(Vector2.zero);
        setDirAng(Random.Range(0f, 2f * Mathf.PI));
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreManager>();
        respawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collison) {
        if (collison.gameObject.CompareTag("paddle"))
            direction.x = -direction.x;
        else if (collison.gameObject.CompareTag("topWall"))
            direction.y = -direction.y;
        else if (collison.gameObject.CompareTag("leftWall")) {
            respawnBall();
            // Add 1 to score and end game if right player won
            if (score.addRight() == 1)
                gameObject.SetActive(false);
        } else if (collison.gameObject.CompareTag("rightWall")) {
            respawnBall();
            if (score.addLeft() == 1)
                gameObject.SetActive(false);
        }
    }
}