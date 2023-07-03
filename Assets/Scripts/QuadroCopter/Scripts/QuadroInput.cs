using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuadroInput : MonoBehaviour
{
    private bool isLeftDown = false;
    private bool isRightDown = false;
    private float steeringValue = 0;
    private float steeringVelocity = 0;

    public GameObject nullRotatePoint;
    private bool jump;

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    public GameObject quadroCameraGM;
    public GameObject quadroCenter;
    public float speed = 100.0f;
    public float rotationSpeed = 100.0f;
    
    // Audio
    public AudioSource flyAudioSource;
    public AudioClip flySound;
    public AudioClip preflySound;


    

    Vector3 startLocalEulerAngles = Vector3.zero;

    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = new Rigidbody();
        startLocalEulerAngles = transform.localEulerAngles;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        InputKeyboard();
        InputMouse();
        JumpAddForce();


        //gameObject.transform.rotation.SetFromToRotation(gameObject.transform.position, nullRotatePoint.transform.position);


        nullRotatePoint.transform.position = gameObject.transform.position;
        quadroCameraGM.transform.position = gameObject.transform.position + new Vector3(16, 9, -4);

        //quadroCameraGM.transform.rotation = gameObject.transform.rotation; 
    }
    private void Update()
    {
        /*
        x += Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;
        y += Input.GetAxis("HorizontalArrow") * Time.deltaTime * rotationSpeed;
        z += Input.GetAxis("Horizontal")* Time.deltaTime * rotationSpeed;


        x = Mathf.Clamp(x, -30, 30);
        y = Mathf.Clamp(y, -30, 30);
        y = Mathf.Clamp(z, -30, 30);

        transform.localEulerAngles = new Vector3(
            startLocalEulerAngles.x + x,
            startLocalEulerAngles.y + y,
            startLocalEulerAngles.z);
    */
        if(gameObject.transform.rotation.x >= 30)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up);
        }

        // JUMP
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
            flyAudioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            flyAudioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            flyAudioSource.Stop();
        }
    }

    private void InputKeyboard()
    {
        float rotationXAxis = Input.GetAxis("Vertical") * rotationSpeed;
        float rotationYAxis = Input.GetAxis("HorizontalArrow") * rotationSpeed;
        float rotationZAxis = Input.GetAxis("Horizontal") * rotationSpeed;

        float moveHorizontal = Input.GetAxis("VerticalArrow") * rotationSpeed;
       
        


        // Make it move 10 meters per second instead of 10 meters per frame...
        rotationXAxis *= Time.deltaTime;
        rotationZAxis *= Time.deltaTime;
        rotationYAxis *= Time.deltaTime;

        moveHorizontal *= Time.deltaTime;

        // Rotate around our XYZ-axis
        gameObject.transform.Rotate(rotationXAxis, 0, 0);
        gameObject.transform.Rotate(0, rotationYAxis, 0);
        gameObject.transform.Rotate(0, 0, rotationZAxis);

        gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, moveHorizontal, 0) * speed);
    }
    private void InputMouse()
    {
        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        

        gameObject.transform.Rotate(0, 0, 0);
    }
    private void JumpAddForce()
    {
        if(jump == true)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed);

        }
        
    }
}
