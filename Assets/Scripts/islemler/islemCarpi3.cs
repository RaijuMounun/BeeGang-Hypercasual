using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemCarpi3 : MonoBehaviour
{
    #region Deðiþkenler
    [SerializeField] GameObject gecilenKapi;
    [SerializeField] GameObject yanKapi;
    [SerializeField] GameObject dostParent; //Kapýda duran dost arýlarýn baðlý olduðu parent
    [SerializeField] int kapiSayac = 0;
    #endregion

    #region OnTriggerEnter, kapýlarý yok ediyor ve AriActivate2x fonksiyonunu çaðýrýyor
    private void OnTriggerEnter(Collider other) //kapýnýn colliderýna temas olursa
    {
        if (other.tag == "Ari")//kapýdan geçenin tagi ari ise
        {
            gecilenKapi.GetComponent<BoxCollider>().enabled = false;//geçtiði kapýnýn colliderýný kapatýyorum
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kapýnýn colliderýný kapatýyorum
            AriActivate2x();
        }
    }
    #endregion

    #region AriActivate2x
    void AriActivate2x()
    {
        for (int i = 0; i < ((AriSpawner.mevcutAriSayi * 2)); i++)//mevcut arý sayýsý kadar arý açan döngü
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i + AriSpawner.mevcutAriSayi + 1).gameObject.SetActive(true);//Ariparent'ýn son açýk olan childýndan itibaren bir arý açýyor
            //dostParent.transform.GetChild(i).gameObject.SetActive(false);//kapýdaki dost arýlarý kapatýyor
            kapiSayac += 1;//kapýnýn kaç arý ürettiðini sayýyor
        }
        AriSpawner.mevcutAriSayi += kapiSayac;//kapýnýn ürettiði arýlarý mevcut arý sayýsýna ekliyor
    }
    #endregion
}
