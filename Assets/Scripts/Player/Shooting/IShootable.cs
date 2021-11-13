namespace Player.Shooting
{
    public interface ISHootable
    {
        void OnShot(float damage);
        void OnShot(float damage, UnityEngine.Vector3 direction);
    }
}