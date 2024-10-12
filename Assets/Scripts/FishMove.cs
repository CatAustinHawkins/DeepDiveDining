using UnityEngine;

public class FishMove : MonoBehaviour
{
    public GameObject[] Locations;

    public float step;

    public float scalesize;

    public string GOtag;

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Locations[0].transform.position, step);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "End")
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

    void Start()
    {
        Locations = GameObject.FindGameObjectsWithTag(GOtag);

        transform.localScale = new Vector3(-scalesize, scalesize, scalesize);
    }
}
