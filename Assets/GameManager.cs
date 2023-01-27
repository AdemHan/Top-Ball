using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;

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
    }

    // Update is called once per frame
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
}
