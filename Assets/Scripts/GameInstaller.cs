using Zenject;
using UnityEngine;
using System.Collections;

public class GameInstaller : MonoInstaller
{
    //public GameObject roseSpawnerPrefab;
    //public GameObject roseSpawner;
    public override void InstallBindings()
    {
        Container.BindFactory<string, RoseSpawner, RoseSpawner.Factory>().FromFactory<PrefabResourceFactory<RoseSpawner>>();
        Container.BindFactory<string, Rose, Rose.Factory>().FromFactory<PrefabResourceFactory<Rose>>();
        Container.BindFactory<string, PuffballSpawner, PuffballSpawner.Factory>().FromFactory<PrefabResourceFactory<PuffballSpawner>>();
        Container.BindFactory<string, Puffball, Puffball.Factory>().FromFactory<PrefabResourceFactory<Puffball>>();
        Container.Bind<ITimer>().To<Timer>().AsTransient();
        Container.Bind<ICollisionHandler>().To<CollisionHandler>().AsSingle();
        Container.Bind<RoseSkill>().AsSingle();
        Container.Bind<PuffballSkill>().AsSingle();
    }
}