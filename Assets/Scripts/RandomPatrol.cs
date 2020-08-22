using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    float speed;
    public float maxSpeed;
    public float minSpeed;
    public float secondsToMaxDifficulty;
    Vector2 targetPosition;

    public GameObject restartPanel;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDificultyPercent());
            transform.position = Vector2.MoveTowards
            (
                transform.position,
                targetPosition,
                speed
            );

        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PatrolCircle")
        {
            restartPanel.SetActive(true);
        }
    }

    float GetDificultyPercent() {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
