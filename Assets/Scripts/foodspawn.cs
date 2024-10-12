using System.Collections;
using UnityEngine;

public class foodspawn : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnPause());
    }

    IEnumerator EnemySpawnPause()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(Random.Range(3f, 10f));
        StartCoroutine(EnemySpawnPause());
    }
}
