﻿// SPDX-License-Identifier: Apache-2.0
// © 2023 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using UnityEngine;

namespace Depra.Ecs.Components.Runtime
{
	[Serializable]
	public struct CharacterControllerRef
	{
		public CharacterController Value;
	}
}