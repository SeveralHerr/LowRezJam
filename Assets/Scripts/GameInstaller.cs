using Zenject;
using UnityEngine;
using System.Collections;

public class GameInstaller : MonoInstaller
{
    public GameObject roseSpawnerPrefab;
    public GameObject roseSpawner;
    public override void InstallBindings()
    {
        Container.BindFactory<string, RoseSpawner, RoseSpawner.Factory>().FromFactory<PrefabResourceFactory<RoseSpawner>>();
        Container.BindFactory<string, Rose, Rose.Factory>().FromFactory<PrefabResourceFactory<Rose>>();
        Container.Bind<RoseSkill>().AsSingle();

        Container.BindFactory<string, PuffballSpawner, PuffballSpawner.Factory>().FromFactory<PrefabResourceFactory<PuffballSpawner>>();
        Container.BindFactory<string, Puffball, Puffball.Factory>().FromFactory<PrefabResourceFactory<Puffball>>();
        Container.Bind<PuffZigZagSkill>().AsSingle();
        Container.Bind<PuffPiercingSkill>().AsSingle();
        Container.Bind<PuffballTimeSkill>().AsSingle();
        Container.Bind<PuffballSkill>().AsSingle();


        Container.BindFactory<string, PlantRingSpawner, PlantRingSpawner.Factory>().FromFactory<PrefabResourceFactory<PlantRingSpawner>>();
        Container.BindFactory<string, PlantRing, PlantRing.Factory>().FromFactory<PrefabResourceFactory<PlantRing>>();
        Container.Bind<PlantRingSkill>().AsSingle();

        Container.BindFactory<string, RootSpikesSpawner, RootSpikesSpawner.Factory>().FromFactory<PrefabResourceFactory<RootSpikesSpawner>>();
        Container.BindFactory<string, RootSpikes, RootSpikes.Factory>().FromFactory<PrefabResourceFactory<RootSpikes>>();
        Container.Bind<RootSpikesSkill>().AsSingle();

        Container.Bind<SkillList>().AsSingle();
        Container.Bind<PiercingSkill>().AsSingle();
        Container.Bind<AttackSpeedSkill>().AsSingle();


        Container.BindFactory<string, Enemy, Enemy.Factory>().FromFactory<PrefabResourceFactory<Enemy>>();


        Container.Bind<ITimer>().To<Timer>().AsTransient();
        Container.Bind<ICollisionHandler>().To<CollisionHandler>().AsSingle();

    }

    //private void BindSkill<T>() where T : class
    //{
    //    Container.BindFactory<string, SkillFactory<T>, SkillFactory<T>.Factory>().FromFactory<PrefabResourceFactory<SkillFactory<T>>>();
    //}
}