using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    //called at start of game before any updates
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

   //occurs every frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //move the ball
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //adds input in movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //applies movement to ball
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //counts pick ups collected
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        //when all boxes are collecteed game ends
        countText.text = "Count" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}