using URLShorteningService.Core.DataAccess;
using URLShorteningService.Entities.Concrete;

namespace URLShorteningService.DataAccess.Abstract
{
    public interface ILinkDal : IEntityRepository<Link>
    {

    }
}
