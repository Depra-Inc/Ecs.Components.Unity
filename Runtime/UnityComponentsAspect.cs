// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

namespace Depra.Ecs.Components
{
	public sealed class UnityComponentsAspect : IComponentAspect
	{
		public const int DEFAULT_ORDER = 52;
		public const string MENU_PATH = nameof(Ecs) + "/" + nameof(Components) + "/";

		public ComponentPool<CameraRef> Cameras { get; private set; }
		public ComponentPool<AnimatorRef> Animators { get; private set; }
		public ComponentPool<TransformRef> Transforms { get; private set; }
		public ComponentPool<LineRendererRef> LineRenderers { get; private set; }

		void IComponentAspect.Initialize(AspectGroup aspects, ComponentPoolGroup pools)
		{
			aspects.Add(this);
			pools.Add(Cameras = new ComponentPool<CameraRef>());
			pools.Add(Animators = new ComponentPool<AnimatorRef>());
			pools.Add(Transforms = new ComponentPool<TransformRef>());
			pools.Add(LineRenderers = new ComponentPool<LineRendererRef>());
		}
	}
}