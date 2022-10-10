using System;
using URLShorteningService.Business.Abstract;
using URLShorteningService.DataAccess.Abstract;

namespace URLShorteningService.Business.Concrete
{
    public class RedirectManager : IRedirectService
    {
        private ILinkDal _linkDal;
        public RedirectManager(ILinkDal linkDal)
        {
            _linkDal = linkDal;
        }
        public string GetURLByCode(string UrlCode)
        {
            var link = _linkDal.Get(x=>x.ShorteningCode == UrlCode);
            if(link == null)
            {
                throw new Exception($"This shortening code : {UrlCode} does not exist.");
            }
            return link.OriginalURL;
        }
    }
}
