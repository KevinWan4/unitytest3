using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    /*tile id definition:
    1 - 6 -> weighted tiles
    0 -> empty/space tile
    -6 - -1 -> fragile tiles
    7 -> standard tiles
    8 -> breakable tile
    9 -> you win
    11-16 -> specific number tile
    */

    private int idNum; 

    public Tile(int id){
        idNum = id;
    }
    public int getid(){
        return idNum;
    }
    void updateTile(){
        if(idNum == 8){
            idNum = 0;
        }
        else if(idNum<0){
            idNum ++;
        }
    }
}