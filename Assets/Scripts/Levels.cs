using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    [SerializeField] string newLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void endLevel()
    {
        
    }

    // void update() {
    //     OnTriggerEnter2D(GetComponent<BoxCollider2D>());
    // }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            print("collide");
            endLevel();
            SceneManager.LoadScene(newLevel);
        }
        
    }

    Tile[,] newScene (int level) 
    {
        level++;
        if (level==1) {
            
            //Level 1
            return new Tile[2,5]{
                {new Tile(7), new Tile(7), new Tile(7), new Tile(7), new Tile(7)},
                {new Tile(7), new Tile(7), new Tile(0), new Tile(7), new Tile(9)}
            };
        } else if (level==2) {
            
            //Level 2
            return new Tile[2,4]{
                {new Tile(7), new Tile(7), new Tile(0), new Tile(0)},
                {new Tile(7), new Tile(7), new Tile(1), new Tile(9)}
            };
        } else if (level==3) {
            
            //Level 3
            return new Tile[2,6]{
                {new Tile(0), new Tile(0), new Tile(7), new Tile(7), new Tile(0), new Tile(0)},
                {new Tile(7), new Tile(8), new Tile(7), new Tile(-6), new Tile(3), new Tile(9)}
            };
        } else {

            //something went wrong, or we run out 
            return new Tile[1,1] {{new Tile(7)}};
        }
    }



    
}
