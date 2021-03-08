using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimHandMove : MonoBehaviour
{
    public Transform location;
    public Vector3 position;
    public float movespeed;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //location.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movespeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movespeed);
        }

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DoSprint(10);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DoSprint(0.1f);
        }
    }
        public void DoSprint(float sprintFactor)
        {
          var acceleration = movespeed * sprintFactor;
        movespeed = acceleration; //Mathf.Lerp(movespeed, acceleration, Time.deltaTime);
        }
    
}
