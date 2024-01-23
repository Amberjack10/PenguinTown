using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupStartMenu : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private Button characterSelectButton;

    public void OnClickSelectCharacter()
    {

        Debug.Log("SelectCharacter");
    }

    public void OnClickJoin()
    {
        if (string.IsNullOrEmpty(inputField.text) || !(inputField.text.Length > 2 && inputField.text.Length < 10))
        {
            return;
        }

        playerName.text = inputField.text;

        Destroy(gameObject);
    }
}