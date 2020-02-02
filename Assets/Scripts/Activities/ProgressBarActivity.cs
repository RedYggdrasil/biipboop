using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarActivity : Activity
{
	[SerializeField] protected LocalHud _progressBar;
	float alreadyDoneProgression = 0f;
	public override bool canCancelActivity => true;

	public override void OnActivityCanceled(Character chara)
	{
		base.OnActivityCanceled(chara);
	}
	protected override IEnumerator OnReachedActivityCoroutine(float wait, Character chara)
	{
		float StartTime = Time.time;

		float endTime = ((StartTime + wait) - alreadyDoneProgression);

		while (Time.time < endTime)
		{
			if (_canceledCharacter.Contains(chara))
			{
				_canceledCharacter.Remove(chara);
				alreadyDoneProgression += Time.time - StartTime;
				yield break;
			}
			_progressBar.UpdateProgress(((Time.time - StartTime) + alreadyDoneProgression) / wait);
			yield return null;
		}
		_progressBar.UpdateProgress(1f);
		OnDone(chara);
	}
	
}
