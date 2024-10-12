using System.Collections;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    public GameObject[] Locations;

    public int Randomlimit;

    public GameObject Location;
    public float step;
    public int random;

    public float scalesize;

    public string tag;

    void Start()
    {
        Locations = GameObject.FindGameObjectsWithTag(tag);
        random = Random.Range(0, Randomlimit);
        StartCoroutine(ChangeTarget());
    }

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Locations[random].transform.position, step);
    }

    IEnumerator ChangeTarget()
    {
        yield return new WaitForSecondsRealtime(10f);
        random = Random.Range(0, Randomlimit);
        StartCoroutine(ChangeTarget());
    }
}
