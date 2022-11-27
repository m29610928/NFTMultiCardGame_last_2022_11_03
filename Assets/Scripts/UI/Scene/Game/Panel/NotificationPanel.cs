using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class NotificationPanel : UI_Base
{
    enum GameObjects{
		NotificationText,
    }

	public TMP_Text notificationTMP;

	void Start()
	{
		Init();
	}

	public override void Init()
	{
		Bind<GameObject>(typeof(GameObjects));
		notificationTMP = Get<GameObject>((int)GameObjects.NotificationText).GetComponent<TMP_Text>();

		ScaleZero();
	}

	[ContextMenu("ScaleOne")]
	void ScaleOne() => transform.localScale = Vector3.one;

	[ContextMenu("ScaleZero")]
	public void ScaleZero() => transform.localScale = Vector3.zero;



	public void Show(string message)
	{
		notificationTMP.text = message;
		Sequence sequence = DOTween.Sequence()
			.Append(transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.InOutQuad))
			.AppendInterval(0.9f)
			.Append(transform.DOScale(Vector3.zero, 0.4f).SetEase(Ease.InOutQuad));
	}
}