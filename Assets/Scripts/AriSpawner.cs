using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AriSpawner : MonoBehaviour {

    #region Singleton, awake burada
    public static AriSpawner Instance;
    private void Awake() { Instance = this; }
    #endregion
    
    #region De�i�kenler
    [SerializeField] GameObject ariPrefab;
    [SerializeField] int ariBaslangicSpawnSayi;
    public int MevcutAriSayi; //inspectorde g�rmek i�in
    public static int mevcutAriSayi;
    public GameObject AriParent;
    #endregion

    #region Start, ba�lang�� ar� spawn
    private void Start() //Yaln�zca ba�lang��ta, girdi�im de�er kadar ar�y� spawn eyliyor
    {
        mevcutAriSayi = 1; //ba�lang��ta 1'e e�itliyorum

        for (int i = 0; i < ariBaslangicSpawnSayi; i++) //ar�lar� spawn eyleyen d�ng�
        {
            GameObject Ari2 = Instantiate(ariPrefab, AriParent.transform.position + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)), AriParent.transform.rotation); //Ari'yi spawn eyleyen komut
            Ari2.tag = "AriClone"; //klon ar�lar�n tagi
            Ari2.name = "KlonAri " + (i+1); //klon ar�lar�n isimlendirilmesi
            Ari2.transform.parent = AriParent.transform; //Klon ar�lar� parent�n�n alt�nda spawn eylemek i�in
            Ari2.SetActive(false);//Spawn eylenen ar�lar�n oyun ba��nda deaktive olmas�
        }
    }
    #endregion

    #region Update
    private void Update() 
    { 
        MevcutAriSayi = mevcutAriSayi;//sayac� inspectorde g�rmek i�in

        if (mevcutAriSayi <= 0)//Oyunda ar� kalmad�ysa
        {
            GameManager.Instance.EndGame();//endgame fonksiyonunu �a��r
        }
    }
    #endregion
}
