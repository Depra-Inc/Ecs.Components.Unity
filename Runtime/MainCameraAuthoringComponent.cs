// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using UnityEngine;
using static Depra.Ecs.Components.UnityComponentsAspect;

namespace Depra.Ecs.Components.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(CameraRef), DEFAULT_ORDER)]
	public sealed class MainCameraAuthoringComponent : MonoBehaviour, IAuthoring
	{
		IBaker IAuthoring.CreateBaker() => new Baker();

		private readonly struct Baker : IBaker
		{
			void IBaker.Bake(IAuthoring authoring, World world)
			{
				if (((IAuthoringEntity)authoring).Unpack(out var entity))
				{
					world.Pool<CameraRef>().Allocate(entity).Value = Camera.main;
				}
			}
		}
	}
}