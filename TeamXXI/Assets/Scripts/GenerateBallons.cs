using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBallons : MonoBehaviour
{
    [SerializeField]
    private float startHeightY;
    [SerializeField]
    private GameObject balloonPrefab;
    [SerializeField]
    private float minWaitingTimeInSeconds;
    [SerializeField]
    private float maxWaitingTimeInSeconds;


    private float startMinXPosition = -70f;
    private float startMaxXPosition = 70f;
    private float startMinZPosition = -70f;
    private float startMaxZPosition = 60f;
    private float startXPosition;
    private float startZPosition;
    private float startingSide;
    private float position;
    private float generationTime;
    private float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SetGenerationTime();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= generationTime)
        {
            elapsed = elapsed % generationTime;

            SetStartPosition();
            Vector3 startPosition = new Vector3(startXPosition, startHeightY, startZPosition);

            // TODO: Choose the right rotation
            Instantiate(balloonPrefab, startPosition, Quaternion.identity);
            SetGenerationTime();
        }
    }

    private void SetGenerationTime()
    {
        //generationTime = Random.Range(10, 61);
        generationTime = Random.Range(minWaitingTimeInSeconds, maxWaitingTimeInSeconds);
    }

    private void SetStartPosition()
    {

        startingSide = Random.Range(0, 4);
        position = Random.Range(-50f, 50f);

        if (startingSide == 0)
        {
            startXPosition = startMinXPosition;
            startZPosition = position;

        }
        else if (startingSide == 1)
        {
            startXPosition = startMaxXPosition;
            startZPosition = position;

        }
        else if (startingSide == 2)
        {
            startZPosition = startMinZPosition;
            startXPosition = position;
        }
        else if (startingSide == 3)
        {
            startZPosition = startMaxZPosition;
            startXPosition = position;
        }
    }

}