using UnityEngine;
using Zenject;

public abstract class SkillFactory<T> : MonoBehaviour
{
    public abstract class Factory : PlaceholderFactory<string, T>
    {
        public abstract T Create();
        //{
        //    return base.Create($"Prefabs/{nameof(T)}");
        //}
    }
}