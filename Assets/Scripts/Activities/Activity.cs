using UnityEngine;

public abstract class Activity : MonoBehaviour
{
	[SerializeField] public float positionRange;
	[SerializeField] public float imobilizeSeconds;
	public virtual Transform positionTarget
	{
		get
		{
			return transform;
		}
	}
	public abstract void OnReached(Character chara);
	public abstract void OnDone(Character chara);

}
