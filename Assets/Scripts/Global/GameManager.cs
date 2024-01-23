using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Character> characterList = new List<Character>();
    public TextMeshProUGUI playerName;
    public CharacterType characterType;

    public Animator playerAnimatorController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetCharacter(string name)
    {
        
        var character = characterList.Find(item => item.CharacterType == characterType);

        playerAnimatorController.runtimeAnimatorController = character.CharacterAnimatorController;
        playerName.text = name;
    }
}
