using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL TEMEL OBJELERÝ")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusmaNoktalari;
    [SerializeField] private AudioSource[] Sesler;
    [SerializeField] private ParticleSystem[] Efektler;
    SceneManager scene;

    [Header("---UI OBJELERÝ")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    [SerializeField] private GameObject[] Paneller;
    [SerializeField] private TextMeshProUGUI LevelAd;
    float ParmakPozX;
    int BasketSayisi;

    void Start()
    {
        LevelAd.text = "LEVEL :   " + SceneManager.GetActiveScene().name;

        for (int i = 0; i < AtilmasiGerekenTop; i++)
        {
            GorevGorselleri[i].gameObject.SetActive(true);
        }

        // Invoke("OzellikOlussun", 3f);
    }

    void OzellikOlussun()
    {
        int RandomSayi = Random.Range(0, OzellikOlusmaNoktalari.Length - 1);
        PotaBuyume.transform.position = OzellikOlusmaNoktalari[RandomSayi].transform.position;
        PotaBuyume.SetActive(true);
    }


    void Update()
    {
        if (Time.timeScale != 0 )
        {

            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);
                Vector3 TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        ParmakPozX = TouchPosition.x - Platform.transform.position.x; 
                        break;
                    case TouchPhase.Moved:
                        if (TouchPosition.x - ParmakPozX > -1.5 && TouchPosition.x - ParmakPozX < 1.5)
                        {
                            Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(TouchPosition.x - ParmakPozX, Platform.transform.position.y, Platform.transform.position.z), .5F);

                        }
                        break;

                }
            }


            if (Input.GetKey(KeyCode.LeftArrow)) // sol ok tusuna basildiginda
            {
                if (Platform.transform.position.x > -1.5)  //duvarýn sol tarafindki mesafeyi ayarladik
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x - .3f, Platform.transform.position.y, Platform.transform.position.z), .050F);
                //yukarida yapilan islem sola götürmek icin yapilan islem
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Platform.transform.position.x < 1.5)
                    Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + .3f, Platform.transform.position.y, Platform.transform.position.z), .050F);
            }
        }

    }

    public void Basket(Vector3 Poz)
    {
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;
        Efektler[0].transform.position = Poz;
        Efektler[0].gameObject.SetActive(true);
        Sesler[1].Play();

        if (BasketSayisi == AtilmasiGerekenTop)
        {

            Kazandin();

        }

        if (BasketSayisi == 1)
        {
            OzellikOlussun();
        }
    }

    public void Kaybettin()
    {

        Sesler[2].Play();
        Paneller[2].SetActive(true);
        Time.timeScale = 0;
    }

    void Kazandin()
    {
        Sesler[3].Play();
        Paneller[1].SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Time.timeScale = 0;
    }

    public void PotaBuyut(Vector3 Poz)
    {
        Efektler[1].transform.position = Poz;
        Efektler[1].gameObject.SetActive(true);
        Sesler[0].Play();
        Pota.transform.localScale = new Vector3(55f, 55f, 55f);
        
    }

    public void ButonlarinÝslemleri(string Deger)
    {

        switch (Deger)
        {
            case "Durdur":
                Time.timeScale = 0;
                Paneller[0].SetActive(true);
                break;

            case "DevamEt":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;

            case "Tekrar":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                break;

            case "SonrakiLevel":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Time.timeScale = 1;
                break;

            case "Ayarlar":

                //ayarlar paneli yapýlabilir.
                break;

        }
    }
}
