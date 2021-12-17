using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 100.0f;
    Vector3 respawnPos;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }

        /*if (health <= 0)
        {
            SceneManager.LoadScene("Death Screen");
            //This will transition over to the death screen if the health of the player is 0
        }*/
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "Enemy")
        {
            TakeDamage(5f);
            Debug.Log("I have hit the enemy");
            Debug.Log(health);
        }
    }

    public void TakeDamage(float damage)
    {
        // this is the damage function
        health -= damage;
        Debug.Log(health);
        if (health <= 0.0f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.SetPositionAndRotation(respawnPos, Quaternion.identity);
        health = 100.0f;
    }
}