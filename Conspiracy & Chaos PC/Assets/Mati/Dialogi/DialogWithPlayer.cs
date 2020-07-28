using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogWithPlayer : MonoBehaviour
{
    //zmienne do inspektora 
    [SerializeField]
    Dialog dialog;
    [SerializeField]
    TextMeshProUGUI textUI;

    //gdy wchodzimy w obszar triggera uruchamiamy funkcje
    private void OnTriggerEnter2D(Collider2D collision)
    {

        StartCoroutine(ChangeDialogWords());
    }
    //IEnumerator pozwala na stworzenie korutyny
    //w tym wypadku możemy użyć funkcjonalności która nam pozwala na 
    //ustawienie odstępu czasowego w wykonaniu funkcji w 
    //tym wpadku to 4 sekundy 
    IEnumerator ChangeDialogWords()
    {
        //ustawiamy pętle która ma za zadanie wyświetlanie dialogu 
        //oraz zmianę po 4 sekundach 
        for (int i = 0; i < dialog.dialogText.Length; i++)
        {

            //tą tablicę stringów mamy w skrypcie Dialog
            textUI.text = dialog.dialogText[i];
            yield return new WaitForSeconds(4);

        }
        //następnie zerujemy tekst aby sie nie pojawił 
        //gdy dialog się zakończy 
        //bo gdybyśmy nie mieli tej linijki to ostani dialog 
        //został by na ekranie
        textUI.text = "";
    }
}
