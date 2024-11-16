// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

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