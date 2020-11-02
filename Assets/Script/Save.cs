using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour {

    
	
	void Start () {

        save();

    }
	
	
	void Update () {
		
	}

    public void save()
    {

        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        print("Game saved!");
        
    }

    
}
