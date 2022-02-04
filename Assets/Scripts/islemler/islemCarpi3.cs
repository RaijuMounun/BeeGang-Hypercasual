using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemCarpi3 : MonoBehaviour
{
    #region De�i�kenler
    [SerializeField] GameObject gecilenKapi;
    [SerializeField] GameObject yanKapi;
    [SerializeField] GameObject dostParent; //Kap�da duran dost ar�lar�n ba�l� oldu�u parent
    [SerializeField] int kapiSayac = 0;
    #endregion

    #region OnTriggerEnter, kap�lar� yok ediyor ve AriActivate2x fonksiyonunu �a��r�yor
    private void OnTriggerEnter(Collider other) //kap�n�n collider�na temas olursa
    {
        if (other.tag == "Ari")//kap�dan ge�enin tagi ari ise
        {
            gecilenKapi.GetComponent<BoxCollider>().enabled = false;//ge�ti�i kap�n�n collider�n� kapat�yorum
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kap�n�n collider�n� kapat�yorum
            AriActivate2x();
        }
    }
    #endregion

    #region AriActivate2x
    void AriActivate2x()
    {
        for (int i = 0; i < ((AriSpawner.mevcutAriSayi * 2)); i++)//mevcut ar� say�s� kadar ar� a�an d�ng�
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i + AriSpawner.mevcutAriSayi + 1).gameObject.SetActive(true);//Ariparent'�n son a��k olan child�ndan itibaren bir ar� a��yor
            //dostParent.transform.GetChild(i).gameObject.SetActive(false);//kap�daki dost ar�lar� kapat�yor
            kapiSayac += 1;//kap�n�n ka� ar� �retti�ini say�yor
        }
        AriSpawner.mevcutAriSayi += kapiSayac;//kap�n�n �retti�i ar�lar� mevcut ar� say�s�na ekliyor
    }
    #endregion
}
