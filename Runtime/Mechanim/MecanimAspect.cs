using System.Runtime.CompilerServices;

namespace Depra.Ecs.Components
{
	public sealed class MecanimAspect : IComponentAspect
	{
		public ComponentPool<AnimatorRef> Animator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			private set;
		}

		public ComponentPool<AnimationCrossfadeRequest> CrossfadeRequest
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			private set;
		}

		void IComponentAspect.Initialize(AspectGroup aspects, ComponentPoolGroup pools)
		{
			aspects.Add(this);
			pools.Add(Animator = new ComponentPool<AnimatorRef>());
			pools.Add(CrossfadeRequest = new ComponentPool<AnimationCrossfadeRequest>());
		}
	}
}