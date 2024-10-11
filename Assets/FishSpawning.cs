using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnPause());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EnemySpawnPause()
    {
        Instantiate(Enemy[Random.Range(0,6)], transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(Random.Range(3f, 15f));
        StartCoroutine(EnemySpawnPause());
    }
}
