using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    //used in other classes
    private int level = 0;
    
    Tile[,] tileGrid = new Tile[0,0];
    GameObject[] taggedTiles;
    Tile currentTile;
    //used by me
    private int index_X, index_Y;


    Faces faces;
    


    private bool isMoving = false;
    private Vector3 originalPosition, targetPosition;
    private Quaternion originalRotation;
    [SerializeField] private float timeToMove = 0.3f;
    [SerializeField] private float moveDistance = 2;
    public Vector3 axis;

    void Start() {
        faces.setInitial();
        currentTile = GameObject.FindGameObjectsWithTag("0,0")[0].GetComponent(typeof(Tile)) as Tile;
    }

    void Update() {
        
        if (!isMoving) {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                currentTile.updateTile();
                index_Y++;
                axis = Vector3.Cross(Vector3.down, Vector3.back);
                StartCoroutine(Move(new Vector3(0,1, 0)));
                faces.changeFaces("up");

                setCurrentTile();
                checkTile();
            } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                currentTile.updateTile();
                index_Y--;
                axis = Vector3.Cross(Vector3.up, Vector3.back);
                StartCoroutine(Move(new Vector3(0,-1, 0)));
                faces.changeFaces("down");

                setCurrentTile();
                checkTile();
            } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                currentTile.updateTile();
                index_X--;
                axis = Vector3.Cross(Vector3.back, Vector3.left);
                StartCoroutine(Move(new Vector3(-1,0, 0)));
                faces.changeFaces("left");

                setCurrentTile();
                checkTile();
            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                currentTile.updateTile();
                index_X++;
                StartCoroutine(Move(new Vector3(1,0, 0)));
                axis = Vector3.Cross(Vector3.back, Vector3.right);
                faces.changeFaces("right");

                setCurrentTile();
                checkTile();
            } 
        }
    }

    
    void checkTile() {
        if (Mathf.Abs(currentTile.getid()) < faces.front) {
            death();
        } else if (currentTile.getid() == 9) {
            print("You win");
        }
        
    }
    
    void setCurrentTile() {
        taggedTiles = GameObject.FindGameObjectsWithTag(index_X+","+(index_Y));
        if (taggedTiles.Length == 0) {
            death();
        } else {
            currentTile = taggedTiles[0].GetComponent(typeof(Tile)) as Tile;
        }
    }

    void death() {
        print("you died!");
    }

    private IEnumerator Move(Vector3 moveDirection) {
        isMoving = true;
        float elapsedTime = 0f;
        originalPosition = transform.position;
        targetPosition = originalPosition + moveDirection * moveDistance;
        originalRotation = transform.rotation;

        while (elapsedTime < timeToMove) {
            
            transform.RotateAround(transform.position, axis, 90/timeToMove*Time.deltaTime);
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime/timeToMove));
            

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.position = targetPosition;
        transform.rotation = originalRotation;
        transform.RotateAround(transform.position, axis, 90);
        isMoving = false;
    }

    public struct Faces {
        public int front, top, bottom, left, right, back;
        int temp;

        public void changeFaces(string direction) {
            if (direction == "right") { 
                temp = right; 
                right = front; 
                front = left; 
                left = back; 
                back = temp; 
            } else if (direction == "left") {
                temp = left; 
                left = front; 
                front = right; 
                right = back;
                back = temp;
            } else if (direction == "down") {
                temp = front;
                front = top;
                top = back;
                back = bottom;
                bottom = temp;
            } else if (direction == "up") {
                temp = bottom;
                bottom = back; 
                back = top; 
                top = front; 
                front = temp;
            }
            print(top + "," + bottom + "," + front + "," + back + "," + left + "," + right);
        }

        public void setInitial() {
            front = 6;
            top = 2;
            bottom = 5;
            left = 3;
            right = 4;
            back = 1;
        }
    }

    
} 
