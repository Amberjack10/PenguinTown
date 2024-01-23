# PenguinTown
 Making a clone of Zep

 # 코드별 기능
 ## CameraController.cs
 카메라가 플레이어를 따라 움직일 수 있게 하는 코드. 
 카메라가 맵의 범위 밖을 벗어나지 못하도록 카메라 범위의 최소, 최대값 설정

 ## PenguinTownCharacterController.cs
 캐릭터의 움직임 이벤트들을 설정. 
 OnMoveEvent, OnLookEvent를 선언하여 이벤트를 발생.

 ## PlayerInputController.cs
 CharacterController를 상속 받아 OnMove, OnLook 이벤트를 선언함.

 ## PenguinTownMovement.cs
 플레이어에 추가하여 플레이어의 움직임을 구현.
 CharacterController를 GetComponent하여 OnMoveEvent를 구독한다. 
 이후, Move 이벤트 발생 시 ApplyMovemnet를 통해 캐릭터의 rigidbody의 velocity 값을 변경하여 움직임.

 ## PenguinTownAnimations.cs
 Animator를 선언, CharacterController를 상속 받아 Awake()에서 GetComponent.

 ## PenguinTownAnimationController.cs
 PenguinTownAnimations을 상속 받아 CharacterController에서 OnMove 이벤트를 구독, 이벤트 호출 시 Move를 통해 캐릭터의 run 애니메이션 재생

 ## Character.cs
 캐릭터 클래스와 enum CharacterType을 선언. Serializable을 통해 캐릭터 클래스를 직렬화시킴.

 ## PenguinTownAimRotation.cs
 캐릭터의 마우스 움직임에 따른 스프라이트 좌우 반전을 처리. 
 CharacterController를 GetComponent하여 OnLookEvent를 구독한다. 
 이후, Look 이벤트 발생 시, RotateAim을 통해 캐릭터의 Postion Z의 절대값이 90도 보다 커지면 캐릭터의 스프라이트를 좌우 반전함.
 
 ## PopupStartMenu.cs
 플레이어의 캐릭터 선택 및 플레이어 이름을 설정 받는 UI PopupStartMenu의 동작 처리.
 GameManager에 선언되어 있는 characterList에서 characterList.Find(item => item.CharacterType == GameManager.Instance.characterType)을 통해 플레이어가 선택한 캐릭터의 스프라이트를 가져온다.
 이후, 플레이어가 Join 버튼을 누르면 OnClickJoin()에서 GameManager에 있는 SetCharacter에 이름을 넘긴다.

 ## GameManager.cs
 characterList와 characterType를 통해 playerName, playerAnimatorController을 설정하여 플레이어의 캐릭터 스프라이트와 애니메이션, 이름을 변경한다.
 PopupStartMenu에서 SetCharacter를 호출하면 현재 GameManager의 characterType과 일치하는 character를 리스트에서 찾아 playerAnimatorController.runtimeAnimatorController를 변경한다.
