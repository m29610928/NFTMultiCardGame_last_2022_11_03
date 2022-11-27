using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : UI_Base
{
	enum GameObjects
	{
		LobbyButton,
		ResultText,
	}

	public Button lobbyButton;
	public TMP_Text resultText;

	void Start()
	{
		Init();
	}

	public override void Init()
	{
		ScaleZero();

		Bind<GameObject>(typeof(GameObjects));
		lobbyButton = Get<GameObject>((int)GameObjects.LobbyButton).GetComponent<Button>();
		resultText = Get<GameObject>((int)GameObjects.ResultText).GetComponent<TMP_Text>();

		lobbyButton.gameObject.BindEvent((PointerEventData) => {
			Managers.Sound.Play("Button", Define.Sound.Effect);
			if (Managers.Scene.CurrentScene.SceneType == Define.Scene.MultiGame)
				NetworkManager.Inst.LeaveRoom();
			else if (Managers.Scene.CurrentScene.SceneType == Define.Scene.Game)
				Managers.Scene.LoadScene(Define.Scene.Lobby);
		});
	}

	public void Show(string message)
	{
		resultText.text = message;
		transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutQuad);
	}

	public void SetBlueColor()
    {
		resultText.color = Color.blue;
	}

	public void SetRedColor()
	{
		resultText.color = Color.red;
	}

	[ContextMenu("ScaleOne")]
	void ScaleOne() => transform.localScale = Vector3.one;

	[ContextMenu("ScaleZero")]
	public void ScaleZero() => transform.localScale = Vector3.zero;
}
