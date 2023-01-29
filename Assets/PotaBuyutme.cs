using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    IEnumerator Start()
    {
        Sure.text = BaslangicSuresi.ToString();

        while (true)
        {

            yield return new WaitForSeconds(1f);
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();

            if (BaslangicSuresi == 0)
            {
                gameObject.SetActive(false);
                break;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Carpma Var");
    }
}
