using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Shotgun;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Shotgun.GetComponent<Shotgun>().Ammo += 1;
            Shotgun.GetComponent<Shotgun>().AmmoText.text = "" + Shotgun.GetComponent<Shotgun>().Ammo;
        }
    }
}
