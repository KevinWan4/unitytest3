using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    private idNum; 

    private Tile(int id){
        idNum = id;
    }
    public getid(){
        return idNum;
    }
    void updateTile(){
        if(this.idNum == 8){
            this.idNum = 0;
        }
        else if(this.idNum<0){
            this.idNum ++;
        }
    }
}