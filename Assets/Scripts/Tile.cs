using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    private int idNum; 

    private Tile(int id){
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