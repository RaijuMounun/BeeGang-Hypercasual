using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AriSpawner : MonoBehaviour {

    #region Singleton, awake burada
    public static AriSpawner Instance;
    private void Awake() { Instance = this; }
    #endregion
    
    #region Deðiþkenler
    [SerializeField] GameObject ariPrefab;
    [SerializeField] int ariBaslangicSpawnSayi;
    public int MevcutAriSayi; //inspectorde görmek için
    public static int mevcutAriSayi;
    public GameObject AriParent;
    #endregion

    #region Start, baþlangýç arý spawn
    private void Start() //Yalnýzca baþlangýçta, girdiðim deðer kadar arýyý spawn eyliyor
    {
        mevcutAriSayi = 1; //baþlangýçta 1'e eþitliyorum

        for (int i = 0; i < ariBaslangicSpawnSayi; i++) //arýlarý spawn eyleyen döngü
        {
            GameObject Ari2 = Instantiate(ariPrefab, AriParent.transform.position + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)), AriParent.transform.rotation); //Ari'yi spawn eyleyen komut
            Ari2.tag = "AriClone"; //klon arýlarýn tagi
            Ari2.name = "KlonAri " + (i+1); //klon arýlarýn isimlendirilmesi
            Ari2.transform.parent = AriParent.transform; //Klon arýlarý parentýnýn altýnda spawn eylemek için
            Ari2.SetActive(false);//Spawn eylenen arýlarýn oyun baþýnda deaktive olmasý
        }
    }
    #endregion

    #region Update
    private void Update() 
    { 
        MevcutAriSayi = mevcutAriSayi;//sayacý inspectorde görmek için

        if (mevcutAriSayi <= 0)//Oyunda arý kalmadýysa
        {
            GameManager.Instance.EndGame();//endgame fonksiyonunu çaðýr
        }
    }
    #endregion
}
