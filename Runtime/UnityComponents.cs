using Depra.Ecs.Worlds;

namespace Depra.Ecs.Components.Runtime
{
	public sealed class UnityComponents : IWorldRegistry
	{
		internal ComponentPool<RigidbodyRef> Rigidbodies { get; private set; }
		internal ComponentPool<CharacterControllerRef> CharacterControllers { get; private set; }

		void IWorldRegistry.Initialize(World world)
		{
			world.AddRegistry(this);
			world.AddPool(Rigidbodies = new ComponentPool<RigidbodyRef>());
			world.AddPool(CharacterControllers = new ComponentPool<CharacterControllerRef>());
		}

		void IWorldRegistry.PostInitialize() { }
	}
}