using UnityEngine;
using UnityEngine.SceneManagement;

public class frogMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {   
            rb.MovePosition(rb.position + Vector2.right);
        }

        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {   
            rb.MovePosition(rb.position + Vector2.left);
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {   
            rb.MovePosition(rb.position + Vector2.up);
        }
        
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {   
            rb.MovePosition(rb.position + Vector2.down);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Car")
        {   
            SceneManager.LoadScene("GameOverCarScene");
        }
    }


}
