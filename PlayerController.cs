using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

    
    public Text CountText;
    public Text winText;
    public Text loseText;
    public Text timerText;
    public float speed = 800.0f;
    private int count;
    public float timeLeft;
    public float totalTime;
    public bool gamewon = false;
    public GameObject reset;
    public GameObject next;

    void Start()
    {
        InitializeVariables();

        
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
        timerText.text = "Timer:" + timeLeft.ToString();
        if (gamewon == false)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                loseText.text = "You Lose!!!";
                gameObject.SetActive(false);
                timerText.text = "Timer: 0.0";
                reset.SetActive(true);

            }
            if (count == 8)
            {
                winText.text = "You Win!!!";
                gamewon = true;
                next.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            CountText.text = "Count:" + count.ToString();
        }
        if (count >= 8)
        {
            winText.gameObject.SetActive(true);
        }

    }

    public void InitializeVariables()
    {
        count = 0;
        winText.text = "";
        timerText.text = "";
        loseText.text = "";
        totalTime = 20;
        timeLeft = totalTime;
        gamewon = false;
        timerText.text = "Timer:" + timeLeft.ToString();
        reset.SetActive(false);
        next.SetActive(false);
    }

    

}