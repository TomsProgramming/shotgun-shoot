using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public bool GameStarted = false;

    public GameObject Player;
    public Transform Shotgun;

    public TextMeshProUGUI ClickToPlayText;
    public TextMeshProUGUI AmmoText;

    public GameObject BulletlPrefab;

    void Start()
    {
        // Hier zet die de zwaartekracht van de speler uit
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void Update()
    {
        // Hier kijkt die ofdat de game gestart moet worden
        if (Input.GetMouseButtonDown(0) && GameStarted == false)
        {
            // Hier zet die de zwaartekracht van de speler aan
            ClickToPlayText.enabled = false;
            AmmoText.enabled = true;
            Player.SetActive(true);

            Shotgun.GetComponent<Shotgun>().Ammo = 3;
            AmmoText.text = "" + Shotgun.GetComponent<Shotgun>().Ammo;

            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
            GameStarted = true;
        }

        if (GameStarted == true)
        {
            if (Player.transform.position.y < -5)
            {
                // Hier zet die de zwaartekracht van de speler uit
                GameStarted = false;

                ClickToPlayText.enabled = true;
                AmmoText.enabled = false;
                Player.SetActive(false);

                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }

                Player.GetComponent<Rigidbody2D>().gravityScale = 0;
                Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                Shotgun.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Player.transform.position = new Vector3(0, 0, 0);
            }


            if(Player.transform.position.x < -9.5)
            {
                Player.transform.position = new Vector3(9.5f, Player.transform.position.y, 0);
            }

            if (Player.transform.position.x > 9.5)
            {
                Player.transform.position = new Vector3(-9.5f, Player.transform.position.y, 0);
            }


            // Bullet pickup

            float BulletAmount = GameObject.FindGameObjectsWithTag("Bullet").Length;

            if (BulletAmount < 2)
            {
                Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Camera.main.nearClipPlane));
                GameObject Bullet = Instantiate(BulletlPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
