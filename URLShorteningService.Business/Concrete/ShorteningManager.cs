using System;
using URLShorteningService.Business.Abstract;
using URLShorteningService.Business.Dto;
using URLShorteningService.Core.Const;
using URLShorteningService.DataAccess.Abstract;
using URLShorteningService.Entities.Concrete;

namespace URLShorteningService.Business.Concrete
{
    public class ShorteningManager : IShorteningService
    {
        private ILinkDal _linkDal;
        public ShorteningManager(ILinkDal linkDal)
        {
            _linkDal = linkDal;
        }

        public string Shortening(ShorteningDto shorteningDto)
        {
            if(shorteningDto.ShorteningText == null)
            {
                return CreateGenericShortening(shorteningDto);
            }

            var link = _linkDal.Get(x => x.ShorteningCode == shorteningDto.ShorteningText);
            if (link != null)
            {
                throw new Exception($"This shortening : {Consts.URL.ReponseURL + shorteningDto.ShorteningText} already exist.");
            }

            var newLink = new Link()
            {
                OriginalURL = shorteningDto.URL,
                ShorteningCode = shorteningDto.ShorteningText
            };

            _linkDal.Add(newLink);

            return Consts.URL.ReponseURL + shorteningDto.ShorteningText;
        }

        public string CreateGenericShortening(ShorteningDto shorteningDto)
        {
            var code = "";
            var link = new Link();
            do
            {
                code = CreateChorteningCode();
                link = _linkDal.Get(x => x.ShorteningCode == code);
            } while (link != null);

            var newLink = new Link()
            {
                OriginalURL = shorteningDto.URL,
                ShorteningCode = code
            };

            _linkDal.Add(newLink);

            return Consts.URL.ReponseURL + code;
        }

        public string CreateChorteningCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
