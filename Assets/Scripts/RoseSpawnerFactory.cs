//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Zenject;

//public class RoseSpawnerFactory : IFactory<string, RoseSpawner>
//{
//    public DiContainer _container;

//    public RoseSpawnerFactory(DiContainer container)
//    {
//        _container = container; 
//    }
//    public RoseSpawner Create(UnityEngine.Object prefab)
//    {
//        return _container.InstantiatePrefabForComponent<RoseSpawner>(prefab);
//    }

//}
