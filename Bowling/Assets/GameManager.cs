using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Move the ball
    // Manage the score
    // Manage the turns

    public GameObject ball;
    int score = 0;
    int turnCounter = 0;
    GameObject[] pins;
    public Text scoreUI;

    Vector3[] positions;


    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for(int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();

        if(Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -20);
        {
            CountPinsDown();
            turnCounter++;
            ResetPins();
        }
    }

    void MoveBall()
    {
        ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    void CountPinsDown()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }

        scoreUI.text = score.ToString();
    }

    void ResetPins()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            //pins[i].SetActive(true);
            //pins[i].transform.position = positions[i];
            //pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            //pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //pins[i].transform.rotation = Quaternion.identity;
        }

        //ball.transform.position = new Vector3(-0.238, -0.185f, -9.178f);
        //ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //ball.transform.rotation = Quaternion.identity;
    }
}

