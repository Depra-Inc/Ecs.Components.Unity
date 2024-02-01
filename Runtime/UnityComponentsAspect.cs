// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ecs.Worlds;

namespace Depra.Ecs.Components
{
	public sealed class UnityComponentsAspect : IComponentAspect
	{
		public ComponentPool<CameraRef> Cameras { get; private set; }
		public ComponentPool<AnimatorRef> Animators { get; private set; }
		public ComponentPool<TransformRef> Transforms { get; private set; }
		public ComponentPool<LineRendererRef> LineRenderers { get; private set; }

		void IComponentAspect.Initialize(World world)
		{
			world.AddAspect(this);
			world.AddPool(Cameras = new ComponentPool<CameraRef>());
			world.AddPool(Animators = new ComponentPool<AnimatorRef>());
			world.AddPool(Transforms = new ComponentPool<TransformRef>());
			world.AddPool(LineRenderers = new ComponentPool<LineRendererRef>());
		}

		void IComponentAspect.PostInitialize() { }
	}
}