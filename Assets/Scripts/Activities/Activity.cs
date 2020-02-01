using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity : MonoBehaviour
{
	[SerializeField] public float positionRange;
	[SerializeField] public float imobilizeSeconds;
	public List<Character> _canceledCharacter = new List<Character>();
	public virtual Transform positionTarget
	{
		get
		{
			return transform;
		}
	}
	public virtual bool canCancelActivity
	{
		get
		{
			return true;
		}
	}
	public virtual bool playerInteractibleActivity
	{
		get
		{
			return true;
		}
	}
	protected virtual void Awake()
	{

	}


	public virtual void OnActivityCanceled(Character chara)
	{
		Debug.LogWarning("Ask cancel activity for " + chara.gameObject.name + " activity " + this.gameObject.name);
		if (canCancelActivity)
		{
			_canceledCharacter.Add(chara);
		}
	}
	public virtual void OnDone(Character chara)
	{
		chara.OnActivityFinished(this);
	}

	public virtual void OnReached(Character chara)
	{
		StartCoroutine(OnReachedActivityCoroutine(imobilizeSeconds, chara));
	}
	protected virtual IEnumerator OnReachedActivityCoroutine(float wait, Character chara)
	{
		if (wait > 0f)
		{
			yield return new WaitForSeconds(wait);
		}

		if (_canceledCharacter.Contains(chara))
		{
			_canceledCharacter.Remove(chara);
		}
		else
		{
			OnDone(chara);
		}
	}
}
