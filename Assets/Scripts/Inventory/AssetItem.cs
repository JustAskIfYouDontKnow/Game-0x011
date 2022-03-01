using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemMenu")]
public class AssetItem : ScriptableObject, IItem
{
    public string Name => throw new NotImplementedException();

    public Sprite UIIcon => throw new NotImplementedException();

    [SerializeField] private string _name;
    [SerializeField] private Sprite _uiIcon;
}
