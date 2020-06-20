using UnityEngine;

namespace Kogane
{
	/// <summary>
	/// グローバルな Canvas で使用するカメラを設定するコンポーネント
	/// </summary>
	[DisallowMultipleComponent]
	[RequireComponent( typeof( Canvas ) )]
	internal sealed class SetCameraOnGlobalCanvas : MonoBehaviour
	{
		//==============================================================================
		// 変数
		//==============================================================================
		private Canvas m_canvas;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 初期化する時に呼び出されます
		/// </summary>
		private void Awake()
		{
			m_canvas = GetComponent<Canvas>();

			CameraUsedOnGlobalCanvas.OnChange += OnChangeCameraUsedOnGlobalCanvas;
		}
		
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			OnChangeCameraUsedOnGlobalCanvas( CameraUsedOnGlobalCanvas.ActiveCamera );
		}

		/// <summary>
		/// 破棄する時に呼び出されます
		/// </summary>
		private void OnDestroy()
		{
			CameraUsedOnGlobalCanvas.OnChange -= OnChangeCameraUsedOnGlobalCanvas;
		}

		/// <summary>
		/// グローバルな Canvas で使用するカメラが変更された時に呼び出されます
		/// </summary>
		private void OnChangeCameraUsedOnGlobalCanvas( ICameraUsedOnGlobalCanvas worldCamera )
		{
			m_canvas.worldCamera = worldCamera.Camera;
		}
	}
}