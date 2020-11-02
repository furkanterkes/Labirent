using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

	
	void Start () {
        if (PlayerPrefs.HasKey("Level"))
        {

            
            LoadGame();
            PlayerPrefs.DeleteAll();
        }
        
        

    }

    
    void Update () {
		
	}

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        print("Game loaded!");
    }
}
