using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private BotObject[] _botObjects;
    [SerializeField] public List<BotParts> _botParts;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        _botObjects = new BotObject[] { BotObject.EmptyObject, BotObject.EmptyObject, BotObject.EmptyObject, BotObject.EmptyObject };
        ProgressToNextObject(0);
    }
    public void OnPickUpObjectObject(BotObject part)
    {
        int partIndex = GetBodypartIndex (part);
        Debug.LogWarning("Picked Item : " + part + " of wave : " + partIndex);
        if (_botObjects[partIndex] != BotObject.EmptyObject)
        {
            return;
        }
        else if (partIndex < 3)
        {
            _botObjects[partIndex] = part;
            ProgressToNextObject(++partIndex);

        }
        else
        {
            OnGameWon();
        }
    }
    public void ProgressToNextObject(int index)
    {
        Debug.LogWarning("Load Items : " + index);
        if (index > 0)
        {
            foreach (GameObject go in _botParts[index - 1].parts)
            {
                go.SetActive(false);
            }
        }
        else
        {
            for (int i = 1; i < _botParts.Count; ++i)
            {
                foreach (GameObject go in _botParts[i].parts)
                {
                    go.SetActive(false);
                }
            }
        }
        foreach(GameObject go in _botParts[index].parts)
        {
            go.SetActive(true);
        }
        UIInGame.instance.OnEnterStep(index);
    }
    public void OnGameWon()
    {
        Debug.LogWarning("You won!");
    }
    public BotObject BotPart(){ return GetBotbodyPart(0); }
    public BotObject HeadPart() { return GetBotbodyPart(1); }
    public BotObject ArmPart() { return GetBotbodyPart(2); }
    public BotObject LegPart() { return GetBotbodyPart(3); }
    public BotObject GetBotbodyPart(int index)
    {
        return _botObjects[index];
    }
    public int GetBodypartIndex(BotObject obj)
    {
        int objAsInt = (int)obj;
        if (objAsInt < 1)
        {
            return -1;
        }
        if (objAsInt < 4)
        {
            return 0;
        }
        if (objAsInt < 7)
        {
            return 1;
        }
        if (objAsInt < 10)
        {
            return 2;
        }
        if (objAsInt < 13)
        {
            return 3;
        }
        return -1;
    }
}

[System.Serializable]
public class BotParts
{
    public List<GameObject> parts;
}
public enum BotObject
{
    EmptyObject = 0,

    BodyObject0 = 1,
    BodyObject1 = 2,
    BodyObject2 = 3,

    HeadObject0 = 4,
    HeadObject1 = 5,
    HeadObject2 = 6,

    ArmObject0 = 7,
    ArmObject1 = 8,
    ArmObject2 = 9,

    LegObject0 = 10,
    LegObject1 = 11,
    LegObject2 = 12
}