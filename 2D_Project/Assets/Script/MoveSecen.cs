using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSecen : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene("Coding");
        }
    }
}
