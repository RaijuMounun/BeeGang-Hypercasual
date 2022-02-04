using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemTopla10 : MonoBehaviour
{

    #region Deðiþkenler
    [SerializeField] GameObject gecilenKapi; //mevcut kapý, inspectore yok edebilsin diye ekliyorum
    [SerializeField] GameObject dostParent; //Kapýda duran dost arýlarýn baðlý olduðu parent
    [SerializeField] GameObject yanKapi; //yan kapý, inspectore yok edebilsin diye ekliyorum
    [SerializeField] int kapiSayac = 0; //kapýnýn ürettiði arýlarý sayýyor
    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ari") //Ari tagine sahip sadece klon arýlarýn parentý var
        {
            gecilenKapi.GetComponent<BoxCollider>().enabled = false; //kapýnýn colliderýný sorun çýkmasýn diye kapatýyorum
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kapýnýn colliderýný kapatýyorum
            AriActivate15arti();
        }
    }
    #endregion

    #region AriActivate5arti
    void AriActivate15arti()
    {
        for (int i = 0; i < 10; i++)
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i + AriSpawner.mevcutAriSayi + 1).gameObject.SetActive(true);//dost arýlarý aktif ediyor
            dostParent.transform.GetChild(i).gameObject.SetActive(false);//kapýdaki dost arýlarý kapatýyor
            kapiSayac += 1;//kaç arý açýldýðýný sayýyor
        }
        AriSpawner.mevcutAriSayi += kapiSayac; //kapýnýn açtýðý arýlarý toplam arý sayýsýna ekliyor
    }
    #endregion
}