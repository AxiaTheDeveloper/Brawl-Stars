# Brawl Stars
 
IMPLEMENTASI Game Optimization
- Penggunaan Couroutine dibanding Invoke()
- Membuat const string untuk tags atau trigger pada animasi dan pada playerprefs
- Menghilangkan function yang kosong atau tidak dipakai
- Menggunakkan CompareTag() dibanding Gameobject.Tag()


===================================================================================================================================================

IMPLEMENTASI SOLID

SRP : PlayerAnimator.cs, PlayerAttackRotasi.cs, PlayerAttack.cs, PlayerCollision.cs, PlayerIdentity.cs, PlayerMovement.cs, PlayerRotation.cs, CountDownUI.cs, EndUI.cs, HealthBarUI.cs, HealthLayarUI.cs, MainMenuUI.cs, BrawlGameManager.cs, Bullet.cs, BulletPool.cs, BulletSpawnPlace.cs, BulletThrow.cs, GameInput.cs, PlayerRecognition.cs

OCP, LSP :  interface IAttackShoot & IAttackThrow dalam PlayerAttack.cs
