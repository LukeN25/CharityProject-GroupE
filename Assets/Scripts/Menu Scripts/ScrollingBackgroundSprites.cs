using UnityEngine;

public class ScrollingBackgroundSprites : MonoBehaviour
{
    public float speed = 2f; 
    public float spriteWidth; 
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; 
    }

    void Update()
    {
        // Move the background left
        transform.position += Vector3.left * speed * Time.deltaTime;

       
        if (transform.position.x <= startPosition.x - spriteWidth)
        {
            transform.position += new Vector3(spriteWidth * 2, 0, 0);
        }
    }
}
