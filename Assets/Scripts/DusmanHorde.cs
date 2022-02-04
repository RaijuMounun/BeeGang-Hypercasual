using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanHorde : MonoBehaviour
{
    [SerializeField] GameObject dusmanHorde;


    private void OnTriggerEnter()
    {
        for (int i = 0; i < 10; i++)
        {
            AriSpawner.Instance.AriParent.transform.GetChild(i+1).gameObject.SetActive(false);
            dusmanHorde.transform.GetChild(i).gameObject.SetActive(false);
            AriSpawner.Instance.MevcutAriSayi = AriSpawner.Instance.MevcutAriSayi - 1;
        }
        
    }
}
