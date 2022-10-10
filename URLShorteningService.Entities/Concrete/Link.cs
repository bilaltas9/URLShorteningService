using URLShorteningService.Core.Entities;

namespace URLShorteningService.Entities.Concrete
{
    public class Link : IEntity
    {
        public int Id { get; set; }
        public string ShorteningCode { get; set; }
        public string OriginalURL { get; set; }
    }
}
