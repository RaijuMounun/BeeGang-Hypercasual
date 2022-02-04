using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemEksi5 : MonoBehaviour
{
    #region Tanýtýmlar
    [SerializeField] GameObject kapiCollider;//geçilen kapýnýn colliderý
    [SerializeField] GameObject dusmanParent;//kapýdaki düþman arýlarýn parenti
    [SerializeField] GameObject yanKapi; //yan kapý, inspectore yok edebilsin diye ekliyorum
    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ari") //ari tagine sahip sadece clone arýlarýn parentý var.
        {
            kapiCollider.GetComponent<BoxCollider>().enabled = false; //geçilen kapýnýn colliderýný kapatýyorum ki sorun çýkmasýn
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kapýnýn colliderýný kapatýyorum
            AriDectivateEksiAlti();
        }
    }
    #endregion

    #region AriDeactivateEksiAlti
    void AriDectivateEksiAlti()
    {
        for (int i = 0; i < 5; i++)
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i+2).gameObject.SetActive(false);//Dost arýyý kapatýyor
            dusmanParent.transform.GetChild(i).gameObject.SetActive(false);//Duþman arýyý kapatýyor
        }
        AriSpawner.mevcutAriSayi += -5;//toplam arý sayýsýndan 6 çýkarýyor
    }
    #endregion
}
