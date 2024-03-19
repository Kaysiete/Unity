using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float movement;
    public float speed = 0;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        count = count + 1;
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }

    void OnMove (InputValue movementvalue)
    {
        Vector2 movementVector = movementvalue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if(count >= 5)
        {
            WinTextObject.SetActive(true);
        }
    }
  
}
