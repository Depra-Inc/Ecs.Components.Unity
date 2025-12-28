// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;

namespace Depra.Ecs.Components
{
	[Serializable]
	public struct AnimatorRef
	{
		public Animator Value;
	}
}