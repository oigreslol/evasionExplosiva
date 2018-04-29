using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour {

    [SerializeField] private Text text;
    public float coolDownTimer;
    public bool listo = false;
    public bool necesito = false;
    // Update is called once per frame
    void Update()
    {
        //si el tamaño igual a 0,enabled igual a falso , texto va a ser igual a coolDowntimer
        if (coolDownTimer > 0)
        {
            if (necesito)
            {
                text.gameObject.SetActive(true);
            
                text.text = "" + (int)coolDownTimer;
            }
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
            if (necesito)
            {
                text.text = "";
            }
            listo = true;
        }
    }
}

