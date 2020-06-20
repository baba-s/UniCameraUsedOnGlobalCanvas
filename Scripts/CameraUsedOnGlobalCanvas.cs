using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// グローバルな Canvas で使用するカメラを検知するコンポーネントのインターフェイス
	/// </summary>
	public interface ICameraUsedOnGlobalCanvas
	{
		//================================================================================
		// プロパティ
		//================================================================================
		/// <summary>
		/// グローバルな Canvas で使用するカメラを返します
		/// </summary>
		Camera Camera { get; }
	}

	/// <summary>
	/// グローバルな Canvas で使用するカメラを検知するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	[RequireComponent( typeof( Camera ) )]
	public sealed class CameraUsedOnGlobalCanvas :
		MonoBehaviour,
		ICameraUsedOnGlobalCanvas
	{
		//================================================================================
		// 変数
		//================================================================================
		private Camera m_camera;

		//================================================================================
		// 変数（static readonly）
		//================================================================================
		private static readonly List<CameraUsedOnGlobalCanvas> ms_list = new List<CameraUsedOnGlobalCanvas>();

		//================================================================================
		// プロパティ
		//================================================================================
		public Camera Camera => m_camera;

		//================================================================================
		// プロパティ（static）
		//================================================================================
		public static IReadOnlyList<ICameraUsedOnGlobalCanvas> List         => ms_list;
		public static ICameraUsedOnGlobalCanvas                ActiveCamera => ms_list[ ms_list.Count - 1 ];

		//================================================================================
		// イベント（static）
		//================================================================================
		public static event Action<ICameraUsedOnGlobalCanvas> OnChange;

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// 有効になった時に呼び出されます
		/// </summary>
		private void OnEnable()
		{
			ms_list.Add( this );

			if ( m_camera == null )
			{
				m_camera = GetComponent<Camera>();
			}

			OnChange?.Invoke( this );
		}

		/// <summary>
		/// 無効になった時に呼び出されます
		/// </summary>
		private void OnDisable()
		{
			ms_list.Remove( this );
		}
	}
}