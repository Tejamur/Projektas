using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ball;
    public float speed = 7f;
    public float maxDragDistance = 3.5f;
    public TrailRenderer trailRenderer;

    public GetPoint[] aliens;
    public EndLevel endLevel;

    private bool isDragging = false;
    private bool hasShot = false;

    private Vector2 startPos;
    private Vector2 currentPos;

    

    void Start()
    {
        ball.isKinematic = true;
        startPos = transform.position;
        trailRenderer.enabled = false;
    }

    void Update()
    {
            if (isDragging && !hasShot)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 offset = mousePos - startPos;
                offset = Vector2.ClampMagnitude(offset, maxDragDistance); //clampinam vectoriu kad kamuolys nevirsitu leistino atstumo.

                currentPos = startPos + offset;
                ball.transform.position = currentPos;
            }
        
    }

    private void OnMouseDown()
    {
        if (hasShot) return;
        isDragging = true;
    }

    private void OnMouseUp()
    {
            if (hasShot) return;

            isDragging = false;
            hasShot = true;

            ball.isKinematic = false;
            trailRenderer.enabled = true;

            Vector2 launchForce = (startPos - currentPos) * speed;

            ball.AddForce(launchForce, ForceMode2D.Impulse);


            endLevel.waitTime = 10f;
       
    }

 private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Destroy"))
    {

        for (int i = 0; i < aliens.Length; i++)
        {
            aliens[i].MakeDynamic();
        }
    }
}
}