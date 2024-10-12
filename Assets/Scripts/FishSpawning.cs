using System.Collections;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fish;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FishSpawnPause());
    }


    IEnumerator FishSpawnPause()
    {
        Instantiate(Fish[Random.Range(0,6)], transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(Random.Range(3f, 15f));
        StartCoroutine(FishSpawnPause());
    }
}
