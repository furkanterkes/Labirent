using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonrakiBolum : MonoBehaviour {
    ArrayList bolumler = new ArrayList();
    
    
    void Start () {
        bolumler.Add("bölüm2");
        bolumler.Add("bölüm3");
        bolumler.Add("bölüm4");
	}
	
	
	void Update () {
		
	}

    public void YeniOyun()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        



    }
}
