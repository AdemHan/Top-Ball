using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("---LEVEL TEMEL OBJELERÝ")]
    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Pota;
    [SerializeField] private GameObject PotaBuyume;
    [SerializeField] private GameObject[] OzellikOlusmaNoktalari;

    [Header("---UI OBJELERÝ")]
    [SerializeField] private Image[] GorevGorselleri;
    [SerializeField] private Sprite GorevTamamSprite;
    [SerializeField] private int AtilmasiGerekenTop;
    int BasketSayisi;

    void Start()
    {
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
        if (Input.GetKey(KeyCode.LeftArrow)) // sol ok tusuna basildiginda
        {
            if (Platform.transform.position.x > -1.5)  //duvarýn sol tarafindki mesafeyi ayarladik
                Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x -.3f, Platform.transform.position.y, Platform.transform.position.z), .050F);
            //yukarida yapilan islem sola götürmek icin yapilan islem
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Platform.transform.position.x < 1.5)
                Platform.transform.position = Vector3.Lerp(Platform.transform.position, new Vector3(Platform.transform.position.x + .3f, Platform.transform.position.y, Platform.transform.position.z), .050F);
        }

    }

    public void Basket()
    {
        BasketSayisi++;
        GorevGorselleri[BasketSayisi - 1].sprite = GorevTamamSprite;
        //BasketSayisi
        // GorevGorselleri[i]

        if (BasketSayisi == AtilmasiGerekenTop)
        {
            Debug.Log("Kazandýn");
        }
        if (BasketSayisi == 1)
        {
            OzellikOlussun();
        }
    }

    public void Kaybettin()
    {
        Debug.Log("Kaybettin");
    }

    public void PotaBuyut()
    {
        Pota.transform.localScale = new Vector3(55f, 55f, 55f);
    }
}
