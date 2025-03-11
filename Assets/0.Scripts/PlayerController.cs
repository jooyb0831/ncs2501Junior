using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    public float horizontalInput;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");   

        //차량 전진
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        if(forwardInput!=0)
        {
            //회전
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        }

    }
}
