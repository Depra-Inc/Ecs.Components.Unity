﻿// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ecs.Worlds;

namespace Depra.Ecs.Components
{
	public sealed class UnityComponentsAspect : IComponentAspect
	{
		public ComponentPool<CameraRef> Cameras { get; private set; }
		public ComponentPool<SliderRef> Sliders { get; private set; }
		public ComponentPool<AnimatorRef> Animators { get; private set; }
		public ComponentPool<TransformRef> Transforms { get; private set; }
		public ComponentPool<RigidbodyRef> Rigidbodies { get; private set; }
		public ComponentPool<LineRendererRef> LineRenderers { get; private set; }
		public ComponentPool<RigidbodyForceMode> ForceModes { get; private set; }
		public ComponentPool<CharacterControllerRef> CharacterControllers { get; private set; }

		void IComponentAspect.Initialize(World world)
		{
			world.AddAspect(this);
			world.AddPool(Cameras = new ComponentPool<CameraRef>());
			world.AddPool(Sliders = new ComponentPool<SliderRef>());
			world.AddPool(Animators = new ComponentPool<AnimatorRef>());
			world.AddPool(Transforms = new ComponentPool<TransformRef>());
			world.AddPool(Rigidbodies = new ComponentPool<RigidbodyRef>());
			world.AddPool(LineRenderers = new ComponentPool<LineRendererRef>());
			world.AddPool(ForceModes = new ComponentPool<RigidbodyForceMode>());
			world.AddPool(CharacterControllers = new ComponentPool<CharacterControllerRef>());
		}

		void IComponentAspect.PostInitialize() { }
	}
}