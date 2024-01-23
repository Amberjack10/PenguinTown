using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupStartMenu : MonoBehaviour
{
    [SerializeField] private InputField inputField;     // �÷��̾� �̸� �Է�â
    [SerializeField] private TextMeshProUGUI playerName;        // �÷��̾��� �̸�
    [SerializeField] private Button characterSelectButton;      // ĳ���� ���� UI Ű�� ��ư
    [SerializeField] private Image SelectedCharacter;       // �÷��̾ ������ ĳ����

    [SerializeField] private GameObject popupCharacterSelectMenu;

    // ĳ���� ����â ����
    public void OnClickSelectCharacter()
    {
        popupCharacterSelectMenu.SetActive(true);
    }

    // ĳ���� ����â���� �÷��̾ ���� ��ư�� index ���� characterType���� ����
    public void GetSelectedCharacter(int index)
    {
        GameManager.Instance.characterType = (CharacterType)index;      // �÷��̾ ������ ĳ���� �ε����� characterType���� ����

        // GameManager.Instance.characterList���� ������ characterType�� ���� ĳ���͸� ��������
        var character = GameManager.Instance.characterList.Find(item => item.CharacterType == GameManager.Instance.characterType);

        SelectedCharacter.sprite = character.CharacterSprite;
        SelectedCharacter.SetNativeSize();      // SetNativeSize() : ĳ���� ��������Ʈ�� UIâ ũ�⿡ �°� �ڵ����� ����
        SetCharacterImage(GameManager.Instance.characterType, SelectedCharacter);

        popupCharacterSelectMenu.SetActive(false);
    }

    // Penguin�� Dwarf�� �̹��� ũ�Ⱑ ���� �ʹ� �޶� ����� ����ϰ� �����ϱ�
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

    // Join ��ư ó���ϱ�
    public void OnClickJoin()
    {
        // ���� �÷��̾ �Է��� �̸��� null�̰ų� 2 ~ 10 ������ string�� �ƴ� ��� return;
        if (string.IsNullOrEmpty(inputField.text) || !(inputField.text.Length > 2 && inputField.text.Length < 10))
        {
            return;
        }
        GameManager.Instance.SetCharacter(inputField.text);     // �÷��̾��� ĳ���� �����ϱ�

        Destroy(gameObject);
    }
}
