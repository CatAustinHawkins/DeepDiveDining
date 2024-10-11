using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLifespan : MonoBehaviour
{
    public float Lifespan;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(Lifespan);
        Destroy(gameObject);
    }
}
