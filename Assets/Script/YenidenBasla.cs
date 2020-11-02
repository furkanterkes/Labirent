using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YenidenBasla : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void Tekrar ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
