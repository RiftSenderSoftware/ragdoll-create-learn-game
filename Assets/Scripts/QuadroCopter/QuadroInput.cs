using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadroInput : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    public GameObject quadroCameraGM;

    public AudioSource flyAudioSource;
    public AudioClip flySound;
    

    public AudioClip preflySound;

    public GameObject quadroCenter;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = new Rigidbody();
        
    }


    // Update is called once per frame
    void Update()
    {
        InputKeyboard();
        InputMouse();

       

        quadroCameraGM.transform.position = gameObject.transform.position + new Vector3(0, 1f, 3);
        quadroCameraGM.transform.rotation = gameObject.transform.rotation;  
    }

    private void InputKeyboard()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        gameObject.transform.Translate(0, 0, translation);

        // Rotate around our Z-axis
        gameObject.transform.Rotate(0, 0, rotation);

        // JUMP
        if (Input.GetKey(KeyCode.Space))
        {

            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * speed);
        }
        else
        {
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
    private void InputMouse()
    {
        // Get the mouse delta. This is not in the range -1...1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        gameObject.transform.Rotate(0, h, 0);
    }

}
