using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islemEksi5 : MonoBehaviour
{
    #region Tan�t�mlar
    [SerializeField] GameObject kapiCollider;//ge�ilen kap�n�n collider�
    [SerializeField] GameObject dusmanParent;//kap�daki d��man ar�lar�n parenti
    [SerializeField] GameObject yanKapi; //yan kap�, inspectore yok edebilsin diye ekliyorum
    #endregion

    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ari") //ari tagine sahip sadece clone ar�lar�n parent� var.
        {
            kapiCollider.GetComponent<BoxCollider>().enabled = false; //ge�ilen kap�n�n collider�n� kapat�yorum ki sorun ��kmas�n
            yanKapi.GetComponent<BoxCollider>().enabled = false;//varsa yandaki kap�n�n collider�n� kapat�yorum
            AriDectivateEksiAlti();
        }
    }
    #endregion

    #region AriDeactivateEksiAlti
    void AriDectivateEksiAlti()
    {
        for (int i = 0; i < 5; i++)
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i+2).gameObject.SetActive(false);//Dost ar�y� kapat�yor
            dusmanParent.transform.GetChild(i).gameObject.SetActive(false);//Du�man ar�y� kapat�yor
        }
        AriSpawner.mevcutAriSayi += -5;//toplam ar� say�s�ndan 6 ��kar�yor
    }
    #endregion
}
