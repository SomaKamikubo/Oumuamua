@startuml
左右入力 -> PlayerPresenter : 何キーが押されたか
PlayerPresenter -> PlayerModel : プレイヤーの動きを指示 
PlayerPresenter -> PlayerAnimator : プレイヤーのアニメーションを指示 

@enduml