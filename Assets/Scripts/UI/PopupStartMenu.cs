using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupStartMenu : MonoBehaviour
{
    [SerializeField] private InputField inputField;     // 플레이어 이름 입력창
    [SerializeField] private TextMeshProUGUI playerName;        // 플레이어의 이름
    [SerializeField] private Button characterSelectButton;      // 캐릭터 변경 UI 키는 버튼
    [SerializeField] private Image SelectedCharacter;       // 플레이어가 선택한 캐릭터

    [SerializeField] private GameObject popupCharacterSelectMenu;

    // 캐릭터 선택창 띄우기
    public void OnClickSelectCharacter()
    {
        popupCharacterSelectMenu.SetActive(true);
    }

    // 캐릭터 선택창에서 플레이어가 누른 버튼의 index 값을 characterType으로 지정
    public void GetSelectedCharacter(int index)
    {
        GameManager.Instance.characterType = (CharacterType)index;      // 플레이어가 선택한 캐릭터 인덱스를 characterType으로 변경

        // GameManager.Instance.characterList에서 선택한 characterType과 같은 캐릭터를 가져오기
        var character = GameManager.Instance.characterList.Find(item => item.CharacterType == GameManager.Instance.characterType);

        SelectedCharacter.sprite = character.CharacterSprite;
        SelectedCharacter.SetNativeSize();      // SetNativeSize() : 캐릭터 스프라이트를 UI창 크기에 맞게 자동으로 조정
        SetCharacterImage(GameManager.Instance.characterType, SelectedCharacter);

        popupCharacterSelectMenu.SetActive(false);
    }

    // Penguin과 Dwarf의 이미지 크기가 서로 너무 달라 사이즈를 비슷하게 변경하기
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

    // Join 버튼 처리하기
    public void OnClickJoin()
    {
        // 만약 플레이어가 입력한 이름이 null이거나 2 ~ 10 길이의 string이 아닐 경우 return;
        if (string.IsNullOrEmpty(inputField.text) || !(inputField.text.Length > 2 && inputField.text.Length < 10))
        {
            return;
        }
        GameManager.Instance.SetCharacter(inputField.text);     // 플레이어의 캐릭터 설정하기

        Destroy(gameObject);
    }
}
