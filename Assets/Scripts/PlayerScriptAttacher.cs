using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttach
{
    public void Attach(GameObject target);
}

//public class PlayerScriptAttacher : MonoBehaviour 
//{
//    public IAttach<T> script;
//    // Start is called before the first frame update
//    void Start()
//    {
//        Player.Instance.gameObject.AddComponent(typeof(script));
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
