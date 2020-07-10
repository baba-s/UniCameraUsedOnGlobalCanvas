# UniCameraUsedOnGlobalCanvas

グローバルな Canvas で使用するカメラを自動で割り当てるコンポーネント

## 使用例

![2020-07-10_142228](https://user-images.githubusercontent.com/6134875/87119398-d3b75580-c2b8-11ea-80dd-5383125fa250.png)

各シーンの Camera に「CameraUsedOnGlobalCanvas」コンポーネントをアタッチして  

![2020-07-10_142259](https://user-images.githubusercontent.com/6134875/87119401-d4e88280-c2b8-11ea-9a90-d213b39916c3.png)

グローバルなシーンの Canvas に「SetCameraOnGlobalCanvas」をアタッチすることで  
シーンが切り替わった時に、グローバルなシーンの Canvas が  
現在のシーンのカメラを自動で参照するようになります  

これでグローバルなシーンの Canvas 専用のカメラを用意する必要がなくなるため、描画負荷を削減できます  
