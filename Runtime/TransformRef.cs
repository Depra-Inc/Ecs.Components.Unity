// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Ecs.QoL.Components;
using UnityEngine;

namespace Depra.Ecs.Components
{
	public struct TransformRef : IComponent
	{
		public Transform Value;
	}
}