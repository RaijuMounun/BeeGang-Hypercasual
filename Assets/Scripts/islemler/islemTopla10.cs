using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemTopla10 : MonoBehaviour
{

    #region De�i�kenler
    [SerializeField] GameObject gecilenKapi; //mevcut kap�, inspectore yok edebilsin diye ekliyorum
    [SerializeField] GameObject dostParent; //Kap�da duran dost ar�lar�n ba�l� oldu�u parent
    [SerializeField] GameObject yanKapi; //yan kap�, inspectore yok edebilsin diye ekliyorum
    [SerializeField] int kapiSayac = 0; //kap�n�n �retti�i ar�lar� say�yor
    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ari") //Ari tagine sahip sadece klon ar�lar�n parent� var
        {
            gecilenKapi.GetComponent<BoxCollider>().enabled = false; //kap�n�n collider�n� sorun ��kmas�n diye kapat�yorum
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kap�n�n collider�n� kapat�yorum
            AriActivate15arti();
        }
    }
    #endregion

    #region AriActivate5arti
    void AriActivate15arti()
    {
        for (int i = 0; i < 10; i++)
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i + AriSpawner.mevcutAriSayi + 1).gameObject.SetActive(true);//dost ar�lar� aktif ediyor
            dostParent.transform.GetChild(i).gameObject.SetActive(false);//kap�daki dost ar�lar� kapat�yor
            kapiSayac += 1;//ka� ar� a��ld���n� say�yor
        }
        AriSpawner.mevcutAriSayi += kapiSayac; //kap�n�n a�t��� ar�lar� toplam ar� say�s�na ekliyor
    }
    #endregion
}