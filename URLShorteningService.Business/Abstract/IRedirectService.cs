namespace URLShorteningService.Business.Abstract
{
    public interface IRedirectService
    {
        string GetURLByCode(string UrlCode);
    }
}
