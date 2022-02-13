

namespace GeekSpace
{
    public interface IDynamicModelBullet : IDynamicModel
    {
        public IPoolBullet Pool { get; set; }
    }
}
