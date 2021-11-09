using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPewPew : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5f;
    public float rotatespeed = 5f;
    public Camera cam;
    float maxY = 60f;
    float minY = -60f;
    float rotation;
    public ParticleSystem boom;

    void Start()
    {
        cc = GetComponent<CharacterController>();
         
    }

    void Update()
    {
        movement();
        rotate();
    }


    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cc.Move(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            cc.Move(Vector3.back * speed * Time.deltaTime  );
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.Move(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            cc.Move(Vector3.left * speed * Time.deltaTime  );
        }
    }

    void rotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rotation += rotatespeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotation -= rotatespeed * Time.deltaTime;
        }

        Vector3 cannonpos = transform.position + new Vector3(0, 1, 0);
        Quaternion cannonrot = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotation, transform.localEulerAngles.z));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pewed at " + cannonpos + " " + cannonrot);
            Instantiate(boom, cannonpos, cannonrot);
        }
    }

    
}
