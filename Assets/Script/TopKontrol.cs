using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour {
    public AudioClip carpma, bitis;
    public UnityEngine.UI.Button sonrakibolum, basla, yenidenoyna;
    public float speed;
    public AudioSource audioSrc;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    public float Hiz = 18.5f;
    float zamanSayaci = 20;
    int cansayaci = 3;
    bool baslat = false;
    bool oyundevam = true;
    bool oyuntamam = false;

    

    void Start() {
        rg = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();


        
    }

    

    
    void Update()
    {
        




        if (oyundevam && !oyuntamam && baslat)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = "" + (int)zamanSayaci;
        }
        else if (!oyuntamam && baslat)
        {
            durum.text = "GAME OVER";
            yenidenoyna.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyundevam = false;

        }

    }

    /*"FixUpdate" methodu her bir fizik hesaplamasından önce çağrılır. Oyuncu kontrolü gibi fiziksel hesaplamalar gerektiren kodlar
    genellilkle "FixUpdate" içine yazılır.*/
    private void FixedUpdate()
    {
        speed = rg.velocity.magnitude;
        if (oyundevam && !oyuntamam && baslat)
        {
            
            //"GetAxis" WASD veya yön tuşlarını kontrol eden genel bir terimdir.
            float yatay = Input.acceleration.x * 15.5f; //"Getaxis("Horizontal") yatay konumu ilgilendiren "A ve D" tuşlarını kontrol eder.
            float dikey = Input.acceleration.y * 15.5f;   //"Getaxis("Vertical") dikey konumu ilgilendiren "W ve S" tuşlarını kontrol eder.
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay); //"Vector3" kontrol edilen tuşları işlevsel bir hale sokmak için kullanılır.
            rg.AddForce(kuvvet * Hiz); //"AddForce" ise "kuvvet" olarak belirlediğimiz "Vector3" ü artık hareketetirmeye yarar.

           

        } else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }

    //Çarpışma kontrolü için "OnCollisionEnter" 
    //İf içinde "==" yerine ".Equals" da kullanılabilir.
    private void OnCollisionEnter(Collision collision)
    {
        string objİsmi = collision.gameObject.name;

        if (objİsmi.Equals("Bitis"))
        {
            oyuntamam = true;
            AudioSource.PlayClipAtPoint(bitis, transform.position);
            durum.text = "YOU WINNER";
            sonrakibolum.gameObject.SetActive(true);

        }
        else if (!objİsmi.Equals("GenelZemin") && !objİsmi.Equals("LabirentZemin"))
        {
            cansayaci -= 1;
            AudioSource.PlayClipAtPoint(carpma, transform.position,10f);
            can.text = cansayaci + "";
            if (cansayaci == 0)
            {
                oyundevam = false;
            }
        }



    }

   




    public void Basla ()
    {

        baslat = true;
        basla.gameObject.SetActive(false);
       

    }

    
    
}
