using TheEye.Core.DataAccess.EntityFramework;
using URLShorteningService.DataAccess.Abstract;
using URLShorteningService.DataAccess.Context;
using URLShorteningService.Entities.Concrete;

namespace URLShorteningService.DataAccess.Concrete.EntitiyFramework
{
    public class EfLinkDal : EfEntityRepositoryBase<Link, URLShorteningContext>, ILinkDal
    {

    }
}
