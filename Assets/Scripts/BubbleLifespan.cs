using System.Collections;
using UnityEngine;

public class BubbleLifespan : MonoBehaviour
{
    public float Lifespan;

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
