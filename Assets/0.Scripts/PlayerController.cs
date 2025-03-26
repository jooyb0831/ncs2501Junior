using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float horsePower = 200f;
    [SerializeField] private float turnSpeed = 45f;

    [SerializeField] GameObject centerOfMass;

    [SerializeField] TMP_Text speedometerText;
    [SerializeField] float speed;

    [SerializeField] TMP_Text rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    public float horizontalInput;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //플레이어 입력 받기
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (IsOnGround())
        {

            //차량 전진
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);


            if (forwardInput != 0)
            {
                //회전
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
            }

            //UI표기
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for kph
            speedometerText.text = $"Speed : {speed} mph";

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.text = $"RPM : {rpm}";
        }   
        else
        {
            speedometerText.text = $"Speed : 0 mph";
            rpmText.text = $"RPM : 0";
        }



    }

    private void Update()
    {

    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
