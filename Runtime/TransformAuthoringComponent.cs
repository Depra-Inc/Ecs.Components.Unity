// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using Depra.Ecs.Hybrid;
using Depra.Ecs.QoL;
using Depra.Ecs.Transformation;
using UnityEngine;
using static Depra.Ecs.Components.UnityComponentsAspect;

namespace Depra.Ecs.Components.Authoring
{
	[DisallowMultipleComponent]
	[AddComponentMenu(MENU_PATH + nameof(TransformRef), DEFAULT_ORDER)]
	public sealed class TransformAuthoringComponent : MonoBehaviour, IAuthoring
	{
		[SerializeField] private Transform _value;

		IBaker IAuthoring.CreateBaker() => new Baker(this);

		private readonly struct Baker : IBaker
		{
			private readonly TransformAuthoringComponent _component;

			public Baker(TransformAuthoringComponent component) => _component = component;

			void IBaker.Bake(IAuthoring authoringEntity, World world)
			{
				if (((IAuthoringEntity)authoringEntity).Unpack(out var entity))
				{
					world.Pool<TransformRef>().Allocate(entity).Value = _component._value;
					world.Pool<LocalTransformationSpaceRef>().GetOrAllocate(entity).Value =
						new LocalTransformationSpace(_component._value);
					world.Pool<GlobalTransformationSpaceRef>().GetOrAllocate(entity).Value =
						new GlobalTransformationSpace(_component._value);
				}
			}
		}

		private readonly struct LocalTransformationSpace : ITransformationSpace
		{
			private readonly Transform _transform;

			public LocalTransformationSpace(Transform transform) => _transform = transform;

			Vector3 ITransformationSpace.Position
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.localPosition;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.localPosition = value;
			}

			Quaternion ITransformationSpace.Rotation
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.localRotation;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.localRotation = value;
			}

			Vector3 ITransformationSpace.Scale
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.localScale;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.localScale = value;
			}
		}

		private readonly struct GlobalTransformationSpace : ITransformationSpace
		{
			private readonly Transform _transform;

			public GlobalTransformationSpace(Transform transform) => _transform = transform;

			Vector3 ITransformationSpace.Position
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.position;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.position = value;
			}

			Quaternion ITransformationSpace.Rotation
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.rotation;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.rotation = value;
			}

			Vector3 ITransformationSpace.Scale
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get => _transform.lossyScale;
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				set => _transform.localScale = value;
			}
		}
	}
}