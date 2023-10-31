// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ecs.Worlds;

namespace Depra.Ecs.Components.Runtime
{
	public sealed class UnityComponents : IWorldRegistry
	{
		public ComponentPool<RigidbodyRef> Rigidbodies { get; private set; }
		public ComponentPool<CharacterControllerRef> CharacterControllers { get; private set; }

		void IWorldRegistry.Initialize(World world)
		{
			world.AddRegistry(this);
			world.AddPool(Rigidbodies = new ComponentPool<RigidbodyRef>());
			world.AddPool(CharacterControllers = new ComponentPool<CharacterControllerRef>());
		}

		void IWorldRegistry.PostInitialize() { }
	}
}