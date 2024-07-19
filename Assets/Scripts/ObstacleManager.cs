using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] stonePrefabs;  // Array of stone prefabs
    public float spawnRate = 2f;
    public float speed = 5f;

    void Start()
    {
        StartCoroutine(SpawnStones());
    }

    IEnumerator SpawnStones()
    {
        while (true)
        {
            SpawnStone();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    void SpawnStone()
    {
        // Choose a random stone prefab from the array
        GameObject selectedStonePrefab = stonePrefabs[Random.Range(0, stonePrefabs.Length)];

        Vector3 spawnPosition = new Vector3(Random.Range(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect, Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect),
                                            Camera.main.transform.position.y + Camera.main.orthographicSize + 1f,
                                            0f);

        GameObject newStone = Instantiate(selectedStonePrefab, spawnPosition, Quaternion.identity);

        // Attach a script to the stone to monitor its position
        StoneController stoneController = newStone.AddComponent<StoneController>();
        stoneController.SetSpeed(speed);
    }
}
