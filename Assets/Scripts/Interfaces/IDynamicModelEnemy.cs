
namespace GeekSpace
{
    public interface IDynamicModelEnemy : IDynamicModel
    {
        public IPoolEnemy Pool { get; set; }
    }
}
