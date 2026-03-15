// SPDX-License-Identifier: Apache-2.0
// © 2023-2026 Depra <n.melnikov@depra.org>

using Depra.Ecs.Modules;

namespace Depra.Ecs.Components
{
	public sealed class MecanimModule : IModule
	{
		IComponentAspect[] IModule.Aspects { get; } = { new MecanimAspect() };

		void IModule.Initialize(ISystemGroup systems) => systems.Add(new MecanimCrossfadeSystem());
	}
}