using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Guc : MonoBehaviour
{
    [SerializeField] private float Aci; // platformun yüzlerinin açýlarý
    [SerializeField] private float UygulanacakGuc;  // platformdan sekme miktarý

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Aci, 90, 0) * UygulanacakGuc, ForceMode.Force);   // Platformdan topa uygulanacak gücü ve açýyý yerine yazdýk
    }
}
