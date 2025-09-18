using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    public float respawnAngle;
    Vector2 direction;
    public scoreManager score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnAngle *= Mathf.PI / 180f; // Convert to radians
        direction = new Vector2(Mathf.Cos(respawnAngle), Mathf.Sin(respawnAngle));
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreManager>();
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
            rb.MovePosition(Vector2.zero);
            score.addRight();
        } else if (collison.gameObject.CompareTag("rightWall")) {
            rb.MovePosition(Vector2.zero);
            score.addLeft();
        }
    }
}