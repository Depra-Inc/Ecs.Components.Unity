// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

namespace Depra.Ecs.Components
{
	[System.Serializable]
	public struct AnimationCrossfadeRequest
	{
		public int AnimationHash;
		public float TransitionDuration;
	}
}