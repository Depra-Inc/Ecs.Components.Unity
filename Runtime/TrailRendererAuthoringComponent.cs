// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using UnityEngine;
using static Depra.Ecs.Components.UnityComponentsAspect;

namespace Depra.Ecs.Components.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(TrailRendererRef), DEFAULT_ORDER)]
	public sealed class TrailRendererAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private TrailRenderer _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly TrailRendererAuthoringComponent _component;

			public Baker(TrailRendererAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity)authoringEntity).Unpack(out var entity))
				{
					world.Pool<TrailRendererRef>().Allocate(entity).Value = _component._value;
				}
			}
		}
	}
}