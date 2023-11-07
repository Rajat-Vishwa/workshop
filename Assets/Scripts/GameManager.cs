using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Vector3 spawnPos = new Vector3(0f, 0f, 0f);
    public Vector3 minScale = new Vector3(0.6f, 0.6f, 1f);
    public Vector3 maxScale = new Vector3(1f, 1f, 1f);
    public GameObject ObstaclePrefab;
    public Transform player;

    private List<GameObject> obstacles = new List<GameObject>();
    public int maxObstacles = 2;
    public float spawnCooldown = 1f;
    private float spawnTimer = 0f;

    public int CurrentScore = 0;
    public int incrementScore = 100;
    public TMP_Text scoreText;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(obstacles.Count > 0 && player != null){
            if(obstacles[0].transform.position.x < player.position.x - 10f){
                CurrentScore += incrementScore;
                obstacles.RemoveAt(0);
            }
        }

        scoreText.text = "Score : " + CurrentScore.ToString();

        // for(int i = 0; i < obstacles.Count; i++){
        //     if(obstacles[i] == null){
        //         obstacles.RemoveAt(i);
        //     }
        // }

        if(obstacles.Count < maxObstacles){
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnCooldown * Random.Range(0.5f, 2.5f)){
                spawnTimer = 0f;
                GameObject obstacle = Instantiate(ObstaclePrefab, spawnPos, Quaternion.identity);
                obstacle.transform.parent = transform;
                obstacle.transform.localScale = Vector3.Lerp(minScale, maxScale, Random.Range(0f, 1f));
                obstacles.Add(obstacle);
            }
        }
    }
}
