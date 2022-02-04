using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YolHareket : MonoBehaviour
{
    #region Singleton, awake burada
    public static YolHareket Instance;
    private void Awake() { Instance = this; }
    #endregion

    #region Tanýmlamalar
    [SerializeField] float hareketHizi=15f;
    public static bool isDead;
    #endregion

    #region Update, sadece isDead var
    private void Update()
    {
        if (AriSpawner.Instance.MevcutAriSayi <= 0) //arý kalmadýysa isdead true oluyor, true iken yol ve gateler vs. hareket etmiyor
        {
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        if (isDead == false && GameManager.Instance.oyunBasladi == true)
        {
            transform.Translate(0, 0, -hareketHizi * Time.deltaTime); //yolun hareketi
        }
    }
    #endregion
}
