using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{
    public Transform Manager;
    public Transform Player;

    public float Ammo = 0;

    public TextMeshProUGUI AmmoText;

    public AudioClip Gunshot;
    public AudioClip CantShoot;

    void Start()
    {

    }

    void Update()
    {
        // Controlleren ofdat de game gestart is
        if(Manager.GetComponent<Manager>().GameStarted)
        {
            // Hier krijgt die de muis positie en zet die om naar een 3D positie
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // hier zet die de z positie op 0 omdat het 2D is

            // hier berekent die de richting van de muis naar de shotgun
            Vector3 direction = mousePosition - transform.position;

            // hier berekent die de hoek van de richting en zet die om naar graden
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // hier kijkt die ofdat linker muisknop is ingedrukt
            if (Input.GetMouseButtonDown(0))
            {
                // hier kijkt die ofdat er nog ammo is
                if (Ammo > 0)
                {
                    // hier speelt die het geluid af
                    AudioSource.PlayClipAtPoint(Gunshot, transform.position, 1f);
                    // Beweegt speler van de kogel af
                    Player.GetComponent<Rigidbody2D>().velocity = -direction.normalized * 10;

                    // hier zet die de ammo -1
                    Ammo--;
                    AmmoText.text = ""+Ammo;
                }
                else
                {
                    // hier speelt die het geluid af
                    AudioSource.PlayClipAtPoint(CantShoot, transform.position, 1f);
                }
            }
        }
    }
}
