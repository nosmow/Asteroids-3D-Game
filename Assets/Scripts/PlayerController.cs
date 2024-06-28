using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioSource audioFire;
    float movX, movZ;
    public float limitX, limitZ;
    public float speed = 10f;
    public float turbo = 20f;
    public float timeTurbo = 0f;

    Vector3 move;
    public GameObject bullet;

    void Start()
    {
        audioFire = GetComponent<AudioSource>();
    }

    void Update()
    {
        LimitMovement();
        PlayerMovement();
        TurboPlayer();
        Shoot();
    }


    void PlayerMovement()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        if (movX != 0 || movZ != 0)
        {       
            move = new Vector3(movX, 0, movZ).normalized;        

            //Gira el jugador hacia donde nos estamos moviendo
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            //Mueve al jugador
            transform.Translate(move * speed * Time.deltaTime, Space.World);
        }
    }

    void TurboPlayer()
    {
        timeTurbo += Time.deltaTime;

        //El jugador avanza e dirección hacia donde mira
        if (Input.GetKeyDown(KeyCode.Space) && timeTurbo >= 3f)
        {
            transform.position += transform.forward * turbo;
            timeTurbo = 0f;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioFire.Play();
            // Instanciar la bala en la posición del jugador
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void LimitMovement()
    {
        Vector3 position = transform.position;

        position.z = Mathf.Clamp(position.z, -limitZ, limitZ);
        position.x = Mathf.Clamp(position.x, -limitX, limitX);

        transform.position = position;
    }

}

