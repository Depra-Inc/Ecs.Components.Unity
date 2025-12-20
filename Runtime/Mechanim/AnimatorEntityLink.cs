// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using UnityEngine;
using static Depra.Ecs.Components.UnityComponentsAspect;

namespace Depra.Ecs.Components
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(AnimatorEntityLink), DEFAULT_ORDER)]
	public sealed class AnimatorEntityLink : MonoBehaviour, IAuthoring
	{
		public PackedEntityWithWorld Entity { get; private set; }

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly AnimatorEntityLink _component;

			public Baker(AnimatorEntityLink component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity)authoringEntity).Unpack(out var entity))
				{
					_component.Entity = world.PackEntityWithWorld(entity);
				}
			}
		}
	}
}