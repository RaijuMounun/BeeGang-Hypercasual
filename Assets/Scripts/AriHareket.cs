using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriHareket : MonoBehaviour
{
    #region Tan�tmalar
    public bool isTouching;
    private float touchPosX;
    [SerializeField] float xAxisHizi = 60f;
    #endregion

    #region Singleton, awake burada
    public static AriHareket Instance;
    private void Awake() { Instance = this; }
    #endregion

    #region Update
    void Update() 
    { 
        GetInput();

        #region ana ar� animasyon @@@@@ AKT�F DE��L @@@@@
        /*if (transform.position.y <= baslangicPos.y)
        {
            enAlt = true;
            enUst = false;
            Debug.Log("enalt true oldu, enust false");
        }

        if (transform.position.y >= baslangicPos.y + 1.6f)
        {
            enAlt = false;
            enUst = true;
            Debug.Log("enalt false oldu, enust true");
        }



        if (enAlt == true)
        {
            //transform.Translate(new Vector3.Lerp(0, yEksenHiz * Time.deltaTime, 0));
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y + 2f, transform.position.z), Time.deltaTime);
            Debug.Log("enAlt true transform position kodu �al��t�");
        }

        if (enUst == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y - 2f, transform.position.z), Time.deltaTime);
            Debug.Log("enUst true transform position kodu �al��t�");
        }*/
        #endregion
    }
    #endregion

    #region FixedUpdate
    private void FixedUpdate()
    {
        if (isTouching) //E�er kullan�c� ekrana dokunuyorsa
        {
            touchPosX += Input.GetAxis("Mouse X") * xAxisHizi * Time.fixedDeltaTime;//touchposx'i farenin x de�eri * verdi�im xaxishizi * deltatime'a e�itle
        }
        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z); //Ar�n�n x de�erini touchposx'e e�itle
    }
    #endregion

    #region GetInput()
    void GetInput() //farenin bas�p basmad���n� kontrol ediyor
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
            GameManager.Instance.oyunBasladi = true;
        }
        else
        {
            isTouching = false;
        }
    }
    #endregion
}
