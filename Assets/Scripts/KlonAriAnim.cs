using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonAriAnim : MonoBehaviour
{
    #region Deðiþkenler
    [SerializeField] bool enAlt = true;
    [SerializeField] bool enUst = false;
    Vector3 baslangicPos;
    #endregion

    #region Start
    private void Start()
    {
        baslangicPos = transform.position; //klon arýlarýn baþlangýç pozisyon deðerini tutuyorum
    }
    #endregion

    #region Update
    private void Update()
    {
        if(transform.position.y <= baslangicPos.y) //klon arýlarýn y deðerleri baþlangýç pozisyonundan düþük veya eþitse
        {
            enAlt = true;
            enUst = false;
        }
        
        if(transform.position.y >= baslangicPos.y +1.6f) //klon arýlarýn y deðerleri baþlangýç pozisyonundan yüksek veya eþitse
        {
            enAlt = false;
            enUst = true;
        }
        


        if (enAlt == true)
        {
            //y deðerini yükselterek yukarý hareket ettiriyorum
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y+2f, transform.position.z), Time.deltaTime); 
        }

        if(enUst==true)
        {
            //y deðerini düþürerek aþaðý hareket ettiriyorum
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, baslangicPos.y-2f, transform.position.z), Time.deltaTime);
        }
    }
    #endregion
}
