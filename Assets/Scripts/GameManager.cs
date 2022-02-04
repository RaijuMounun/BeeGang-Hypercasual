using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton, awake burada
    public static GameManager Instance;
    private void Awake() { Instance = this; }
    #endregion

    #region Tan�t�mlar
    bool oyunBitti;
    public TextMesh sayacText;
    public int levelNumber;
    [SerializeField] GameObject pressToStart;
    public bool oyunBasladi;
    #endregion

    #region Update
    private void Update()
    {
        sayacText.text = AriSpawner.mevcutAriSayi.ToString(); //Oyun i�inde ar�lar�n �st�nde yazan toplam ar� say�s�

        #region OyunBasladi
        if (oyunBasladi == true)
        {
            pressToStart.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            pressToStart.GetComponent<MeshRenderer>().enabled = true;
        }
        #endregion

        #region LevelNumber

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level01"))
        {
            levelNumber = 1;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level02"))
        {
            levelNumber = 2;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level03"))
        {
            levelNumber = 3;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level04"))
        {
            levelNumber = 4;
        }
        #endregion

    }
    #endregion

    #region EndGame()
    public void EndGame()
    {
        if (oyunBitti == false)//Engame fonksiyonunu update'de �a��rd���m i�in sadece bir kere �al��mas� i�in bu booldan destek al�yorum
        {
            oyunBitti = true;
            Debug.Log("�LD�N KNK");
            Restart();
        }
    }
    #endregion

    #region Restart
    void Restart()
    {
        if (levelNumber == 1)
        {
            SceneManager.LoadScene("Level01"); //sahneyi tekrar y�kletiyorum
        }
        else if (levelNumber == 2)
        {
            SceneManager.LoadScene("Level02"); //sahneyi tekrar y�kletiyorum
        }
        else if (levelNumber == 3)
        {
            SceneManager.LoadScene("Level03"); //sahneyi tekrar y�kletiyorum
        }
        else if (levelNumber == 4)
        {
            SceneManager.LoadScene("Level04"); //sahneyi tekrar y�kletiyorum
        }
    }
    #endregion

    public void CikisTus()
    {
        Application.Quit();
    }
}
