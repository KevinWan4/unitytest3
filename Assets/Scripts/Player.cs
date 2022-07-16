using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    //used in other classes
    int level;
    
    


    //used by me
    int index_X, index_Y;


    


    private bool isMoving = false;
    private Vector3 originalPosition, targetPosition;
    [SerializeField] private float timeToMove = 0.3f;
    public Vector3 axis;

    void Start() {
        
    }

    void Update() {
        if (!isMoving) {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                axis = Vector3.Cross(Vector3.down, Vector3.back);
                StartCoroutine(Move(new Vector3(0,1, 0)));
            } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                axis = Vector3.Cross(Vector3.up, Vector3.back);
                StartCoroutine(Move(new Vector3(0,-1, 0)));
            } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                axis = Vector3.Cross(Vector3.back, Vector3.left);
                StartCoroutine(Move(new Vector3(-1,0, 0)));
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                StartCoroutine(Move(new Vector3(1,0, 0)));
                axis = Vector3.Cross(Vector3.back, Vector3.right);
            }   
        }
    }

    private IEnumerator Move(Vector3 moveDirection) {
        isMoving = true;
        float elapsedTime = 0f;
        originalPosition = transform.position;
        targetPosition = originalPosition + moveDirection;

        while (elapsedTime < timeToMove) {
            transform.RotateAround(transform.position, axis, 90/timeToMove*Time.deltaTime);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime/timeToMove));
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.rotation = new Quaternion(0, Mathf.Round(transform.rotation.x), Mathf.Round(transform.rotation.y), Mathf.Round(transform.rotation.z));
        isMoving = false;
    }

} 
