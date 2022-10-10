using URLShorteningService.Business.Dto;

namespace URLShorteningService.Business.Abstract
{
    public interface IShorteningService
    {
        string Shortening(ShorteningDto customShorteningDto);
    }
}
