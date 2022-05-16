using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameManager game;

    [Header("Block Prefabs")]
    public GameObject[] shortBlock;

    [Header("Spawner Position")]
    public Transform[] spawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        if (game.isPlay)
        {
            int random = Random.Range(0, 3);

            var blockIndex = Instantiate(shortBlock[random], new Vector3(spawnerPosition[random].position.x, spawnerPosition[random].position.y, spawnerPosition[random].position.z), Quaternion.identity);
            blockIndex.transform.parent = spawnerPosition[random];

            yield return new WaitForSeconds(1f);
            StartCoroutine(Spawner());
        }
    }
}
