using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManger : MonoBehaviour
{
    public bool isPaused = false;

    public GameObject pauseMenu;
    public PlayerController playerData;

    public Image healthBar;
  
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
            playerData = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
