using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove2 : MonoBehaviour
{
    public GameObject[] Locations;

    public float step;

    public float scalesize;

    public string GOtag;

    void Start()
    {
        Locations = GameObject.FindGameObjectsWithTag(GOtag);

        transform.localScale = new Vector3(scalesize, scalesize, scalesize);
    }

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Locations[0].transform.position, step);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "End")
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "End")
        {
            Destroy(gameObject);
        }
    }

}
