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
    [SerializeField] private Image SelectedCharacter;

    [SerializeField] private GameObject popupCharacterSelectMenu;


    public void OnClickSelectCharacter()
    {
        popupCharacterSelectMenu.SetActive(true);
    }

    public void GetSelectedCharacter(int index)
    {
        GameManager.Instance.characterType = (CharacterType)index;

        var character = GameManager.Instance.characterList.Find(item => item.CharacterType == GameManager.Instance.characterType);

        SelectedCharacter.sprite = character.CharacterSprite;
        SelectedCharacter.SetNativeSize();
        SetCharacterImage(GameManager.Instance.characterType, SelectedCharacter);

        popupCharacterSelectMenu.SetActive(false);
    }

    public void SetCharacterImage(CharacterType c, Image image)
    {
        float scale = 0;
        float PosY = 0;

        switch (c)
        {
            case CharacterType.Penguin:
                scale = 1;
                PosY = 100f;
                break;
            case CharacterType.Dwarf:
                scale = 1.5f;
                PosY = 50;
                break;
        }

        SelectedCharacter.transform.localScale = new Vector3(scale, scale, 0);
        SelectedCharacter.transform.localPosition = new Vector3(0, PosY, 0);
    }

    public void OnClickJoin()
    {
        if (string.IsNullOrEmpty(inputField.text) || !(inputField.text.Length > 2 && inputField.text.Length < 10))
        {
            return;
        }
        GameManager.Instance.SetCharacter(inputField.text);

        Destroy(gameObject);
    }
}
