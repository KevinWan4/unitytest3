using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenButtonManager : MonoBehaviour
{
    [SerializeField] private int level;

    public void buttonMoveScene(int level){
        SceneManager.LoadScene(level);
    }
}
