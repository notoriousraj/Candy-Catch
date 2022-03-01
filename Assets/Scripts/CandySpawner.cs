using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxPos;

    [SerializeField]
    float Timeinterval;

    public GameObject[] Candies;

    public static CandySpawner instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine("SpawnCandies");
    }

    public void Spawner()
    {
        float RandomPos = Random.Range(-maxPos, maxPos);

        Vector3 randPOS = new Vector3(RandomPos, transform.position.y, transform.position.z);

        Instantiate(Candies[Random.Range(0, Candies.Length)] , randPOS , transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            Spawner();

            yield return new WaitForSeconds(Timeinterval);
        }
    }

    public void StopSpawingCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
