using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Guc : MonoBehaviour
{
    [SerializeField] private float Aci; // platformun y�zlerinin a��lar�
    [SerializeField] private float UygulanacakGuc;  // platformdan sekme miktar�

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Aci, 90, 0) * UygulanacakGuc, ForceMode.Force);   // Platformdan topa uygulanacak g�c� ve a��y� yerine yazd�k
    }
}
