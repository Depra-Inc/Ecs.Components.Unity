// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using Depra.Ecs.QoL;

namespace Depra.Ecs.Components
{
	public sealed class MecanimCrossfadeSystem : IInitializationSystem, IExecutionSystem
	{
		private EntityQuery _entities;
		private MecanimAspect _mecanim;

		void IInitializationSystem.Initialize(IWorldGroup worlds)
		{
			_entities = new EntityQueryBuilder()
				.With<AnimatorRef>()
				.With<AnimationCrossfadeRequest>()
				.Build();

			var world = worlds.Default;
			_entities.Initialize(world);
			_mecanim = world.Aspect<MecanimAspect>();
		}

		void IExecutionSystem.Execute()
		{
			foreach (var entity in _entities)
			{
				var request = _mecanim.CrossfadeRequest[entity];
				_mecanim.Animator[entity].Value.CrossFade(request.AnimationHash, request.TransitionDuration);
				_mecanim.CrossfadeRequest.Delete(entity);
			}
		}
	}
}