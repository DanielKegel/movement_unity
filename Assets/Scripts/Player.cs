using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Player : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerBody;

    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start() {
        playerBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 10f, playerBody.velocity.y, Input.GetAxisRaw("Vertical") * 10f);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        playerBody.velocity = inputVector;
    }
}
*/

public class Player : MonoBehaviour {
    public float movementSpeed = 10;
    public float turningSpeed = 60;
 
    void Update() {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * (Time.deltaTime * 4);
        transform.Rotate(0, horizontal, 0);
         
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }
}