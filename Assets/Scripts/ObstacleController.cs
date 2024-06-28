using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    GameManager gameManager;

    void Update()
    {
        gameManager = FindObjectOfType<GameManager>();
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameManager.Score();
            Destroy(gameObject);
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("Player")) {

            SceneManager.LoadScene("GameOver");
        }
    }
}
