// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using UnityEngine;
using static Depra.Ecs.Components.UnityComponentsAspect;

namespace Depra.Ecs.Components.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(LineRendererRef), DEFAULT_ORDER)]
	public sealed class LineRendererAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private LineRenderer _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly LineRendererAuthoringComponent _component;

			public Baker(LineRendererAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity)authoringEntity).Unpack(out var entity))
				{
					world.Pool<LineRendererRef>().Allocate(entity).Value = _component._value;
				}
			}
		}
	}
}