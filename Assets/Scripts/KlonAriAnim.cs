using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonAriAnim : MonoBehaviour
{
    #region De�i�kenler
    [SerializeField] bool enAlt = true;
    [SerializeField] bool enUst = false;
    Vector3 baslangicPos;
    #endregion

    #region Start
    private void Start()
    {
        baslangicPos = transform.position; //klon ar�lar�n ba�lang�� pozisyon de�erini tutuyorum
    }
    #endregion

    #region Update
    private void Update()
    {
        if(transform.position.y <= baslangicPos.y) //klon ar�lar�n y de�erleri ba�lang�� pozisyonundan d���k veya e�itse
        {
            enAlt = true;
            enUst = false;
        }
        
        if(transform.position.y >= baslangicPos.y +1.6f) //klon ar�lar�n y de�erleri ba�lang�� pozisyonundan y�ksek veya e�itse
        {
            enAlt = false;
            enUst = true;
        }
        


        if (enAlt == true)
        {
            //y de�erini y�kselterek yukar� hareket ettiriyorum
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y+2f, transform.position.z), Time.deltaTime); 
        }

        if(enUst==true)
        {
            //y de�erini d���rerek a�a�� hareket ettiriyorum
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y-2f, transform.position.z), Time.deltaTime);
        }
    }
    #endregion
}
