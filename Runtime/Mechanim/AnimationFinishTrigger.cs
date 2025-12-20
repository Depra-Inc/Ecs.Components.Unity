// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Ecs.QoL;
using UnityEngine;

namespace Depra.Ecs.Components
{
	public abstract class AnimationFinishTrigger<TAnimation> : StateMachineBehaviour
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (animator.TryGetComponent(out AnimatorEntityLink link) &&
			    link.Entity.Unpack(out var world, out var entity))
			{
				world.Pool<AnimationFinishedEvent<TAnimation>>().TryAllocate(entity);
			}
		}
	}
}